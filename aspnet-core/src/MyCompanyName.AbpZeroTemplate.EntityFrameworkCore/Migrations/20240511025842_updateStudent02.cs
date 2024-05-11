using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class updateStudent02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LearningProgress",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "LearningProgress",
                table: "ClassStudents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LearningProgress",
                table: "ClassStudents");

            migrationBuilder.AddColumn<string>(
                name: "LearningProgress",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
