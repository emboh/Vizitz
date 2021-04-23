using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vizitz.Migrations
{
    public partial class EditTimestampField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "UpdatedAt",
                table: "Visit",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Visit",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Venue",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Venue",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "User",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "User",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Schedule",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Schedule",
                newName: "Deleted");

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "Visit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "Venue",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Added",
                table: "Schedule",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProprietorDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProprietorDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitorDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Identification = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VenueDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ProprietorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VenueDTO_ProprietorDTO_ProprietorId",
                        column: x => x.ProprietorId,
                        principalTable: "ProprietorDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleDTO_VenueDTO_VenueId",
                        column: x => x.VenueId,
                        principalTable: "VenueDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitDTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleId = table.Column<int>(type: "int", nullable: true),
                    Added = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: true),
                    VisitorId = table.Column<int>(type: "int", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitDTO_ScheduleDTO_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "ScheduleDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VisitDTO_VisitorDTO_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "VisitorDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProprietorDTO",
                columns: new[] { "Id", "Added", "Address", "Email", "IsActive", "Modified", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, null, "464 Ross Oval, Bethanyfurt, Rwanda", "Mertie75@hotmail.com", true, null, "William Stoltenberg", "999.879.1572" },
                    { 2, null, "0918 Hilll Unions, Thompsonmouth, Mayotte", "Arvid13@gmail.com", true, null, "Tom Toy", "1-558-643-9698" },
                    { 3, null, "7008 Gaylord Fall, Schmittside, Andorra", "Kali82@gmail.com", true, null, "Issac Graham", "295-315-3359" },
                    { 4, null, "8018 Bahringer Avenue, Prudencemouth, Guernsey", "Tierra66@yahoo.com", true, null, "Kiel Terry", "(762) 994-5099" },
                    { 5, null, "32028 Naomi Mission, East Vivien, Lithuania", "Allene62@gmail.com", true, null, "Margarett Weissnat", "356.957.8030 x4640" },
                    { 6, null, "2651 Josue Isle, Ulisesview, Saint Lucia", "Rosario_Cole@hotmail.com", true, null, "Lew Green", "(801) 512-1770 x7791" },
                    { 7, null, "2422 Bonita Mission, Clydemouth, Honduras", "Ericka.Lubowitz61@yahoo.com", true, null, "Jason Wolff", "694.531.5618" },
                    { 8, null, "060 Brooks Unions, Jordaneview, Libyan Arab Jamahiriya", "Christopher_Parisian67@yahoo.com", true, null, "Leanne Marvin", "1-972-631-8534 x813" },
                    { 9, null, "982 Heather Path, North Damon, Niue", "Verlie.Metz@yahoo.com", true, null, "Tom Murazik", "(774) 894-7092" },
                    { 10, null, "868 Trantow Motorway, Emmerichton, Georgia", "Yolanda_Herman@yahoo.com", true, null, "Gianni Weimann", "550.774.8292 x26546" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDTO_VenueId",
                table: "ScheduleDTO",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueDTO_ProprietorId",
                table: "VenueDTO",
                column: "ProprietorId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitDTO_ScheduleId",
                table: "VisitDTO",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitDTO_VisitorId",
                table: "VisitDTO",
                column: "VisitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "VisitDTO");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ScheduleDTO");

            migrationBuilder.DropTable(
                name: "VisitorDTO");

            migrationBuilder.DropTable(
                name: "VenueDTO");

            migrationBuilder.DropTable(
                name: "ProprietorDTO");

            migrationBuilder.DropColumn(
                name: "Added",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "Added",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Added",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Added",
                table: "Schedule");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Visit",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Visit",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Venue",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Venue",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "User",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "User",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Schedule",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Schedule",
                newName: "CreatedAt");

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
    }
}
