using Domain.Models;
using Dtos.Jwt;
using Infrastructure.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.IJwtServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.JwtServices
{
	public class AccountServices : IAccountServices
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly UserManager<User> userManager;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly Jwt _jwt;

		public AccountServices(IUnitOfWork unitOfWork, UserManager<User> userManager, IOptions<Jwt> jwt,
			RoleManager<IdentityRole> roleManager)
		{
			this.unitOfWork = unitOfWork;
			this.userManager = userManager;
			this.roleManager = roleManager;
			_jwt = jwt.Value;
		}

		public async Task<string> AddRoleAsync(AddRoleDto dto)
		{
			User user = await unitOfWork.Users.GetAsync(u => u.Id == dto.UserId);
			if (user is null || !await roleManager.RoleExistsAsync(dto.RoleName))
				return "User Or Role InValid!";
			if (await userManager.IsInRoleAsync(user, dto.RoleName))
				return "User already assigned this Role";
			var result = await userManager.AddToRoleAsync(user,dto.RoleName);
			var getRefreshToken = user.RefreshTokens.FirstOrDefault(r => r.IsValid);
			if (getRefreshToken is not null)
				getRefreshToken.RevokeOn = DateTime.Now;
			return result.Succeeded ? string.Empty : "Errors";
			throw new NotImplementedException();
		}

		

		public async Task<AuthModelDto> LoginAsync(LoginDto dto)
		{
			var user = await unitOfWork.Users.GetAsync(u => u.Email == dto.Email,
				   new string[] { "RefreshTokens" });
			if (user is null || !await userManager.CheckPasswordAsync(user, dto.Password))
				return new AuthModelDto { Massage = "Email Or Password InValed!" };
			var oldToken = user.RefreshTokens.FirstOrDefault(r => r.IsValid);
			var userToken = new AuthModelDto();
			if (oldToken is not null)
			{
				userToken.AccessToken = oldToken.AccessToken;
				userToken.RefreshToken = oldToken.RefreshJwtToken;
			}


			if (!user.RefreshTokens.Any(x => x.IsValid))
			{
				var generateToken = await CreateAccessTokenAsync(user);
				var token = new JwtSecurityTokenHandler().WriteToken(generateToken);
				userToken.AccessToken = token;
				userToken.AccessTokenExpireOn = generateToken.ValidTo;
				RefreshToken? generateRefreshToken = CreateRefreshToken();
				generateRefreshToken.AccessToken = token;
				generateRefreshToken.AccessTokenExpiration = generateToken.ValidTo;
				userToken.RefreshToken = generateRefreshToken.RefreshJwtToken;
				userToken.RefreshTokenExpireOn = generateRefreshToken.ExpireOn;
				user.RefreshTokens.Add(generateRefreshToken);
				unitOfWork.Users.Update(user);
				await unitOfWork.SaveChangesAsync();
			}
			userToken.IsAuthanticated = true;
			userToken.UserId = user.Id;
			userToken.UserName = user.UserName;
			return userToken;
		}

		public async Task<AuthModelDto> RefreshTokenAsync(string token)
		{
			var user = await unitOfWork.Users.GetAsync(r => r.RefreshTokens.Any(r => r.RefreshJwtToken == token));
			if (user is null)
				return new AuthModelDto { Massage = "User Or Token Invalid!" };
			var jwtRefreshToken = user.RefreshTokens.FirstOrDefault(r => r.RefreshJwtToken == token);

			if (!jwtRefreshToken.IsValid)
				return new AuthModelDto { Massage = "Token Not Active!" };

			jwtRefreshToken.RevokeOn = DateTime.Now;

			var generateNewRefreshToken = CreateRefreshToken();
			generateNewRefreshToken.AccessToken = jwtRefreshToken.AccessToken;
			generateNewRefreshToken.AccessTokenExpiration = jwtRefreshToken.AccessTokenExpiration;
			user.RefreshTokens.Add(generateNewRefreshToken);
			unitOfWork.Users.Update(user);
			await unitOfWork.SaveChangesAsync();
			return new AuthModelDto
			{
				AccessToken = jwtRefreshToken.AccessToken,
				AccessTokenExpireOn = jwtRefreshToken.AccessTokenExpiration,
				IsAuthanticated = true,
				RefreshToken = generateNewRefreshToken.RefreshJwtToken,
				RefreshTokenExpireOn = generateNewRefreshToken.ExpireOn,
				UserId = user.Id,
				UserName = user.UserName
			};

		}

		public async Task<AuthModelDto> RegisterAsync(RegisterDto dto)
		{
			if (await unitOfWork.Users.IsAnyExistAsync(u => u.Email == dto.Email))
				return new AuthModelDto { Massage = "Email Already Register!" };

			if (await unitOfWork.Users.IsAnyExistAsync(u => u.UserName == dto.UsarName))
				return new AuthModelDto { Massage = "UserName Already Exist!" };

			User user = new User
			{
				UserName = dto.UsarName,
				Email = dto.Email,
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				Address = dto.Address,
			};

			var result = await userManager.CreateAsync(user, dto.Password);
			if (!result.Succeeded)
			{
				var errors = string.Empty;
				foreach (var error in result.Errors)
					errors += $"{error},";
				return new AuthModelDto { Massage = errors };
			}

			await userManager.AddToRoleAsync(user, "User");
			var getAccessToken = await CreateAccessTokenAsync(user);
			var token = new JwtSecurityTokenHandler().WriteToken(getAccessToken);

			var getRefreshToken = CreateRefreshToken();
			getRefreshToken.AccessToken = token;
			getRefreshToken.AccessTokenExpiration = getAccessToken.ValidTo;
			user.RefreshTokens.Add(getRefreshToken);
			unitOfWork.Users.Update(user);


			return new AuthModelDto
			{
				AccessToken = token,
				AccessTokenExpireOn = getAccessToken.ValidTo,
				IsAuthanticated = true,
				RefreshToken = getRefreshToken.RefreshJwtToken,
				RefreshTokenExpireOn = getRefreshToken.ExpireOn,
				UserId = user.Id
			};
		}

		public async Task<bool> RevokeTokenAsync(string token)
		{
			var user = await unitOfWork.Users.GetAsync(r => r.RefreshTokens.Any(r => r.RefreshJwtToken == token));
			if (user is null)
				return false;
			var jwtRevokeToken = user.RefreshTokens.FirstOrDefault(r => r.RefreshJwtToken == token);

			if (!jwtRevokeToken.IsValid)
				return false;

			jwtRevokeToken.RevokeOn = DateTime.Now;
			unitOfWork.Users.Update(user);
			await unitOfWork.SaveChangesAsync();
			return true;
		}

		private async Task<JwtSecurityToken> CreateAccessTokenAsync(User user)
		{
			var userClaims = await userManager.GetClaimsAsync(user);
			var roleUser = await userManager.GetRolesAsync(user);
			var roleUserClaims = new List<Claim>();
			foreach (var role in roleUser)
				roleUserClaims.Add(new Claim(ClaimTypes.Role, role));

			var Claims = new List<Claim>
			{
					new Claim(ClaimTypes.Email,user.Email),
				new Claim(ClaimTypes.Name,user.UserName),
				new Claim(ClaimTypes.PrimarySid,user.Id),
			};
			Claims.AddRange(roleUserClaims);
			Claims.AddRange(userClaims);
			var symetreckey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
			var signCreadential = new SigningCredentials(symetreckey, SecurityAlgorithms.HmacSha256);
			return new JwtSecurityToken(issuer:_jwt.Issuer,audience:_jwt.Audience,claims: Claims, signingCredentials: signCreadential, expires: DateTime.Now.AddMonths((int)_jwt.AccessTokenExiretionDate));
		}
		private RefreshToken CreateRefreshToken()
		{
			var token = new byte[64];
			var generator = RandomNumberGenerator.Create();
			generator.GetBytes(token);
			return new RefreshToken
			{
				RefreshJwtToken = Convert.ToBase64String(token),
				CreateOn = DateTime.Now,
				ExpireOn = DateTime.Now.AddMonths((int)_jwt.RefreshTokenExiretionDate)
			};
		}
	}
}
