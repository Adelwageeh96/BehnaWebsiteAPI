using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Dtos.AuthenticationDtos
{
	public class TokenRequestDto
	{
		public string UserIdentifier { get; set; }
		public string Password { get; set; }
	}
}
