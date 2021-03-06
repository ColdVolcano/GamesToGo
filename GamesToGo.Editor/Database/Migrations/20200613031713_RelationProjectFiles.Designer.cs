﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesToGo.Editor.Database.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200613031713_RelationProjectFiles")]
    partial class RelationProjectFiles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("GamesToGo.Editor.Database.Models.File", b =>
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

            modelBuilder.Entity("GamesToGo.Editor.Database.Models.FileRelation", b =>
                {
                    b.Property<int>("FileID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectID")
                        .HasColumnType("INTEGER");

                    b.HasKey("FileID", "ProjectID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("GamesToGo.Editor.Project.ProjectInfo", b =>
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

            modelBuilder.Entity("GamesToGo.Editor.Database.Models.FileRelation", b =>
                {
                    b.HasOne("GamesToGo.Editor.Database.Models.File", "File")
                        .WithMany("Relations")
                        .HasForeignKey("FileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesToGo.Editor.Project.ProjectInfo", "Project")
                        .WithMany("Relations")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesToGo.Editor.Project.ProjectInfo", b =>
                {
                    b.HasOne("GamesToGo.Editor.Database.Models.File", "File")
                        .WithOne("Project")
                        .HasForeignKey("GamesToGo.Editor.Project.ProjectInfo", "FileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
