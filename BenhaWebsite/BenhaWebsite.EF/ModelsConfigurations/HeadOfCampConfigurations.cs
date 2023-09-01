using BenhaWebsite.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BenhaWebsite.EF.ModelsConfigurations
{
	internal class HeadOfCampConfigurations : IEntityTypeConfiguration<HeadOfCamp>
	{
		public void Configure(EntityTypeBuilder<HeadOfCamp> builder)
		{
			builder.HasMany(c => c.Camps).WithOne(h => h.HeadOfCamp).HasForeignKey(c => c.HeadOfCampId).OnDelete(DeleteBehavior.SetNull);
		}
	}
}
