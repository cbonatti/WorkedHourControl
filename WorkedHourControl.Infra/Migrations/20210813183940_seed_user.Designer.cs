﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkedHourControl.Infra.Data;

namespace WorkedHourControl.Infra.Migrations
{
    [DbContext(typeof(WorkedHourContext))]
    [Migration("20210813183940_seed_user")]
    partial class seed_user
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("WorkedHourControl.Domain.Entities.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Profile")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Gestor",
                            Profile = 1
                        });
                });

            modelBuilder.Entity("WorkedHourControl.Domain.Entities.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("WorkedHourControl.Domain.Entities.ProjectTeam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TeamId");

                    b.ToTable("ProjectTeam");
                });

            modelBuilder.Entity("WorkedHourControl.Domain.Entities.ProjectWorkedHour", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TimeSpent")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectWorkedHour");
                });

            modelBuilder.Entity("WorkedHourControl.Domain.Entities.Team", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("WorkedHourControl.Domain.Entities.TeamEmployee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamEmployee");
                });

            modelBuilder.Entity("WorkedHourControl.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            EmployeeId = 1L,
                            Password = "123Mudar",
                            Username = "gestor"
                        });
                });

            modelBuilder.Entity("WorkedHourControl.Domain.Entities.ProjectTeam", b =>
                {
                    b.HasOne("WorkedHourControl.Domain.Entities.Project", "Project")
                        .WithMany("Teams")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkedHourControl.Domain.Entities.Team", "Team")
                        .WithMany("Projects")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkedHourControl.Domain.Entities.ProjectWorkedHour", b =>
                {
                    b.HasOne("WorkedHourControl.Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkedHourControl.Domain.Entities.Project", "Project")
                        .WithMany("WorkedHours")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkedHourControl.Domain.Entities.TeamEmployee", b =>
                {
                    b.HasOne("WorkedHourControl.Domain.Entities.Employee", "Employee")
                        .WithMany("Teams")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkedHourControl.Domain.Entities.Team", "Team")
                        .WithMany("Employees")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkedHourControl.Domain.Entities.User", b =>
                {
                    b.HasOne("WorkedHourControl.Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}