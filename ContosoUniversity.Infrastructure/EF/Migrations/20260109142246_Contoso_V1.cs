using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContosoUniversity.EF.Migrations
{
    /// <inheritdoc />
    public partial class Contoso_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Credits", "Title" },
                values: new object[,]
                {
                    { 1, 3, "Chemistry" },
                    { 2, 3, "Microeconomics" },
                    { 3, 3, "Macroeconomics" },
                    { 4, 4, "Calculus" },
                    { 5, 4, "Trigonometry" },
                    { 6, 3, "Composition" },
                    { 7, 4, "Literature" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "EnrollmentDate", "FirstName", "LastName", "PhotoUri" },
                values: new object[,]
                {
                    { 1, new DateTime(2010, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc), "Carson", "Alexander", null },
                    { 2, new DateTime(2012, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc), "Meredith", "Alonso", null },
                    { 3, new DateTime(2013, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc), "Arturo", "Anand", null },
                    { 4, new DateTime(2012, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc), "Gytis", "Barzdukas", null },
                    { 5, new DateTime(2012, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc), "Yan", "Li", null },
                    { 6, new DateTime(2011, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc), "Peggy", "Justice", null },
                    { 7, new DateTime(2013, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc), "Laura", "Norman", null },
                    { 8, new DateTime(2005, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc), "Nino", "Olivetto", null }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "Grade", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, 0, 1 },
                    { 2, 2, 2, 1 },
                    { 3, 3, 1, 1 },
                    { 4, 4, 1, 2 },
                    { 5, 5, 1, 2 },
                    { 6, 6, 1, 2 },
                    { 7, 1, null, 3 },
                    { 8, 2, 1, 3 },
                    { 9, 1, 1, 4 },
                    { 10, 6, 1, 5 },
                    { 11, 7, 1, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
