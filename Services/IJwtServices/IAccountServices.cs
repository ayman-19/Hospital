using Domain.Models;
using Dtos.Jwt;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IJwtServices
{
	public interface IAccountServices
	{
		Task<AuthModelDto> RegisterAsync(RegisterDto dto);
		Task<AuthModelDto> LoginAsync(LoginDto dto);
		Task<AuthModelDto> RefreshTokenAsync(string token);
		Task<bool> RevokeTokenAsync(string token);
		Task<string> AddRoleAsync(AddRoleDto dto);
	}
}
