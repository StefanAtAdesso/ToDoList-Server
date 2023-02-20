using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoListAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { -4, "Party" },
                    { -3, "Sport" },
                    { -2, "Putzen" },
                    { -1, "Einkaufen" }
                });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "CategoryId", "Created", "Due", "IsDone", "Titel" },
                values: new object[,]
                {
                    { -8, -4, new DateTime(2023, 2, 3, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(345), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Getränke kaufen" },
                    { -7, -4, new DateTime(2023, 2, 3, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(342), new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Dekorieren" },
                    { -6, -3, new DateTime(2023, 2, 3, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(338), new DateTime(2023, 2, 4, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(340), false, "Hanteltraining" },
                    { -4, -2, new DateTime(2023, 1, 31, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(334), new DateTime(2023, 2, 1, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(336), false, "Geschirrspüler ausräumen" },
                    { -3, -2, new DateTime(2023, 2, 3, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(329), new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Frühjahrsputz" },
                    { -2, -1, new DateTime(2023, 2, 3, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(323), new DateTime(2023, 2, 6, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(326), false, "Großeinkauf" },
                    { -1, -1, new DateTime(2023, 1, 27, 13, 0, 46, 248, DateTimeKind.Local).AddTicks(268), null, true, "Montagseinkauf" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "ToDoItems",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
