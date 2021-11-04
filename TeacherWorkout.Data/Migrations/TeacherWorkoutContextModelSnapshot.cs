﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TeacherWorkout.Data;

namespace TeacherWorkout.Data.Migrations
{
    [DbContext(typeof(TeacherWorkoutContext))]
    partial class TeacherWorkoutContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TeacherWorkout.Domain.Models.Image", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("TeacherWorkout.Domain.Models.Lesson", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("ThemeId")
                        .HasColumnType("text");

                    b.Property<string>("ThumbnailId")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ThemeId");

                    b.HasIndex("ThumbnailId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("TeacherWorkout.Domain.Models.Theme", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("ThumbnailId")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ThumbnailId");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("TeacherWorkout.Domain.Models.Lesson", b =>
                {
                    b.HasOne("TeacherWorkout.Domain.Models.Theme", "Theme")
                        .WithMany()
                        .HasForeignKey("ThemeId");

                    b.HasOne("TeacherWorkout.Domain.Models.Image", "Thumbnail")
                        .WithMany()
                        .HasForeignKey("ThumbnailId");

                    b.Navigation("Theme");

                    b.Navigation("Thumbnail");
                });

            modelBuilder.Entity("TeacherWorkout.Domain.Models.Theme", b =>
                {
                    b.HasOne("TeacherWorkout.Domain.Models.Image", "Thumbnail")
                        .WithMany()
                        .HasForeignKey("ThumbnailId");

                    b.Navigation("Thumbnail");
                });
#pragma warning restore 612, 618
        }
    }
}
