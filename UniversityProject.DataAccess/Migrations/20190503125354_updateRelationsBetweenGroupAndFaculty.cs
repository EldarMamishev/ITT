using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityProject.DataAccess.Migrations
{
    public partial class updateRelationsBetweenGroupAndFaculty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Faculties_FacultyId",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Groups",
                newName: "ChairId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_FacultyId",
                table: "Groups",
                newName: "IX_Groups_ChairId");

            migrationBuilder.AddColumn<int>(
                name: "GroupNumber",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Chairs_ChairId",
                table: "Groups",
                column: "ChairId",
                principalTable: "Chairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Chairs_ChairId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupNumber",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "ChairId",
                table: "Groups",
                newName: "FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_ChairId",
                table: "Groups",
                newName: "IX_Groups_FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Faculties_FacultyId",
                table: "Groups",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
