﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VMS.Client.DbModels;

namespace VMS.Model.Migrations
{
    [DbContext(typeof(VMSContext))]
    partial class VMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VMS.Client.DbModels.Van", b =>
                {
                    b.Property<Guid>("VanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Colour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EnteredSystemDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("MotExpriryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VanId");

                    b.ToTable("Vans");
                });
#pragma warning restore 612, 618
        }
    }
}
