using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityProject.DataAccess.Migrations
{
    public partial class changeTablesAtAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groups_GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Subjects_SubjectId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FacultyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DeanName",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "CurrentCourseYear",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ViceDeanName",
                table: "Faculties",
                newName: "Cipher");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "AspNetUsers",
                newName: "ChairId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_SubjectId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ChairId");

            migrationBuilder.AddColumn<long>(
                name: "ControlWorksCount",
                table: "Subjects",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationYear",
                table: "Groups",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<long>(
                name: "StudentsCount",
                table: "Faculties",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Faculties",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Faculties",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chair",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDateUTC = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Cipher = table.Column<string>(maxLength: 30, nullable: true),
                    FacultyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chair", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chair_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDateUTC = table.Column<DateTime>(nullable: false),
                    Number = table.Column<long>(nullable: false),
                    FacultyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDateUTC = table.Column<DateTime>(nullable: false),
                    PartOfEducationYear = table.Column<int>(nullable: false),
                    Year = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDateUTC = table.Column<DateTime>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherSubject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubject_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDateUTC = table.Column<DateTime>(nullable: false),
                    SemesterId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journal_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Journal_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SemesterSubject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDateUTC = table.Column<DateTime>(nullable: false),
                    SemesterId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SemesterSubject_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemesterSubject_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDateUTC = table.Column<DateTime>(nullable: false),
                    Mark = table.Column<decimal>(nullable: false),
                    JournalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statement_Journal_JournalId",
                        column: x => x.JournalId,
                        principalTable: "Journal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentStatement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDateUTC = table.Column<DateTime>(nullable: false),
                    StatementId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStatement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentStatement_Statement_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStatement_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectStatement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDateUTC = table.Column<DateTime>(nullable: false),
                    StatementId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectStatement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectStatement_Statement_StatementId",
                        column: x => x.StatementId,
                        principalTable: "Statement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectStatement_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseId",
                table: "Groups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Chair_FacultyId",
                table: "Chair",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_FacultyId",
                table: "Course",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Journal_GroupId",
                table: "Journal",
                column: "GroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Journal_SemesterId",
                table: "Journal",
                column: "SemesterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SemesterSubject_SemesterId",
                table: "SemesterSubject",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterSubject_SubjectId",
                table: "SemesterSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Statement_JournalId",
                table: "Statement",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStatement_StatementId",
                table: "StudentStatement",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStatement_StudentId",
                table: "StudentStatement",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectStatement_StatementId",
                table: "SubjectStatement",
                column: "StatementId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectStatement_SubjectId",
                table: "SubjectStatement",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubject_SubjectId",
                table: "TeacherSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubject_TeacherId",
                table: "TeacherSubject",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groups_GroupId",
                table: "AspNetUsers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Chair_ChairId",
                table: "AspNetUsers",
                column: "ChairId",
                principalTable: "Chair",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Course_CourseId",
                table: "Groups",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groups_GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Chair_ChairId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Course_CourseId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "Chair");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "SemesterSubject");

            migrationBuilder.DropTable(
                name: "StudentStatement");

            migrationBuilder.DropTable(
                name: "SubjectStatement");

            migrationBuilder.DropTable(
                name: "TeacherSubject");

            migrationBuilder.DropTable(
                name: "Statement");

            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CourseId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ControlWorksCount",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CreationYear",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Faculties");

            migrationBuilder.RenameColumn(
                name: "Cipher",
                table: "Faculties",
                newName: "ViceDeanName");

            migrationBuilder.RenameColumn(
                name: "ChairId",
                table: "AspNetUsers",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ChairId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_SubjectId");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Groups",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentsCount",
                table: "Faculties",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<string>(
                name: "DeanName",
                table: "Faculties",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentCourseYear",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FacultyId",
                table: "AspNetUsers",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyId",
                table: "AspNetUsers",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groups_GroupId",
                table: "AspNetUsers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Subjects_SubjectId",
                table: "AspNetUsers",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
