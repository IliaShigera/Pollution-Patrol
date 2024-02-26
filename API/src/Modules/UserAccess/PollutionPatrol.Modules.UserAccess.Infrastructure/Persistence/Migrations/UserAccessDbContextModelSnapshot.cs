﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence;

#nullable disable

namespace PollutionPatrol.Modules.UserAccess.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(UserAccessDbContext))]
    partial class UserAccessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PollutionPatrol.BuildingBlocks.Domain.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Entity");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg.Registration", b =>
                {
                    b.HasBaseType("PollutionPatrol.BuildingBlocks.Domain.Entity");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("The user's email address");

                    b.Property<DateTime>("ExpiresOn")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("The date and time the registration or verification code will expire");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("The securely hashed password of the user");

                    b.Property<DateTime>("RegisteredOn")
                        .HasColumnType("timestamp with time zone")
                        .HasComment("The date and time the user registered");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("The user's name");

                    b.Property<string>("VerificationCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasComment("A unique code used for email verification purposes");

                    b.Property<DateTime?>("VerifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasIndex("VerificationCode")
                        .IsUnique();

                    b.ToTable("Registrations", (string)null);
                });

            modelBuilder.Entity("PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg.Registration", b =>
                {
                    b.HasOne("PollutionPatrol.BuildingBlocks.Domain.Entity", null)
                        .WithOne()
                        .HasForeignKey("PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg.Registration", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("PollutionPatrol.Modules.UserAccess.Domain.Aggregates.Reg.RegistrationStatus", "Status", b1 =>
                        {
                            b1.Property<Guid>("RegistrationId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Status")
                                .HasComment("The current status of the registration (e.g., pending, verified, expired)");

                            b1.HasKey("RegistrationId");

                            b1.ToTable("Registrations");

                            b1.WithOwner()
                                .HasForeignKey("RegistrationId");
                        });

                    b.Navigation("Status")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
