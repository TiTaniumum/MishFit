﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MishFit;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MishFit.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240818174457_NewTrackersEntities")]
    partial class NewTrackersEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MishFit.Entities.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ActivityType")
                        .HasColumnType("integer");

                    b.Property<int>("Calories")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("MishFit.Entities.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Calories")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("MishFit.Entities.Tracker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ActivityId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ActivityId1")
                        .HasColumnType("uuid");

                    b.Property<int?>("ActivityRepetitions")
                        .HasColumnType("integer");

                    b.Property<int?>("ActivitySets")
                        .HasColumnType("integer");

                    b.Property<int?>("ActivityTimespan")
                        .HasColumnType("integer");

                    b.Property<int?>("ActivityType")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("MealGrams")
                        .HasColumnType("integer");

                    b.Property<Guid?>("MealId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("SleepBegin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("SleepEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("SleepQuality")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TrackerDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TrackerType")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId1");

                    b.HasIndex("MealId");

                    b.HasIndex("UserId");

                    b.ToTable("Trackers");
                });

            modelBuilder.Entity("MishFit.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal?>("Height")
                        .HasColumnType("numeric");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Sex")
                        .HasColumnType("integer");

                    b.Property<decimal?>("StepsGoal")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("WeightGoal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MishFit.Entities.Tracker", b =>
                {
                    b.HasOne("MishFit.Entities.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId1");

                    b.HasOne("MishFit.Entities.Meal", "Meal")
                        .WithMany()
                        .HasForeignKey("MealId");

                    b.HasOne("MishFit.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Meal");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
