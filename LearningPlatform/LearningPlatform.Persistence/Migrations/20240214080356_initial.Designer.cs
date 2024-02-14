﻿// <auto-generated />
using System;
using LearningPlatform.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LearningPlatform.Persistence.Migrations
{
    [DbContext(typeof(LearningDbContext))]
    [Migration("20240214080356_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LearningPlatform.Persistence.Entities.CourseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("LearningPlatform.Persistence.Entities.LessonEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LessonText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VideoLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("LearningPlatform.Persistence.Entities.RolePermissionEntity", b =>
                {
                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int>("Permission")
                        .HasColumnType("integer");

                    b.HasKey("Role", "Permission");

                    b.HasIndex("Permission");

                    b.ToTable("RolePermissionEntity");

                    b.HasData(
                        new
                        {
                            Role = 1,
                            Permission = 2
                        },
                        new
                        {
                            Role = 1,
                            Permission = 1
                        },
                        new
                        {
                            Role = 1,
                            Permission = 3
                        },
                        new
                        {
                            Role = 1,
                            Permission = 4
                        },
                        new
                        {
                            Role = 2,
                            Permission = 1
                        });
                });

            modelBuilder.Entity("LearningPlatform.Persistence.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LearningPlatform.Persistence.PermissionEntity", b =>
                {
                    b.Property<int>("Permission")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Permission");

                    b.ToTable("PermissionEntity");

                    b.HasData(
                        new
                        {
                            Permission = 1,
                            Name = "Read"
                        },
                        new
                        {
                            Permission = 2,
                            Name = "Create"
                        },
                        new
                        {
                            Permission = 3,
                            Name = "Update"
                        },
                        new
                        {
                            Permission = 4,
                            Name = "Delete"
                        });
                });

            modelBuilder.Entity("LearningPlatform.Persistence.RoleEntity", b =>
                {
                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Role");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Role = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Role = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("RoleEntityUserEntity", b =>
                {
                    b.Property<int>("RolesRole")
                        .HasColumnType("integer");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("RolesRole", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleEntityUserEntity");
                });

            modelBuilder.Entity("LearningPlatform.Persistence.Entities.LessonEntity", b =>
                {
                    b.HasOne("LearningPlatform.Persistence.Entities.CourseEntity", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LearningPlatform.Persistence.Entities.RolePermissionEntity", b =>
                {
                    b.HasOne("LearningPlatform.Persistence.PermissionEntity", null)
                        .WithMany()
                        .HasForeignKey("Permission")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearningPlatform.Persistence.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleEntityUserEntity", b =>
                {
                    b.HasOne("LearningPlatform.Persistence.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("RolesRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearningPlatform.Persistence.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LearningPlatform.Persistence.Entities.CourseEntity", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
