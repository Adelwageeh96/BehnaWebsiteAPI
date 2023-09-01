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
	internal class TraineeConfigurations : IEntityTypeConfiguration<Trainee>
	{
		public void Configure(EntityTypeBuilder<Trainee> builder)
		{
			builder.HasOne(t => t.Mentor).WithMany(m => m.Trainees).HasForeignKey(t => t.MentorId);
			builder.HasMany(t => t.TraineesAttendences).WithOne(ta => ta.Trainee).HasForeignKey(ta => ta.TraineeId).OnDelete(DeleteBehavior.Cascade);
			builder.HasMany(t => t.TraineeSheetAccesses).WithOne(ta => ta.Trainee).HasForeignKey(ta => ta.TraineeId).OnDelete(DeleteBehavior.Cascade);
			builder.HasMany(t => t.SessionFeedbacks).WithOne(ta => ta.Trainee).HasForeignKey(ta => ta.TraineeId).OnDelete(DeleteBehavior.Cascade);
		}
	}
}