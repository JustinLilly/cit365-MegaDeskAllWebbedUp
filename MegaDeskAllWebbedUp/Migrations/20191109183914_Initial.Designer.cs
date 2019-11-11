﻿// <auto-generated />
using System;
using MegaDeskAllWebbedUp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MegaDeskAllWebbedUp.Migrations
{
    [DbContext(typeof(MegaDeskAllWebbedUpContext))]
    [Migration("20191109183914_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MegaDeskAllWebbedUp.Models.Quote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeskDepth")
                        .HasColumnType("int");

                    b.Property<int>("DeskWidth")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfDrawers")
                        .HasColumnType("int");

                    b.Property<int>("QuotePrice")
                        .HasColumnType("int");

                    b.Property<int>("RushDays")
                        .HasColumnType("int");

                    b.Property<int>("SurfaceMaterial")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Quote");
                });
#pragma warning restore 612, 618
        }
    }
}