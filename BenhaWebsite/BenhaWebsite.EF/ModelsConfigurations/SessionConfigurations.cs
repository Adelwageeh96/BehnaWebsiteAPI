﻿using BenhaWebsite.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.EF.ModelsConfigurations
{
    internal class SessionConfigurations : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(s => s.Topic).HasMaxLength(100);
            builder.Property(s=>s.InstructorName).HasMaxLength(50);
            builder.Property(s => s.LocationName).HasMaxLength(100);
            builder.Property(s => s.LocationLink).HasMaxLength(200);
            builder.HasMany(s => s.SessionFeedbacks).WithOne(sf => sf.Session).HasForeignKey(sf => sf.SessionId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(s => s.MentorAttendences).WithOne(sf => sf.Session).HasForeignKey(sf => sf.SessionId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(s => s.TraineesAttendences).WithOne(sf => sf.Session).HasForeignKey(sf => sf.SessionId).OnDelete(DeleteBehavior.Cascade);


		}
    }
}
