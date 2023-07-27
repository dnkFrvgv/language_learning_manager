﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230727181958_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("Domain.Entities.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Domain.Entities.LearningSpace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUdpatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("LearningSpaces");
                });

            modelBuilder.Entity("Domain.Entities.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("ComprehensionLevel")
                        .HasColumnType("REAL");

                    b.Property<Guid>("LearningSpaceId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SkillDedicatedId")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("TimeDedicated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LearningSpaceId");

                    b.HasIndex("SkillDedicatedId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Domain.Entities.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Domain.Entities.Vocabulary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExamplePhrase")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Translation")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("VocabularyListId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VocabularyListId");

                    b.ToTable("Vocabularies");
                });

            modelBuilder.Entity("Domain.Entities.VocabularyList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LearningSpaceId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LearningSpaceId");

                    b.ToTable("VocabularyLists");
                });

            modelBuilder.Entity("Domain.Entities.LearningSpace", b =>
                {
                    b.HasOne("Domain.Entities.Language", "Language")
                        .WithMany("LearningSpaces")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Domain.Entities.Log", b =>
                {
                    b.HasOne("Domain.Entities.LearningSpace", "LearningSpace")
                        .WithMany("Logs")
                        .HasForeignKey("LearningSpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Skill", "SkillDedicated")
                        .WithMany()
                        .HasForeignKey("SkillDedicatedId");

                    b.Navigation("LearningSpace");

                    b.Navigation("SkillDedicated");
                });

            modelBuilder.Entity("Domain.Entities.Vocabulary", b =>
                {
                    b.HasOne("Domain.Entities.VocabularyList", "VocabularyList")
                        .WithMany("Vocabularies")
                        .HasForeignKey("VocabularyListId");

                    b.Navigation("VocabularyList");
                });

            modelBuilder.Entity("Domain.Entities.VocabularyList", b =>
                {
                    b.HasOne("Domain.Entities.LearningSpace", "LearningSpace")
                        .WithMany("VocabularyLists")
                        .HasForeignKey("LearningSpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LearningSpace");
                });

            modelBuilder.Entity("Domain.Entities.Language", b =>
                {
                    b.Navigation("LearningSpaces");
                });

            modelBuilder.Entity("Domain.Entities.LearningSpace", b =>
                {
                    b.Navigation("Logs");

                    b.Navigation("VocabularyLists");
                });

            modelBuilder.Entity("Domain.Entities.VocabularyList", b =>
                {
                    b.Navigation("Vocabularies");
                });
#pragma warning restore 612, 618
        }
    }
}
