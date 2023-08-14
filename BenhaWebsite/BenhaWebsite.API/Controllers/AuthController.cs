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
				return NotFound(result.Message);
			return Ok(result);
		}

		[HttpPost("Login")]
		public async Task<IActionResult> LoginAsync(TokenRequestDto dto)
		{
			var result = await _authRepository.GetTokenAsync(dto);
			if (!result.IsAuthenticated)
				return NotFound(result.Message);
			return Ok(result);
		}

	}
}
