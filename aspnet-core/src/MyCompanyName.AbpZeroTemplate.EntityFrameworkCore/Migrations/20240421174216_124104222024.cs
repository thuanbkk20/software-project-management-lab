using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class _124104222024 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicYear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_student = table.Column<int>(type: "int", nullable: false),
                    ID_class = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassStudents_Classes_ID_class",
                        column: x => x.ID_class,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassStudents_Students_ID_student",
                        column: x => x.ID_student,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_student = table.Column<int>(type: "int", nullable: false),
                    ID_user = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentUsers_AbpUsers_ID_user",
                        column: x => x.ID_user,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentUsers_Students_ID_student",
                        column: x => x.ID_student,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_student = table.Column<int>(type: "int", nullable: false),
                    ID_teacher = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Students_ID_student",
                        column: x => x.ID_student,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Teachers_ID_teacher",
                        column: x => x.ID_teacher,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_teacher = table.Column<int>(type: "int", nullable: false),
                    ID_user = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherUsers_AbpUsers_ID_user",
                        column: x => x.ID_user,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherUsers_Teachers_ID_teacher",
                        column: x => x.ID_teacher,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_ID_class",
                table: "ClassStudents",
                column: "ID_class");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_ID_student",
                table: "ClassStudents",
                column: "ID_student");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ID_student",
                table: "Schedules",
                column: "ID_student");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ID_teacher",
                table: "Schedules",
                column: "ID_teacher");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUsers_ID_student",
                table: "StudentUsers",
                column: "ID_student",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentUsers_ID_user",
                table: "StudentUsers",
                column: "ID_user");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherUsers_ID_teacher",
                table: "TeacherUsers",
                column: "ID_teacher",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherUsers_ID_user",
                table: "TeacherUsers",
                column: "ID_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassStudents");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "StudentUsers");

            migrationBuilder.DropTable(
                name: "TeacherUsers");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
