﻿// <auto-generated />
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

                    b.ToTable("Crops");
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

                    b.ToTable("Farmers");
                });

            modelBuilder.Entity("final_proj.Production", b =>
                {
                    b.Property<int>("fID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("cID")
                        .HasColumnType("INTEGER");

                    b.HasKey("fID", "cID");

                    b.HasIndex("cID");

                    b.ToTable("productions");
                });

            modelBuilder.Entity("final_proj.Production", b =>
                {
                    b.HasOne("final_proj.Crop", "Crop")
                        .WithMany("productions")
                        .HasForeignKey("cID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("final_proj.Farmer", "Farmer")
                        .WithMany("productions")
                        .HasForeignKey("fID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crop");

                    b.Navigation("Farmer");
                });

            modelBuilder.Entity("final_proj.Crop", b =>
                {
                    b.Navigation("productions");
                });

            modelBuilder.Entity("final_proj.Farmer", b =>
                {
                    b.Navigation("productions");
                });
#pragma warning restore 612, 618


        }
    }
}
