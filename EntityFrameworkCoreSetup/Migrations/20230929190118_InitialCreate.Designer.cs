﻿// <auto-generated />
using System;
using EntityFrameworkCoreSetup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkCoreSetup.Migrations
{
    [DbContext(typeof(PlaytimeContext))]
    [Migration("20230929190118_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

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

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PriceInWholeDollars")
                        .HasColumnType("INTEGER");

                    b.HasKey("ToyId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Toys");
                });

            modelBuilder.Entity("EntityFramewokCoreSetup.Toy", b =>
                {
                    b.HasOne("EntityFramewokCoreSetup.Player", null)
                        .WithMany("Toys")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("EntityFramewokCoreSetup.Player", b =>
                {
                    b.Navigation("Toys");
                });
#pragma warning restore 612, 618
        }
    }
}
