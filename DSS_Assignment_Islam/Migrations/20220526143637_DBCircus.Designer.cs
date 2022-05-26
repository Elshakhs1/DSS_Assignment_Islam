﻿// <auto-generated />
using DSS_Assignment_Islam.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DSS_Assignment_Islam.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20220526143637_DBCircus")]
    partial class DBCircus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DSS_Assignment_Islam.Models.Act", b =>
                {
                    b.Property<int>("ActID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActID"), 1L, 1);

                    b.Property<int>("ActorID")
                        .HasColumnType("int");

                    b.Property<int>("TrickID")
                        .HasColumnType("int");

                    b.HasKey("ActID");

                    b.HasIndex("ActorID");

                    b.HasIndex("TrickID");

                    b.ToTable("Acts");
                });

            modelBuilder.Entity("DSS_Assignment_Islam.Models.Actor", b =>
                {
                    b.Property<int>("ActorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActorID"), 1L, 1);

                    b.Property<string>("ActorAge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActorSpacielity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CircusID")
                        .HasColumnType("int");

                    b.HasKey("ActorID");

                    b.HasIndex("CircusID");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("DSS_Assignment_Islam.Models.Circus", b =>
                {
                    b.Property<int>("CircusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CircusID"), 1L, 1);

                    b.Property<string>("CircusLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CircusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CircusID");

                    b.ToTable("Circuses");
                });

            modelBuilder.Entity("DSS_Assignment_Islam.Models.Trick", b =>
                {
                    b.Property<int>("TrickID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrickID"), 1L, 1);

                    b.Property<string>("TrickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrickID");

                    b.ToTable("Tricks");
                });

            modelBuilder.Entity("DSS_Assignment_Islam.Models.Act", b =>
                {
                    b.HasOne("DSS_Assignment_Islam.Models.Actor", "Actor")
                        .WithMany("Acts")
                        .HasForeignKey("ActorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DSS_Assignment_Islam.Models.Trick", "Trick")
                        .WithMany("Acts")
                        .HasForeignKey("TrickID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Trick");
                });

            modelBuilder.Entity("DSS_Assignment_Islam.Models.Actor", b =>
                {
                    b.HasOne("DSS_Assignment_Islam.Models.Circus", "Circus")
                        .WithMany("Actors")
                        .HasForeignKey("CircusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Circus");
                });

            modelBuilder.Entity("DSS_Assignment_Islam.Models.Actor", b =>
                {
                    b.Navigation("Acts");
                });

            modelBuilder.Entity("DSS_Assignment_Islam.Models.Circus", b =>
                {
                    b.Navigation("Actors");
                });

            modelBuilder.Entity("DSS_Assignment_Islam.Models.Trick", b =>
                {
                    b.Navigation("Acts");
                });
#pragma warning restore 612, 618
        }
    }
}
