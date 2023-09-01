using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Dtos.AuthenticationDtos
{
	public class ContestRequestDto
	{
		public string ContestId { get; set; }
		public string ApiKey { get; set; }
		public string Secret { get; set; }
	}
}
