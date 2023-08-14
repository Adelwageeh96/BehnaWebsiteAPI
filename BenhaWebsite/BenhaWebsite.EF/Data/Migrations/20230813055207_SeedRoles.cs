using BenhaWebsite.Core.Helpers.Constants;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenhaWebsite.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] {"Id","Name", "NormalizedName", "ConcurrencyStamp" } ,
                values: new object[] {Guid.NewGuid().ToString(),Role.Trainee,Role.Trainee.ToUpper(),Guid.NewGuid().ToString()} 
           );
			migrationBuilder.InsertData(
			   table: "Roles",
			   columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
			   values: new object[] { Guid.NewGuid().ToString(), Role.Mentor, Role.Mentor.ToUpper(), Guid.NewGuid().ToString() }
		  );
			migrationBuilder.InsertData(
			   table: "Roles",
			   columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
			   values: new object[] { Guid.NewGuid().ToString(), Role.HeadOfCamp, Role.HeadOfCamp.ToUpper(), Guid.NewGuid().ToString() }
		  );
			migrationBuilder.InsertData(
			   table: "Roles",
			   columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
			   values: new object[] { Guid.NewGuid().ToString(), Role.Leader, Role.Leader.ToUpper(), Guid.NewGuid().ToString() }
		  );
		    migrationBuilder.InsertData(
			   table: "Roles",
			   columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
			   values: new object[] { Guid.NewGuid().ToString(), Role.User, Role.User.ToUpper(), Guid.NewGuid().ToString() }
		  );
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("Delete from [Roles] ");
        }
    }
}
