using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Updatescheduletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Students_ID_student",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "ID_student",
                table: "Schedules",
                newName: "ID_class");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_ID_student",
                table: "Schedules",
                newName: "IX_Schedules_ID_class");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Classes_ID_class",
                table: "Schedules",
                column: "ID_class",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Classes_ID_class",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "ID_class",
                table: "Schedules",
                newName: "ID_student");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_ID_class",
                table: "Schedules",
                newName: "IX_Schedules_ID_student");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Students_ID_student",
                table: "Schedules",
                column: "ID_student",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
