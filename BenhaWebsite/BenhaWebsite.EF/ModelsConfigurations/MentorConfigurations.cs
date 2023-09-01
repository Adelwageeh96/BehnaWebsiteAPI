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
    internal class MentorConfigurations : IEntityTypeConfiguration<Mentor>
    {
        public void Configure(EntityTypeBuilder<Mentor> builder)
		{
            builder.HasMany(m => m.Trainees).WithOne(t => t.Mentor).HasForeignKey(t => t.MentorId).OnDelete(DeleteBehavior.NoAction);
			builder.HasMany(m => m.MentorAttendences).WithOne(ma => ma.Mentor).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.MentorOfCmaps).WithOne(mc => mc.Mentor).OnDelete(DeleteBehavior.Cascade);

		}
	}
}
