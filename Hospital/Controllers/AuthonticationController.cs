using Dtos.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IJwtServices;
using Services.IServices;

namespace Hospital.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AuthonticationController : ControllerBase
	{
		private readonly IAccountServices accountServices;
		private readonly IUserService _userService;

		public AuthonticationController(IAccountServices accountServices, IUserService userService)
		{
			this.accountServices = accountServices;
			_userService = userService;
		}


		/// <summary>
		/// New Account
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPost, ActionName("RegisterAsync")]


		public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var result = await accountServices.RegisterAsync(dto);

			if (!result.IsAuthanticated)
				return BadRequest(result.Massage);

			//SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpireOn);
			return Ok(result);
		}
		/// <summary>
		/// Login Again
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPost, ActionName("LoginAsync")]
		public async Task<IActionResult> LoginAsync([FromForm] LoginDto dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			var result = await accountServices.LoginAsync(dto);
			if (!result.IsAuthanticated)
				return BadRequest(result.Massage);
			SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpireOn);
			return Ok(result);
		}
		/// <summary>
		/// Add To Role
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPost, ActionName("AddToRoleAysnc")]
		public async Task<IActionResult> AddToRoleAysnc([FromForm] AddRoleDto dto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);
			if (!await _userService.AnyExistByIdAysnc(dto.UserId)) return BadRequest("User Not Found!");
			var addToRole = await accountServices.AddRoleAsync(dto);
			if (!string.IsNullOrEmpty(addToRole)) return BadRequest(addToRole);
			return Ok();
		}
		/// <summary>
		/// New Refresh-Token
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpGet, ActionName("RefreshTokenAysnc")]
		public async Task<IActionResult> RefreshTokenAysnc()
		{
			var refreshTokenInCookie = Request.Cookies["RefreshToken"];
			if (string.IsNullOrEmpty(refreshTokenInCookie))
				return BadRequest("Token InValid!");
			var result = await accountServices.RefreshTokenAsync(refreshTokenInCookie);
			if (!result.IsAuthanticated)
				return BadRequest(result.Massage);
			SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpireOn);
			return BadRequest(result);
		}
		/// <summary>
		/// Revoke-Token
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpGet, ActionName("RevokeTokenAysnc")]
		public async Task<IActionResult> RevokeTokenAysnc()
		{
			var refreshTokenInCookie = Request.Cookies["RefreshToken"];
			if (string.IsNullOrEmpty(refreshTokenInCookie))
				return BadRequest("Token InValid!");
			var result = await accountServices.RevokeTokenAsync(refreshTokenInCookie);
			if (!result) return BadRequest("Token Not Active!");
			return Ok(result);
		}
		private void SetRefreshTokenInCookie(string refreshToken, DateTime expire)
		{
			var cookie = new CookieOptions
			{
				HttpOnly = true,
				Expires = expire.ToLocalTime(),
				Secure = true
			};
			Response.Cookies.Append("RefreshToken", refreshToken, cookie);
		}
	}
}
