using BenhaWebsite.Core.Dtos.AuthenticationDtos;
using BenhaWebsite.Core.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BenhaWebsite.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthRepository _authRepository;
        
		public AuthController(IAuthRepository authRepository)
		{
			_authRepository = authRepository;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> RegisterAsync([FromForm]RegisterDto dto)
		{
			var result = await _authRepository.RegisterAsync(dto);
			if (!result.IsAuthenticated)
				return BadRequest(result.Message);
			return Ok(result);
		}

		[HttpPost("Login")]
		public async Task<IActionResult> LoginAsync(TokenRequestDto dto)
		{
			var result = await _authRepository.GetTokenAsync(dto);
			if (!result.IsAuthenticated)
				return BadRequest(result.Message);
			return Ok(result);
		}
		[HttpGet("ConfirmEmail")]
		public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId,[FromQuery]string token)
		{
			string result = await _authRepository.ConfirmEmailAsync(new ConfirmEmailDto { Token=token,UserId=userId});
			if (!string.IsNullOrEmpty(result))
				return BadRequest(result);
			return Ok("Email Confirmed");

		}
		[HttpPost("GetUserData")]
		public async Task<IActionResult> GetUserDataAsync(UserDataDto dto)
		{
			var result= await _authRepository.GetUserDataAsync(dto);
			if (!string.IsNullOrEmpty(result.Message))
				return BadRequest(result.Message);
			return Ok(result);
		}

		[HttpPost("ConfirmResetPassword")]
		public async Task<IActionResult> ConfirmResetPasswordAsync(ResetPasswordDto dto)
		{
			var result = await _authRepository.ConfirmChangePasswordAsync(dto);
			if (!string.IsNullOrEmpty(result))
				return BadRequest(result);
			return Ok("Password reset");
		}





	}
}
