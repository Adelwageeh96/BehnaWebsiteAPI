using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Dtos.AuthenticationDtos
{
	public class ForgetPasswordDto
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set;}
		public string UserIdentifier { get; set; }
		public string? Message { get; set; }
	}
}
