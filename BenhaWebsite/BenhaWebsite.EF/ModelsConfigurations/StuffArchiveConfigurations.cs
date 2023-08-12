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
    internal class StuffArchiveConfigurations : IEntityTypeConfiguration<StuffArchive>
    {
        public void Configure(EntityTypeBuilder<StuffArchive> builder)
        {
            builder.HasKey(s => s.NationalID);
            builder.Property(s => s.NationalID).HasMaxLength(14);
        }
    }
}
