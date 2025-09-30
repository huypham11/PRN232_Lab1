using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab1.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountMembers",
                columns: new[] { "MemberID", "EmailAddress", "FullName", "MemberPassword", "MemberRole" },
                values: new object[,]
                {
                    { "admin", "admin@example.com", "Administrator", "admin123", 1 },
                    { "user1", "user1@example.com", "User One", "user123", 0 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Mobile" },
                    { 2, "Laptop" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "ProductName", "UnitPrice", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, 1, "Iphone 17 Pro Max", 599m, 100 },
                    { 2, 1, "Iphone 17 Pro", 499m, 150 },
                    { 3, 1, "Iphone 17 Air", 399m, 200 },
                    { 4, 2, "Macbook Air M4", 1299m, 200 },
                    { 5, 2, "Macbook Pro M4", 1599m, 200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountMembers",
                keyColumn: "MemberID",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "AccountMembers",
                keyColumn: "MemberID",
                keyValue: "user1");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);
        }
    }
}
