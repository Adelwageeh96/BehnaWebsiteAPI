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
    internal class MentorAttendenceConfigurations : IEntityTypeConfiguration<MentorAttendence>
    {
        public void Configure(EntityTypeBuilder<MentorAttendence> builder)
        {
            builder.HasKey(ma => new { ma.SessionId, ma.MentorId });
            builder.HasOne(m=>m.Mentor).WithMany(ma=>ma.mentorAttendences).HasForeignKey(ma=>ma.MentorId);
            builder.HasOne(s => s.Session).WithMany(ma => ma.MentorAttendences).HasForeignKey(ma => ma.SessionId);
        }
    }
}
