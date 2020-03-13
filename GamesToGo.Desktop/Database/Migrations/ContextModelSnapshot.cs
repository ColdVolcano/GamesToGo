﻿// <auto-generated />
using System;
using GamesToGo.Desktop.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GamesToGo.Desktop.Database.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("GamesToGo.Desktop.Database.Models.File", b =>
                {
                    b.Property<int>("FileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NewName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(40);

                    b.Property<string>("OriginalName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FileID");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("GamesToGo.Desktop.Database.Models.FileRelation", b =>
                {
                    b.Property<int>("FileID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectID")
                        .HasColumnType("INTEGER");

                    b.HasKey("FileID", "ProjectID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("GamesToGo.Desktop.Project.ProjectInfo", b =>
                {
                    b.Property<int>("LocalProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComunityStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CreatorID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FileID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastEdited")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxNumberPlayers")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinNumberPlayers")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModerationStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberBoxes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberCards")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberTokens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OnlineProjectID")
                        .HasColumnType("INTEGER");

                    b.HasKey("LocalProjectID");

                    b.HasIndex("FileID")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("GamesToGo.Desktop.Database.Models.FileRelation", b =>
                {
                    b.HasOne("GamesToGo.Desktop.Database.Models.File", "File")
                        .WithMany("Relations")
                        .HasForeignKey("FileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesToGo.Desktop.Project.ProjectInfo", "Project")
                        .WithMany("Relations")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesToGo.Desktop.Project.ProjectInfo", b =>
                {
                    b.HasOne("GamesToGo.Desktop.Database.Models.File", "File")
                        .WithOne()
                        .HasForeignKey("GamesToGo.Desktop.Project.ProjectInfo", "FileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
