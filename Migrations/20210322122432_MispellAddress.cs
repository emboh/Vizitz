using Microsoft.EntityFrameworkCore.Migrations;

namespace Vizitz.Migrations
{
    public partial class MispellAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Venue",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "User",
                newName: "Address");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "Identification", "IsActive", "Name", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "074 Gunnar Isle, North Zanehaven, Serbia", null, "Kailee.Torp@gmail.com", null, null, "Evangeline Rath", "(377) 524-7844", null },
                    { 2, "1004 Beier Crest, New Adrien, Uzbekistan", null, "Rory.Corkery@gmail.com", null, null, "Stuart Rath", "1-396-914-3389 x557", null },
                    { 3, "2778 Columbus Center, Altenwerthfort, Macao", null, "Brent_Howell74@gmail.com", null, null, "Drew Hagenes", "297.694.3867 x56472", null },
                    { 4, "5996 Roberts Plain, Ryanburgh, Dominica", null, "Jett_Lubowitz8@hotmail.com", null, null, "Precious Walker", "689.497.2648", null },
                    { 5, "672 Beau Courts, Rahulhaven, Niue", null, "Alexa_Bins@gmail.com", null, null, "Santos Farrell", "605-908-7707 x0298", null },
                    { 6, "1169 Lakin Flat, Lake Omari, El Salvador", null, "Brad.Thompson@hotmail.com", null, null, "Bessie Lowe", "635.511.4191", null },
                    { 7, "1087 Janis Land, Beatriceland, Finland", null, "Korbin.Schiller@hotmail.com", null, null, "Luigi Kirlin", "545-757-7491", null },
                    { 8, "1903 McDermott Fords, Lake Ike, Morocco", null, "Koby_Williamson@hotmail.com", null, null, "Domenico Labadie", "1-994-734-0686", null },
                    { 9, "3615 Linwood Spring, South Cole, Jordan", null, "Ivah_Haag21@hotmail.com", null, null, "Ericka Jerde", "979-488-1784", null },
                    { 10, "723 Vincenzo Orchard, West Rick, Virgin Islands, British", null, "Elza_Aufderhar33@hotmail.com", null, null, "Halle Gaylord", "568.521.5942 x066", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Venue",
                newName: "Adress");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "User",
                newName: "Adress");
        }
    }
}
