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
    internal class TraineeSheetAccessConfigurations : IEntityTypeConfiguration<TraineeSheetAccess>
    {
        public void Configure(EntityTypeBuilder<TraineeSheetAccess> builder)
        {
            builder.HasKey(ts => new { ts.TraineeId, ts.sheetId });
            builder.HasOne(ts => ts.Trainee).WithMany(t => t.TraineeSheetAccesses).HasForeignKey(ts => ts.TraineeId);
            builder.HasOne(ts => ts.Sheet).WithMany(s => s.traineeSheetAccesses).HasForeignKey(ts => ts.sheetId);
        }
    }
}
