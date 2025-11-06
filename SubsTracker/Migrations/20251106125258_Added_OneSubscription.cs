using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubsTracker.Migrations
{
    /// <inheritdoc />
    public partial class Added_OneSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Category", "Currency", "Description", "Frecuency", "Name", "PaymentDate", "Value" },
                values: new object[] { "2513c007-b0c0-4740-88ca-be481c8c1065", "Entertainment", "COP", "Streaming service for movies and TV shows", 2, "Netflix", new DateTime(2025, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 19900m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: "2513c007-b0c0-4740-88ca-be481c8c1065");
        }
    }
}
