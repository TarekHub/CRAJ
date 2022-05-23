﻿// <auto-generated />
using System;
using CRAJ.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRAJ.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220522191123_AddDocuementToDb")]
    partial class AddDocuementToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRAJ.Web.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("LieuCreation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LieuNaissance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomPersonne")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrenomPersonne")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Document");
                });
#pragma warning restore 612, 618
        }
    }
}
