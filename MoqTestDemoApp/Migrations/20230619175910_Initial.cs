using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoqTestDemoApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 6, 19, 17, 59, 10, 190, DateTimeKind.Utc).AddTicks(5484), "June.Hegmann61@yahoo.com", "June", "Hegmann", null, "1-969-838-9776 x3249" },
                    { 2L, new DateTime(2023, 6, 19, 17, 59, 10, 190, DateTimeKind.Utc).AddTicks(6434), "Jeremiah_Barton62@hotmail.com", "Jeremiah", "Barton", null, "(326) 780-1683 x195" },
                    { 3L, new DateTime(2023, 6, 19, 17, 59, 10, 190, DateTimeKind.Utc).AddTicks(7246), "Sonya_Kling10@gmail.com", "Sonya", "Kling", null, "(330) 886-2591 x049" },
                    { 4L, new DateTime(2023, 6, 19, 17, 59, 10, 190, DateTimeKind.Utc).AddTicks(8042), "Grant_Crona68@hotmail.com", "Grant", "Crona", null, "1-882-451-8270 x5456" },
                    { 5L, new DateTime(2023, 6, 19, 17, 59, 10, 190, DateTimeKind.Utc).AddTicks(8812), "Warren_Jenkins@yahoo.com", "Warren", "Jenkins", null, "648.200.9511 x2905" },
                    { 6L, new DateTime(2023, 6, 19, 17, 59, 10, 190, DateTimeKind.Utc).AddTicks(9593), "Maria_Ankunding60@yahoo.com", "Maria", "Ankunding", null, "1-760-858-4742" },
                    { 7L, new DateTime(2023, 6, 19, 17, 59, 10, 191, DateTimeKind.Utc).AddTicks(325), "Pete33@yahoo.com", "Pete", "Mohr", null, "568.849.1339 x772" },
                    { 8L, new DateTime(2023, 6, 19, 17, 59, 10, 191, DateTimeKind.Utc).AddTicks(1049), "Virginia39@yahoo.com", "Virginia", "Wolf", null, "1-651-747-3438 x26759" },
                    { 9L, new DateTime(2023, 6, 19, 17, 59, 10, 191, DateTimeKind.Utc).AddTicks(1820), "Dustin_Conn@hotmail.com", "Dustin", "Conn", null, "773.732.7535" },
                    { 10L, new DateTime(2023, 6, 19, 17, 59, 10, 191, DateTimeKind.Utc).AddTicks(2525), "Ruby.Batz14@hotmail.com", "Ruby", "Batz", null, "1-241-686-7956 x20547" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
