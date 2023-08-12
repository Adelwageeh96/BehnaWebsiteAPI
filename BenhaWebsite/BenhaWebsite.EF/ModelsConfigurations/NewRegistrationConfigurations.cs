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
    internal class NewRegistrationConfigurations : IEntityTypeConfiguration<NewRegistration>
    {
        public void Configure(EntityTypeBuilder<NewRegistration> builder)
        {
            builder.HasKey(reg => reg.NationalID);
            builder.HasIndex(reg => reg.CodeForceHandle).IsUnique();
            builder.HasIndex(reg => reg.VjudgeHandle).IsUnique();
            builder.Property(reg => reg.NationalID).HasMaxLength(14);
        }
    }
}
