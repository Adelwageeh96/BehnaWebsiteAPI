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
    internal class SessionFeedbackConfigurations : IEntityTypeConfiguration<SessionFeedback>
    {
        public void Configure(EntityTypeBuilder<SessionFeedback> builder)
        {
            builder.Property(sf=>sf.Feedback).HasMaxLength(500);
            builder.HasKey(sf => new {sf.TraineeId,sf.SessionId});
            builder.HasOne(t=>t.Trainee).WithMany(sf=>sf.SessionFeedbacks).HasForeignKey(sf=>sf.TraineeId);
            builder.HasOne(s => s.Session).WithMany(sf => sf.SessionFeedbacks).HasForeignKey(sf => sf.SessionId);
        }
    }
}
