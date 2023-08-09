using BenhaWebsite.Core.Models;
using BenhaWebsite.EF.ModelsConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.EF.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Accounts");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            new ApplicationUserConfigurations().Configure(builder.Entity<ApplicationUser>());
            new MaterialConfigurations().Configure(builder.Entity<Material>());
            new TraineeConfigurations().Configure(builder.Entity<Trainee>());
            new TraineeSheetAccessConfigurations().Configure(builder.Entity<TraineeSheetAccess>());
            new SheetConfigurations().Configure(builder.Entity<Sheet>());
            new SessionConfigurations().Configure(builder.Entity<Session>());
            new CampConfigurations().Configure(builder.Entity<Camp>());
            new MentorConfigurations().Configure(builder.Entity<Mentor>());
            new MentorAttendenceConfigurations().Configure(builder.Entity<MentorAttendence>());
            new MentorOfCmapConfigurations().Configure(builder.Entity<MentorOfCmap>());
            new SessionFeedbackConfigurations().Configure(builder.Entity<SessionFeedback>());
            new TraineesAttendenceConfigurations().Configure(builder.Entity<TraineesAttendence>());
            
        }
    }
}
