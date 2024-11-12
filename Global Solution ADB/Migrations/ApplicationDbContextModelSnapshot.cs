﻿// <auto-generated />
using System;
using Global_Solution_ADB.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Global_Solution_ADB.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Global_Solution_ADB.Models.Entities.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<bool>("IsResolved")
                        .HasColumnType("NUMBER(1)");

                    b.Property<int>("Level")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime?>("ResolvedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("SensorId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("TriggeredAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.ToTable("GlobalEnergy_Alert");
                });

            modelBuilder.Entity("Global_Solution_ADB.Models.Entities.Analysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("SensorId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("Unit")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<double>("Value")
                        .HasColumnType("BINARY_DOUBLE");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.ToTable("GlobalEnergy_Analysis");
                });

            modelBuilder.Entity("Global_Solution_ADB.Models.Entities.Metric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<double>("ElectricityProvided")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<double>("NuclearParticipation")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<DateTime>("NuclearPlantDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("NuclearPlantId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<double>("OperationalEfficiency")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.HasIndex("NuclearPlantId");

                    b.ToTable("GlobalEnergy_Metric");
                });

            modelBuilder.Entity("Global_Solution_ADB.Models.Entities.NuclearPlant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<float>("FullCapacity")
                        .HasColumnType("BINARY_FLOAT");

                    b.Property<string>("Localization")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<int>("NumberOfReactors")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.ToTable("GlobalEnergy_NuclearPlant");
                });

            modelBuilder.Entity("Global_Solution_ADB.Models.Entities.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<int>("Type")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.ToTable("GlobalEnergy_Sensor");
                });

            modelBuilder.Entity("Global_Solution_ADB.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("LastLoginAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Role")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.ToTable("GlobalEnergy_User");
                });

            modelBuilder.Entity("Global_Solution_ADB.Models.Entities.Alert", b =>
                {
                    b.HasOne("Global_Solution_ADB.Models.Entities.Sensor", "Sensor")
                        .WithMany()
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("Global_Solution_ADB.Models.Entities.Analysis", b =>
                {
                    b.HasOne("Global_Solution_ADB.Models.Entities.Sensor", "Sensor")
                        .WithMany()
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("Global_Solution_ADB.Models.Entities.Metric", b =>
                {
                    b.HasOne("Global_Solution_ADB.Models.Entities.NuclearPlant", "NuclearPlant")
                        .WithMany()
                        .HasForeignKey("NuclearPlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NuclearPlant");
                });
#pragma warning restore 612, 618
        }
    }
}
