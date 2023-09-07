﻿// <auto-generated />
using System;
using BenhaWebsite.EF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BenhaWebsite.EF.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230906061547_EditCampTable")]
    partial class EditCampTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BenhaWebsite.Core.Models.Camp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationInWeeks")
                        .HasColumnType("int");

                    b.Property<int?>("HeadOfCampId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("HeadOfCampId");

                    b.ToTable("Camps");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.EmployeeRegisterationCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeRegisterations");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.HeadOfCamp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("HeadOfCamp");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("SheetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SheetId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Mentor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Mentors");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.MentorAttendence", b =>
                {
                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("MentorId")
                        .HasColumnType("int");

                    b.HasKey("SessionId", "MentorId");

                    b.HasIndex("MentorId");

                    b.ToTable("MentorsAttendences");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.MentorOfCmap", b =>
                {
                    b.Property<int>("MentorId")
                        .HasColumnType("int");

                    b.Property<int>("CampId")
                        .HasColumnType("int");

                    b.HasKey("MentorId", "CampId");

                    b.HasIndex("CampId");

                    b.ToTable("MentorsOfCamps");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CampId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstructorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LocationLink")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CampId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.SessionFeedback", b =>
                {
                    b.Property<int>("TraineeId")
                        .HasColumnType("int");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("TraineeId", "SessionId");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionsFeedbacks");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Sheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CampId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("NumberOfProblems")
                        .HasColumnType("int");

                    b.Property<int>("SheetOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampId");

                    b.ToTable("Sheets");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CampId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastSubmession")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MentorId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("TotalSolvedProblems")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CampId");

                    b.HasIndex("MentorId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.TraineeSheetAccess", b =>
                {
                    b.Property<int>("TraineeId")
                        .HasColumnType("int");

                    b.Property<int>("sheetId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfProblems")
                        .HasColumnType("int");

                    b.HasKey("TraineeId", "sheetId");

                    b.HasIndex("sheetId");

                    b.ToTable("TraineesSheetsAccess");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.TraineesAttendence", b =>
                {
                    b.Property<int>("TraineeId")
                        .HasColumnType("int");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("TraineeId", "SessionId");

                    b.HasIndex("SessionId");

                    b.ToTable("TraineesAttednces");
                });

            modelBuilder.Entity("BenhaWebsite.EF.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CodeforceHandle")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FacebookLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .IsFixedLength();

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CodeforceHandle")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.ToTable("Accounts", null, t =>
                        {
                            t.HasCheckConstraint("CK_Gender", "Gender in ('Male','Female')");
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Camp", b =>
                {
                    b.HasOne("BenhaWebsite.Core.Models.HeadOfCamp", "HeadOfCamp")
                        .WithMany("Camps")
                        .HasForeignKey("HeadOfCampId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("HeadOfCamp");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.HeadOfCamp", b =>
                {
                    b.HasOne("BenhaWebsite.EF.ApplicationUser", null)
                        .WithOne("HeadOfCamp")
                        .HasForeignKey("BenhaWebsite.Core.Models.HeadOfCamp", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Material", b =>
                {
                    b.HasOne("BenhaWebsite.Core.Models.Sheet", "Sheet")
                        .WithMany("Materials")
                        .HasForeignKey("SheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sheet");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Mentor", b =>
                {
                    b.HasOne("BenhaWebsite.EF.ApplicationUser", null)
                        .WithOne("Mentor")
                        .HasForeignKey("BenhaWebsite.Core.Models.Mentor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.MentorAttendence", b =>
                {
                    b.HasOne("BenhaWebsite.Core.Models.Mentor", "Mentor")
                        .WithMany("MentorAttendences")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BenhaWebsite.Core.Models.Session", "Session")
                        .WithMany("MentorAttendences")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mentor");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.MentorOfCmap", b =>
                {
                    b.HasOne("BenhaWebsite.Core.Models.Camp", "Camp")
                        .WithMany("MentorOfCmaps")
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BenhaWebsite.Core.Models.Mentor", "Mentor")
                        .WithMany("MentorOfCmaps")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Session", b =>
                {
                    b.HasOne("BenhaWebsite.Core.Models.Camp", "Camp")
                        .WithMany("Sessions")
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.SessionFeedback", b =>
                {
                    b.HasOne("BenhaWebsite.Core.Models.Session", "Session")
                        .WithMany("SessionFeedbacks")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BenhaWebsite.Core.Models.Trainee", "Trainee")
                        .WithMany("SessionFeedbacks")
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Sheet", b =>
                {
                    b.HasOne("BenhaWebsite.Core.Models.Camp", "Camp")
                        .WithMany("Sheets")
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Camp");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Trainee", b =>
                {
                    b.HasOne("BenhaWebsite.Core.Models.Camp", "Camp")
                        .WithMany("Trainees")
                        .HasForeignKey("CampId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BenhaWebsite.Core.Models.Mentor", "Mentor")
                        .WithMany("Trainees")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("BenhaWebsite.EF.ApplicationUser", null)
                        .WithOne("Trainee")
                        .HasForeignKey("BenhaWebsite.Core.Models.Trainee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camp");

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.TraineeSheetAccess", b =>
                {
                    b.HasOne("BenhaWebsite.Core.Models.Trainee", "Trainee")
                        .WithMany("TraineeSheetAccesses")
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BenhaWebsite.Core.Models.Sheet", "Sheet")
                        .WithMany("traineeSheetAccesses")
                        .HasForeignKey("sheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sheet");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.TraineesAttendence", b =>
                {
                    b.HasOne("BenhaWebsite.Core.Models.Session", "Session")
                        .WithMany("TraineesAttendences")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BenhaWebsite.Core.Models.Trainee", "Trainee")
                        .WithMany("TraineesAttendences")
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BenhaWebsite.EF.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BenhaWebsite.EF.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BenhaWebsite.EF.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BenhaWebsite.EF.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Camp", b =>
                {
                    b.Navigation("MentorOfCmaps");

                    b.Navigation("Sessions");

                    b.Navigation("Sheets");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.HeadOfCamp", b =>
                {
                    b.Navigation("Camps");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Mentor", b =>
                {
                    b.Navigation("MentorAttendences");

                    b.Navigation("MentorOfCmaps");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Session", b =>
                {
                    b.Navigation("MentorAttendences");

                    b.Navigation("SessionFeedbacks");

                    b.Navigation("TraineesAttendences");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Sheet", b =>
                {
                    b.Navigation("Materials");

                    b.Navigation("traineeSheetAccesses");
                });

            modelBuilder.Entity("BenhaWebsite.Core.Models.Trainee", b =>
                {
                    b.Navigation("SessionFeedbacks");

                    b.Navigation("TraineeSheetAccesses");

                    b.Navigation("TraineesAttendences");
                });

            modelBuilder.Entity("BenhaWebsite.EF.ApplicationUser", b =>
                {
                    b.Navigation("HeadOfCamp")
                        .IsRequired();

                    b.Navigation("Mentor")
                        .IsRequired();

                    b.Navigation("Trainee")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
