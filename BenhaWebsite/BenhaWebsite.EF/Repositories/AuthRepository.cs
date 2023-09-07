using Azure.Core;
using BenhaWebsite.Core;
using BenhaWebsite.Core.Dtos.AuthenticationDtos;
using BenhaWebsite.Core.Helpers;
using BenhaWebsite.Core.Helpers.Constants;
using BenhaWebsite.Core.IRepositories;
using BenhaWebsite.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail; 
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BenhaWebsite.EF.Repositories
{
	public class AuthRepository : IAuthRepository
	{
		private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
		private readonly IMailingRepository _mailingRepository;
		private readonly ICodeforcesRepository _codeforcesRepository;
		private readonly JWT _jwt;
		

		private List<string> _allowedExtenstions = new List<string> { ".JPG", ".PNG" };
		private long _maxAllowedProfilePhotoSize = 3145728;
		public AuthRepository(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, IOptions<JWT> jwt, IMailingRepository mailingRepository, ICodeforcesRepository codeforcesRepository)
		{
			_userManager = userManager;
			_unitOfWork = unitOfWork;
			_jwt = jwt.Value;
			_mailingRepository = mailingRepository;
			_codeforcesRepository = codeforcesRepository;
		}

		public async Task<AuthDto> RegisterAsync(RegisterDto dto)
		{
			var errors = new List<string>();

			if (await _userManager.FindByEmailAsync(dto.Email) is not null)
				errors.Add("Email already used!");
			if (await _userManager.FindByNameAsync(dto.UserName) is not null)
				errors.Add("User Name already used!");

			if (await _codeforcesRepository.CheckHandleValidity(dto.CodeforceHandle))
			{
				if (_userManager.Users.Any(u => u.CodeforceHandle == dto.CodeforceHandle))
					errors.Add("Codeforce Handle already used!");
			}
			else
				errors.Add("Invaild codeforce handle");


			if (_userManager.Users.Any(u => u.PhoneNumber == dto.PhoneNumber))
				errors.Add("Phone Number already used!");

			if (dto.PhoneNumber.Length != 11)
				errors.Add("Phone Number should be 11 digits long!");

			var fileExtension = Path.GetExtension(dto.ProfilePicture.FileName)?.ToUpper();
			if (!_allowedExtenstions.Contains(fileExtension))
				errors.Add("Only .png and .jpg images are allowed!");

			if (dto.ProfilePicture.Length > _maxAllowedProfilePhotoSize)
				errors.Add("Max allowed size for profile picture is 3MB!");

			if (errors.Any())
				return new AuthDto { Message = string.Join("\n", errors) };

			using var dataStream = new MemoryStream();
			await dto.ProfilePicture.CopyToAsync(dataStream);

			var user = new ApplicationUser
			{
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				Email = dto.Email,
				CodeforceHandle = dto.CodeforceHandle,
				PhoneNumber = dto.PhoneNumber,
				FacebookLink = dto.FacebookLink,
				BirthDate = dto.BirthDate,
				Gender = dto.Gender,
				ProfilePicture = dataStream.ToArray(),
				UserName= dto.UserName
			};

			var result = await _userManager.CreateAsync(user, dto.Password);
			if (!result.Succeeded)
			{
				var errorMessages = result.Errors.Select(error => error.Description);
				return new AuthDto { Message = string.Join("\n", errorMessages) };
			}

			if (!string.IsNullOrEmpty(dto.EmployeeRegistrationCode))
			{
				AddEmployeeDto employeeDto = new AddEmployeeDto { UserId = user.Id, RegistrationCode = dto .EmployeeRegistrationCode };
				if (!await AddEmployeeAsync(employeeDto))
					return new AuthDto { Message = "Invaild employee code" };
			}

			await _userManager.AddToRoleAsync(user, Role.User);

			var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
			var userIdParameter = $"userId={Uri.EscapeDataString(user.Id)}";
			var tokenParameter = $"token={Uri.EscapeDataString(emailConfirmationToken)}";
			var query = $"{userIdParameter}&{tokenParameter}";
			var uriBuilder = new UriBuilder
			{
				Scheme = "http",
				Host = "localhost",
				Port = 5237,
				Path = "api/Auth/ConfirmEmail",
				Query = query,
			};

			var confirmationUrl = uriBuilder.ToString();
			string subject = "Confirm Your Email";
			string message = $"Please confirm your email by clicking <a href='{confirmationUrl}'>here</a>.";
			await _mailingRepository.SendEmailAsync(user.Email, subject, message);
			var jwtSecurityToken = await CreateJwtTokenAsync(user);
			return new AuthDto
			{
				Email = user.Email,
				ExpiresOn = jwtSecurityToken.ValidTo,
				IsAuthenticated = true,
				Roles = _userManager.GetRolesAsync(user).Result.ToList(),
				Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
				UserName = user.UserName
			};
		}

		public async Task<string> ConfirmEmailAsync(ConfirmEmailDto dto)
		{
			if (dto.UserId is null || dto.Token is null)
				return $"Can't confirm email!";
			var user = await _userManager.FindByIdAsync(dto.UserId);
			if (user is null)
				return $"Can't confirm email!";
			var result = await _userManager.ConfirmEmailAsync(user, dto.Token);

			return (!result.Succeeded) ? String.Join("\n", result.Errors) : String.Empty;
		}




		public async Task<AuthDto> GetTokenAsync(TokenRequestDto dto)
		{
			AuthDto authDto = new();
			var vaildEmail = new EmailAddressAttribute().IsValid(dto.UserIdentifier);
			ApplicationUser? user = new();
			if (vaildEmail)
			{
				user = await _userManager.FindByEmailAsync(dto.UserIdentifier);
				if(user is null)
				{
					authDto.Message = "Invaild login attempt"; 
					return authDto;
				}
			}
			else
			{
				user = await _userManager.FindByNameAsync(dto.UserIdentifier);
				if (user is null)
				{
					authDto.Message = "Invaild login attempt";
					return authDto;
				}
			}
			if(!await _userManager.IsEmailConfirmedAsync(user))
			{
				authDto.Message = "Please confirm your email first";
				return authDto;
			}

			if(!await _userManager.CheckPasswordAsync(user, dto.Password))
			{
				authDto.Message="Invaild login attempt";
				return authDto;
			}
			var jwtSecurityToken= await CreateJwtTokenAsync(user);
			var roles = await _userManager.GetRolesAsync(user);

			authDto.IsAuthenticated=true;
			authDto.Email = user.Email;
			authDto.UserName = user.UserName;
			authDto.ExpiresOn = jwtSecurityToken.ValidTo;
			authDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
			authDto.Roles = roles.ToList();

			return authDto;
		}


		public async Task<UserDataDto> GetUserDataAsync(UserDataDto dto)
		{
			UserDataDto resDto = new();
			var vaildEmail = new EmailAddressAttribute().IsValid(dto.UserIdentifier);
			ApplicationUser? user = new();
			if (vaildEmail)
			{
				user = await _userManager.FindByEmailAsync(dto.UserIdentifier);
				if (user is null)
				{
					resDto.Message = "There is no user with this information";
					return resDto;
				}
			}
			else
			{
				user = await _userManager.FindByNameAsync(dto.UserIdentifier);
				if (user is null)
				{
					resDto.Message = "There is no user with this information";
					return resDto;
				}
			}
			resDto.FirstName = user.FirstName;
			resDto.LastName = user.LastName;
			resDto.UserIdentifier = user.Email;
			return resDto;
		}


		//public async Task<bool> SendChangePasswordEmailAsync(string email)
		//{

		//}
	
		public async Task<string> ConfirmChangePasswordAsync(ResetPasswordDto dto)
		{
			var user = await _userManager.FindByIdAsync(dto.UserId);
			if (user is null)
				return $"Can't change password!";
			var result= await _userManager.ResetPasswordAsync(user,dto.Token,dto.Password);
			return (!result.Succeeded) ? String.Join("\n", result.Errors) : String.Empty;
		}





		private async Task<JwtSecurityToken> CreateJwtTokenAsync(ApplicationUser user)
		{
			var userClaims=await _userManager.GetClaimsAsync(user);
			var userRoles=await _userManager.GetRolesAsync(user);
			List<Claim> roleClaims = new();
			foreach (var roleClaim in userRoles)
				roleClaims.Add(new Claim("roles", roleClaim));
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email,user.Email),
				new Claim("userId",user.Id)
			}
			.Union(roleClaims)
			.Union(userClaims);
			SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
			SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

			var jwtSecurityToken = new JwtSecurityToken(
				issuer:_jwt.Issuer,
				audience:_jwt.Audience,
				expires:DateTime.Now.AddDays(_jwt.DurationInDays),
				claims:claims,
				signingCredentials:signingCredentials
			);

			return jwtSecurityToken;
		}



		private async Task<bool> AddEmployeeAsync(AddEmployeeDto dto)
		{
			var employeeRole = await _unitOfWork.EmployeeRegisterationCodes.GetByIdAsync<Guid>(new Guid(dto.RegistrationCode));
			if (employeeRole is not null)
			{
				var user =  _userManager.Users.FirstOrDefault(u => u.Id == dto.UserId);
				if (employeeRole.RoleName == Role.Mentor)
				{
					 await _userManager.AddToRoleAsync(user, employeeRole.RoleName);
					 await _unitOfWork.Mentors.AddAsync(new Mentor { UserId = dto.UserId });
					_unitOfWork.Complete();
				}
				else if (employeeRole.RoleName == Role.HeadOfCamp)
				{
					 await _userManager.AddToRoleAsync(user, employeeRole.RoleName);
					await _unitOfWork.HeadOfCamps.AddAsync(new HeadOfCamp { UserId= dto.UserId });
					_unitOfWork.Complete();
				}
				else
					await _userManager.AddToRoleAsync(user, employeeRole.RoleName);

				await _unitOfWork.EmployeeRegisterationCodes.DeleteAsync(employeeRole);
				_unitOfWork.Complete();
				return true;
			}
			return false;
		}

		


	}
}
