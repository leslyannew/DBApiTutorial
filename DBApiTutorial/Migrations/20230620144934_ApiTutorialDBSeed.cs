using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBApiTutorial.Migrations
{
    /// <inheritdoc />
    public partial class ApiTutorialDBSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficeEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeEmployees_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Robert", "Smith" },
                    { 2, "Pamela", "Johnson" },
                    { 3, "John", "Franklin" },
                    { 4, "Kathy", "McDonald" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "East Baton Rouge" },
                    { 2, "West Baton Rouge" },
                    { 3, "Ascension" },
                    { 4, "Iberville" }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "City", "Phone", "RegionId", "State" },
                values: new object[,]
                {
                    { 1, "Baton Rouge", "555-222-2222", 1, "LA" },
                    { 2, "Port Allen", "555-123-4567", 2, "LA" },
                    { 3, "Gonzales", "555-777-7777", 3, "LA" },
                    { 4, "Plaquemine", "555-444-4444", 4, "LA" }
                });

            migrationBuilder.InsertData(
                table: "OfficeEmployees",
                columns: new[] { "Id", "EmployeeId", "OfficeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 },
                    { 4, 3, 3 },
                    { 5, 3, 4 },
                    { 6, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfficeEmployees_EmployeeId",
                table: "OfficeEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeEmployees_OfficeId",
                table: "OfficeEmployees",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_RegionId",
                table: "Offices",
                column: "RegionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficeEmployees");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
