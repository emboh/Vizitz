using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vizitz.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("b6f768d5-6d77-4814-8a93-a679f97b6448"), "b6f768d5-6d77-4814-8a93-a679f97b6448", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("1fe125cd-2a32-4a6e-aed9-7ff821627b38"), "1fe125cd-2a32-4a6e-aed9-7ff821627b38", "Proprietor", "PROPRIETOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("889ef87a-ba2c-4e6e-b71c-03786981e437"), "889ef87a-ba2c-4e6e-b71c-03786981e437", "Visitor", "VISITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1fe125cd-2a32-4a6e-aed9-7ff821627b38"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("889ef87a-ba2c-4e6e-b71c-03786981e437"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b6f768d5-6d77-4814-8a93-a679f97b6448"));
        }
    }
}
