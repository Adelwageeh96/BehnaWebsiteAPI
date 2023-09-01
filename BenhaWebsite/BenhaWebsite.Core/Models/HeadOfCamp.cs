using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.Core.Models
{
	public class HeadOfCamp
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public IEnumerable<Camp>? Camps { get;set; }
	}
}
