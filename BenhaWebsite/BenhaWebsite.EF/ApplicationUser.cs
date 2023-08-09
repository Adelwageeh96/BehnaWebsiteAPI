using BenhaWebsite.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.EF
{
    public enum Gender
    {
        Male,
        Female
    }
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }
        public byte Grade { get; set; }
        public string College { get; set; }
        public DateTime JoinDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime LastLoginDate { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string CodeforceHandle { get; set;}
        public string? FacebookLink { get;}
        public string? VjudgeHandle { get; set; }
        public Mentor Mentor { get; set; }
        public Trainee Trainee { get; set; }


    }
}
