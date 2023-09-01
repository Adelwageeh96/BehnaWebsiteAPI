using BenhaWebsite.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.EF.ModelsConfigurations
{
    internal class CampConfigurations : IEntityTypeConfiguration<Camp>
    {
        public void Configure(EntityTypeBuilder<Camp> builder)
        {
            builder.Property(c=>c.Name).HasMaxLength(100);
            builder.HasMany(c => c.Trainees).WithOne(t => t.Camp).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Sessions).WithOne(s => s.Camp).OnDelete(DeleteBehavior.Cascade);
			builder.HasMany(c => c.MentorOfCmaps).WithOne(m => m.Camp).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c=>c.Sheets).WithOne(s=>s.Camp).OnDelete(DeleteBehavior.SetNull);

		}
	}
}
