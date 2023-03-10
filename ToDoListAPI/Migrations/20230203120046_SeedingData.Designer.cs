// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoListAPI.Database;

#nullable disable

namespace ToDoListAPI.Migrations
{
    [DbContext(typeof(ToDoContext))]
    [Migration("20230203120046_SeedingData")]
    partial class SeedingData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("ToDoListAPI.Database.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "Einkaufen"
                        },
                        new
                        {
                            Id = -2,
                            Name = "Putzen"
                        },
                        new
                        {
                            Id = -3,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = -4,
                            Name = "Party"
                        });
                });

            modelBuilder.Entity("ToDoListAPI.Database.ToDoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Due")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ToDoItems");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CategoryId = -1,
                            Created = new DateTime(2023, 1, 27, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(268),
                            IsDone = true,
                            Titel = "Montagseinkauf"
                        },
                        new
                        {
                            Id = -2,
                            CategoryId = -1,
                            Created = new DateTime(2023, 2, 3, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(323),
                            Due = new DateTime(2023, 2, 6, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(326),
                            IsDone = false,
                            Titel = "Großeinkauf"
                        },
                        new
                        {
                            Id = -3,
                            CategoryId = -2,
                            Created = new DateTime(2023, 2, 3, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(329),
                            Due = new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDone = false,
                            Titel = "Frühjahrsputz"
                        },
                        new
                        {
                            Id = -4,
                            CategoryId = -2,
                            Created = new DateTime(2023, 1, 31, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(334),
                            Due = new DateTime(2023, 2, 1, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(336),
                            IsDone = false,
                            Titel = "Geschirrspüler ausräumen"
                        },
                        new
                        {
                            Id = -6,
                            CategoryId = -3,
                            Created = new DateTime(2023, 2, 3, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(338),
                            Due = new DateTime(2023, 2, 4, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(340),
                            IsDone = false,
                            Titel = "Hanteltraining"
                        },
                        new
                        {
                            Id = -7,
                            CategoryId = -4,
                            Created = new DateTime(2023, 2, 3, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(342),
                            Due = new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDone = false,
                            Titel = "Dekorieren"
                        },
                        new
                        {
                            Id = -8,
                            CategoryId = -4,
                            Created = new DateTime(2023, 2, 3, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(345),
                            Due = new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDone = false,
                            Titel = "Getränke kaufen"
                        });
                });

            modelBuilder.Entity("ToDoListAPI.Database.ToDoItem", b =>
                {
                    b.HasOne("ToDoListAPI.Database.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
