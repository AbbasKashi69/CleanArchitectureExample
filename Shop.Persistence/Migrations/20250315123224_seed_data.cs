using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seed_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "لوازم اکترونیک", null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "لوازم خانگی", null },
                    { 1000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "لوازم یدکی ماشین", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "موبایل", 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "لوازم موبایل", 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Name", "Picture", "Price", "Tags" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 15, 16, 2, 23, 978, DateTimeKind.Local).AddTicks(7486), "", "samsung A 50", null, 15000000m, null },
                    { 2, 1, new DateTime(2025, 3, 15, 16, 2, 23, 978, DateTimeKind.Local).AddTicks(7516), "", "samsung A 55", null, 12000000m, null },
                    { 3, 1, new DateTime(2025, 3, 15, 16, 2, 23, 978, DateTimeKind.Local).AddTicks(7521), "", "xiaomi red me 1", null, 17500000m, null },
                    { 4, 2, new DateTime(2025, 3, 15, 16, 2, 23, 978, DateTimeKind.Local).AddTicks(7525), "", "ipad pro", null, 48000000m, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
