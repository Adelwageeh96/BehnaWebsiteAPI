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
    internal class MentorOfCmapConfigurations : IEntityTypeConfiguration<MentorOfCmap>
    {
        public void Configure(EntityTypeBuilder<MentorOfCmap> builder)
        {
            builder.HasKey(moc => new { moc.MentorId, moc.CampId });
            builder.HasOne(m => m.Mentor).WithMany(moc => moc.MentorOfCmaps).HasForeignKey(moc => moc.MentorId);
            builder.HasOne(c => c.Camp).WithMany(moc => moc.MentorOfCmaps).HasForeignKey(moc => moc.CampId);
        }
    }
}
