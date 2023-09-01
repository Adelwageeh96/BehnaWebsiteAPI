using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Dtos.AuthenticationDtos
{
	public class ConfirmEmailDto
	{
		public string UserId { get; set; }
		public string Token { get; set; }
	}
}
