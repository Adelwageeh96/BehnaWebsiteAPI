using BenhaWebsite.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.EF.ModelsConfigurations
{
    internal class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasIndex(u=>u.NationalId).IsUnique();
            builder.HasIndex(u=>u.CodeforceHandle).IsUnique();
            builder.HasIndex(u=>u.Email).IsUnique();
            builder.HasIndex(u=>u.VjudgeHandle).IsUnique();
            builder.HasIndex(u=>u.PhoneNumber).IsUnique();
            builder.Property(u => u.FirstName).HasMaxLength(50);
            builder.Property(u => u.LastName).HasMaxLength(50);
            builder.Property(u => u.College).HasMaxLength(50);
            builder.HasOne(c => c.Trainee).WithOne().HasForeignKey<Trainee>(t => t.UserId);
            builder.HasOne(c => c.Mentor).WithOne().HasForeignKey<Mentor>(m => m.UserId);
        }
    }
}
