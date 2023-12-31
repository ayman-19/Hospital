﻿// <auto-generated />
using System;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StratTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Stutas")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("Domain.Models.Diagonse", b =>
                {
                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AppointmentId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Diagonse");
                });

            modelBuilder.Entity("Domain.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Domain.Models.DoctorsHaveSchedules", b =>
                {
                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.HasKey("ScheduleId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("DoctorsHaveSchedules");
                });

            modelBuilder.Entity("Domain.Models.DoctorsViewHistory", b =>
                {
                    b.Property<int>("MedicalHistoryId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.HasKey("MedicalHistoryId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("DoctorsViewHistory");
                });

            modelBuilder.Entity("Domain.Models.MedicalHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Medication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Stutas")
                        .HasColumnType("bit");

                    b.Property<string>("Surgeries")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MedicalHistory");
                });

            modelBuilder.Entity("Domain.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Domain.Models.PatientFillHistory", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("MedicalHistoryId")
                        .HasColumnType("int");

                    b.HasKey("PatientId", "MedicalHistoryId");

                    b.HasIndex("MedicalHistoryId");

                    b.ToTable("PatientFillHistory");
                });

            modelBuilder.Entity("Domain.Models.PatientsAttendAppointments", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("Symptoms")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId", "AppointmentId");

                    b.HasIndex("AppointmentId");

                    b.ToTable("PatientsAttendAppointments");
                });

            modelBuilder.Entity("Domain.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BreakTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", (string)null);
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

                    b.ToTable("AspNetRoles", (string)null);
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

                    b.ToTable("AspNetRoleClaims", (string)null);
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

                    b.ToTable("AspNetUserClaims", (string)null);
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

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Diagonse", b =>
                {
                    b.HasOne("Domain.Models.Appointment", "Appointment")
                        .WithMany("Diagonses")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Doctor", "Doctors")
                        .WithMany("Diagonses")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Domain.Models.Doctor", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithOne("Doctor")
                        .HasForeignKey("Domain.Models.Doctor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.DoctorsHaveSchedules", b =>
                {
                    b.HasOne("Domain.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Schedule", "Schedule")
                        .WithMany("DoctorsHaveSchedules")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Domain.Models.DoctorsViewHistory", b =>
                {
                    b.HasOne("Domain.Models.Doctor", "Doctor")
                        .WithMany("DoctorsViewHistories")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.MedicalHistory", "MedicalHistory")
                        .WithMany("DoctorsViewHistories")
                        .HasForeignKey("MedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("MedicalHistory");
                });

            modelBuilder.Entity("Domain.Models.Patient", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithOne("Patient")
                        .HasForeignKey("Domain.Models.Patient", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.PatientFillHistory", b =>
                {
                    b.HasOne("Domain.Models.MedicalHistory", "MedicalHistory")
                        .WithMany("PatientFillHistories")
                        .HasForeignKey("MedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Patient", "Patient")
                        .WithMany("PatientFillHistories")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalHistory");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Models.PatientsAttendAppointments", b =>
                {
                    b.HasOne("Domain.Models.Appointment", "Appointment")
                        .WithMany("PatientsAttendAppointments")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Patient", "Patient")
                        .WithMany("PatientsAttendAppointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.OwnsMany("Domain.Models.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<string>("UserId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("AccessToken")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("AccessTokenExpiration")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("CreateOn")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("ExpireOn")
                                .HasColumnType("datetime2");

                            b1.Property<string>("RefreshJwtToken")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("RevokeOn")
                                .HasColumnType("datetime2");

                            b1.HasKey("UserId", "Id");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("RefreshTokens");
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
                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Models.User", null)
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

                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Appointment", b =>
                {
                    b.Navigation("Diagonses");

                    b.Navigation("PatientsAttendAppointments");
                });

            modelBuilder.Entity("Domain.Models.Doctor", b =>
                {
                    b.Navigation("Diagonses");

                    b.Navigation("DoctorsViewHistories");
                });

            modelBuilder.Entity("Domain.Models.MedicalHistory", b =>
                {
                    b.Navigation("DoctorsViewHistories");

                    b.Navigation("PatientFillHistories");
                });

            modelBuilder.Entity("Domain.Models.Patient", b =>
                {
                    b.Navigation("PatientFillHistories");

                    b.Navigation("PatientsAttendAppointments");
                });

            modelBuilder.Entity("Domain.Models.Schedule", b =>
                {
                    b.Navigation("DoctorsHaveSchedules");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("Doctor")
                        .IsRequired();

                    b.Navigation("Patient")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
