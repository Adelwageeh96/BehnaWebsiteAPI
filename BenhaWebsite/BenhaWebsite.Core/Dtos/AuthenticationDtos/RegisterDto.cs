using BenhaWebsite.Core.Helpers.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Dtos.AuthenticationDtos
{
	public class RegisterDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string NationalId { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
		public string PhoneNumber { get; set; }

		public DateTime BirthDate { get; set; }

		public byte Grade { get; set; }
		public string College { get; set; }

		public string Gender { get; set; }
		public IFormFile ProfilePicture { get; set; }
		public string CodeforceHandle { get; set; }
		public string? FacebookLink { get; }
		public string? VjudgeHandle { get; set; }
		public string? EmployeeRegistrationCode { get; set; }
	}
}
