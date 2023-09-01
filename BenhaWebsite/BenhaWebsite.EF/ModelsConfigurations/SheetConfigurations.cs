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
    internal class SheetConfigurations : IEntityTypeConfiguration<Sheet>
    {
        public void Configure(EntityTypeBuilder<Sheet> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(250);
            builder.HasMany(s=>s.traineeSheetAccesses).WithOne(tsa => tsa.Sheet).HasForeignKey(tsa=>tsa.sheetId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
