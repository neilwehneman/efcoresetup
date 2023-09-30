﻿// <auto-generated />
using EntityFrameworkCoreSetup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkCoreSetup.Migrations
{
    [DbContext(typeof(PlaytimeContext))]
    [Migration("20230929201309_ChangeManufacturerId")]
    partial class ChangeManufacturerId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("EntityFramewokCoreSetup.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("EntityFramewokCoreSetup.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("EntityFramewokCoreSetup.Toy", b =>
                {
                    b.Property<int>("ToyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PriceInWholeDollars")
                        .HasColumnType("INTEGER");

                    b.HasKey("ToyId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Toys");
                });

            modelBuilder.Entity("PlayerToy", b =>
                {
                    b.Property<int>("PlayersPlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ToysToyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayersPlayerId", "ToysToyId");

                    b.HasIndex("ToysToyId");

                    b.ToTable("PlayerToy");
                });

            modelBuilder.Entity("EntityFramewokCoreSetup.Toy", b =>
                {
                    b.HasOne("EntityFramewokCoreSetup.Manufacturer", "Manufacturer")
                        .WithMany("Toys")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("PlayerToy", b =>
                {
                    b.HasOne("EntityFramewokCoreSetup.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramewokCoreSetup.Toy", null)
                        .WithMany()
                        .HasForeignKey("ToysToyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFramewokCoreSetup.Manufacturer", b =>
                {
                    b.Navigation("Toys");
                });
#pragma warning restore 612, 618
        }
    }
}