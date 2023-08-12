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
    internal class TraineeArchiveConfigurations : IEntityTypeConfiguration<TraineeArchive>
    {
        public void Configure(EntityTypeBuilder<TraineeArchive> builder)
        {
            builder.HasKey(t => t.NationalID);
            builder.Property(t => t.NationalID).HasMaxLength(14);
        }
    }
}
