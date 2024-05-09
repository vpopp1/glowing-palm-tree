﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using final_proj;

#nullable disable

namespace glowing_palm_tree.Migrations
{
    [DbContext(typeof(CropDbContext))]
    partial class CropDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("final_proj.Crop", b =>
                {
                    b.Property<int>("cID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FarmerfID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<double>("avYeild")
                        .HasColumnType("REAL");

                    b.Property<string>("cNAme")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<int>("sun")
                        .HasColumnType("INTEGER");

                    b.Property<int>("temp")
                        .HasColumnType("INTEGER");

                    b.HasKey("cID");

                    b.HasIndex("FarmerfID");

                    b.ToTable("crops");
                });

            modelBuilder.Entity("final_proj.Farmer", b =>
                {
                    b.Property<int>("fID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CostpUnit")
                        .HasColumnType("REAL");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("avRain")
                        .HasColumnType("REAL");

                    b.Property<double>("avTemp")
                        .HasColumnType("REAL");

                    b.Property<string>("fName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("fID");

                    b.ToTable("farmers");
                });

            modelBuilder.Entity("final_proj.Crop", b =>
                {
                    b.HasOne("final_proj.Farmer", null)
                        .WithMany("crops")
                        .HasForeignKey("FarmerfID");
                });

            modelBuilder.Entity("final_proj.Farmer", b =>
                {
                    b.Navigation("crops");
                });
#pragma warning restore 612, 618
        }
    }
}
