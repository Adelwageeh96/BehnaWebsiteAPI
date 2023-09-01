using BenhaWebsite.Core.Dtos.AuthenticationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.IRepositories
{
    public interface IAuthRepository
	{
		Task<AuthDto> RegisterAsync(RegisterDto dto);
		Task<AuthDto> GetTokenAsync(TokenRequestDto dto);
		Task<string> ConfirmEmailAsync(ConfirmEmailDto dto);
		Task<UserDataDto> GetUserDataAsync(UserDataDto dto);
		//	Task<bool> SendChangePasswordEmailAsync(string email);
		Task<string> ConfirmChangePasswordAsync(ResetPasswordDto dto);
	}
}
