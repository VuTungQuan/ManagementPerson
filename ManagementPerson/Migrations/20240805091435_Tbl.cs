using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementPerson.Migrations
{
    public partial class Tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addresses_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Professor_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    StudentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageMark = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Student_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId");
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "EmailAddress", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 4, "person4@example.com", "Vu Minh Duc", "1234567894" },
                    { 5, "person5@example.com", "Nguyen Huong Duyen", "1234567895" },
                    { 6, "person6@example.com", "Hoang Thi Lan", "1234567896" },
                    { 1, "person1@example.com", "Vu Tung Quan", "1234567891" },
                    { 2, "person2@example.com", "Nguyen Ai Dan", "1234567892" },
                    { 3, "person3@example.com", "Duc Minh Hoang", "1234567893" }
                });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "PersonId", "Salary" },
                values: new object[,]
                {
                    { 4, 50000m },
                    { 5, 60000m },
                    { 6, 70000m }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "PersonId", "AverageMark", "StudentNumber" },
                values: new object[,]
                {
                    { 1, 9.5, "000001" },
                    { 2, 9.0, "000002" },
                    { 3, 8.5, "000003" }
                });

            migrationBuilder.InsertData(
                table: "addresses",
                columns: new[] { "Id", "Name", "Number", "PersonId" },
                values: new object[,]
                {
                    { 1, "Hà Nội", "30", 1 },
                    { 2, "Hải Dương", "34", 2 },
                    { 3, "Hải Phòng", "15", 3 },
                    { 4, "Hưng Yên", "89", 4 },
                    { 5, "Hải Dương", "34", 5 },
                    { 6, "Hải Phòng", "15", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_PersonId",
                table: "addresses",
                column: "PersonId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
