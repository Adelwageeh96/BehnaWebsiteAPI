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
    internal class TraineesAttendenceConfigurations : IEntityTypeConfiguration<TraineesAttendence>
    {
        public void Configure(EntityTypeBuilder<TraineesAttendence> builder)
        {
            builder.HasKey(ta => new { ta.TraineeId, ta.SessionId });
            builder.HasOne(t=>t.Trainee).WithMany(ta=>ta.TraineesAttendences).HasForeignKey(ta => ta.TraineeId);
            builder.HasOne(s => s.Session).WithMany(ta => ta.TraineesAttendences).HasForeignKey(ta => ta.SessionId);
        }
    }
}
