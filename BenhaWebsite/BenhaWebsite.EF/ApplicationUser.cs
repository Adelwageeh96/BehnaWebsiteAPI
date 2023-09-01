using BenhaWebsite.Core.Helpers.Constants;
using BenhaWebsite.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.EF
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
		public string Gender { get; set; }
		public byte[]? ProfilePicture { get; set; }
        public string CodeforceHandle { get; set;}
        public string? FacebookLink { get; set; }
        public Mentor Mentor { get; set; }
        public Trainee Trainee { get; set; }
        public HeadOfCamp HeadOfCamp { get; set; }

    }
}
