﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationNefc;

namespace WebApplicationNefc.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20231021190157_initial migration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebApplicationNefc.Models.Color", b =>
                {
                    b.Property<int>("ColorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("VehicleRegNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("ColorID");

                    b.HasIndex("VehicleRegNo");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("WebApplicationNefc.Models.Vehicle", b =>
                {
                    b.Property<string>("RegNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(12)");

                    b.Property<bool>("IsSingleColor")
                        .HasColumnType("bit");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NumSeats")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("RegNo");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("WebApplicationNefc.Models.Color", b =>
                {
                    b.HasOne("WebApplicationNefc.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleRegNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
