using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityProject.DataAccess.Migrations
{
    public partial class changeRelationBetweenFacultyAndGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Chair_ChairId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Chair_Faculties_FacultyId",
                table: "Chair");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Course_CourseId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Journal_Groups_GroupId",
                table: "Journal");

            migrationBuilder.DropForeignKey(
                name: "FK_Journal_Semester_SemesterId",
                table: "Journal");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterSubject_Semester_SemesterId",
                table: "SemesterSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterSubject_Subjects_SubjectId",
                table: "SemesterSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Statement_Journal_JournalId",
                table: "Statement");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentStatement_Statement_StatementId",
                table: "StudentStatement");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentStatement_AspNetUsers_StudentId",
                table: "StudentStatement");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectStatement_Statement_StatementId",
                table: "SubjectStatement");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectStatement_Subjects_SubjectId",
                table: "SubjectStatement");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubject_Subjects_SubjectId",
                table: "TeacherSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubject_AspNetUsers_TeacherId",
                table: "TeacherSubject");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherSubject",
                table: "TeacherSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectStatement",
                table: "SubjectStatement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentStatement",
                table: "StudentStatement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statement",
                table: "Statement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SemesterSubject",
                table: "SemesterSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semester",
                table: "Semester");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Journal",
                table: "Journal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chair",
                table: "Chair");

            migrationBuilder.RenameTable(
                name: "TeacherSubject",
                newName: "TeacherSubjects");

            migrationBuilder.RenameTable(
                name: "SubjectStatement",
                newName: "SubjectStatements");

            migrationBuilder.RenameTable(
                name: "StudentStatement",
                newName: "StudentStatements");

            migrationBuilder.RenameTable(
                name: "Statement",
                newName: "Statements");

            migrationBuilder.RenameTable(
                name: "SemesterSubject",
                newName: "SemesterSubjects");

            migrationBuilder.RenameTable(
                name: "Semester",
                newName: "Semesters");

            migrationBuilder.RenameTable(
                name: "Journal",
                newName: "Journals");

            migrationBuilder.RenameTable(
                name: "Chair",
                newName: "Chairs");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Groups",
                newName: "FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_CourseId",
                table: "Groups",
                newName: "IX_Groups_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSubject_TeacherId",
                table: "TeacherSubjects",
                newName: "IX_TeacherSubjects_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSubject_SubjectId",
                table: "TeacherSubjects",
                newName: "IX_TeacherSubjects_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectStatement_SubjectId",
                table: "SubjectStatements",
                newName: "IX_SubjectStatements_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectStatement_StatementId",
                table: "SubjectStatements",
                newName: "IX_SubjectStatements_StatementId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentStatement_StudentId",
                table: "StudentStatements",
                newName: "IX_StudentStatements_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentStatement_StatementId",
                table: "StudentStatements",
                newName: "IX_StudentStatements_StatementId");

            migrationBuilder.RenameIndex(
                name: "IX_Statement_JournalId",
                table: "Statements",
                newName: "IX_Statements_JournalId");

            migrationBuilder.RenameIndex(
                name: "IX_SemesterSubject_SubjectId",
                table: "SemesterSubjects",
                newName: "IX_SemesterSubjects_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SemesterSubject_SemesterId",
                table: "SemesterSubjects",
                newName: "IX_SemesterSubjects_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Journal_SemesterId",
                table: "Journals",
                newName: "IX_Journals_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Journal_GroupId",
                table: "Journals",
                newName: "IX_Journals_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Chair_FacultyId",
                table: "Chairs",
                newName: "IX_Chairs_FacultyId");

            migrationBuilder.AddColumn<int>(
                name: "CourseNumberType",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherSubjects",
                table: "TeacherSubjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectStatements",
                table: "SubjectStatements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentStatements",
                table: "StudentStatements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statements",
                table: "Statements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SemesterSubjects",
                table: "SemesterSubjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Journals",
                table: "Journals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chairs",
                table: "Chairs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Chairs_ChairId",
                table: "AspNetUsers",
                column: "ChairId",
                principalTable: "Chairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chairs_Faculties_FacultyId",
                table: "Chairs",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Faculties_FacultyId",
                table: "Groups",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Groups_GroupId",
                table: "Journals",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Semesters_SemesterId",
                table: "Journals",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterSubjects_Semesters_SemesterId",
                table: "SemesterSubjects",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterSubjects_Subjects_SubjectId",
                table: "SemesterSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statements_Journals_JournalId",
                table: "Statements",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentStatements_Statements_StatementId",
                table: "StudentStatements",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentStatements_AspNetUsers_StudentId",
                table: "StudentStatements",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectStatements_Statements_StatementId",
                table: "SubjectStatements",
                column: "StatementId",
                principalTable: "Statements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectStatements_Subjects_SubjectId",
                table: "SubjectStatements",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectId",
                table: "TeacherSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_AspNetUsers_TeacherId",
                table: "TeacherSubjects",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Chairs_ChairId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Chairs_Faculties_FacultyId",
                table: "Chairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Faculties_FacultyId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Journals_Groups_GroupId",
                table: "Journals");

            migrationBuilder.DropForeignKey(
                name: "FK_Journals_Semesters_SemesterId",
                table: "Journals");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterSubjects_Semesters_SemesterId",
                table: "SemesterSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterSubjects_Subjects_SubjectId",
                table: "SemesterSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Statements_Journals_JournalId",
                table: "Statements");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentStatements_Statements_StatementId",
                table: "StudentStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentStatements_AspNetUsers_StudentId",
                table: "StudentStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectStatements_Statements_StatementId",
                table: "SubjectStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectStatements_Subjects_SubjectId",
                table: "SubjectStatements");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectId",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_AspNetUsers_TeacherId",
                table: "TeacherSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherSubjects",
                table: "TeacherSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectStatements",
                table: "SubjectStatements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentStatements",
                table: "StudentStatements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statements",
                table: "Statements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SemesterSubjects",
                table: "SemesterSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Semesters",
                table: "Semesters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Journals",
                table: "Journals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chairs",
                table: "Chairs");

            migrationBuilder.DropColumn(
                name: "CourseNumberType",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "TeacherSubjects",
                newName: "TeacherSubject");

            migrationBuilder.RenameTable(
                name: "SubjectStatements",
                newName: "SubjectStatement");

            migrationBuilder.RenameTable(
                name: "StudentStatements",
                newName: "StudentStatement");

            migrationBuilder.RenameTable(
                name: "Statements",
                newName: "Statement");

            migrationBuilder.RenameTable(
                name: "SemesterSubjects",
                newName: "SemesterSubject");

            migrationBuilder.RenameTable(
                name: "Semesters",
                newName: "Semester");

            migrationBuilder.RenameTable(
                name: "Journals",
                newName: "Journal");

            migrationBuilder.RenameTable(
                name: "Chairs",
                newName: "Chair");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Groups",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_FacultyId",
                table: "Groups",
                newName: "IX_Groups_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSubjects_TeacherId",
                table: "TeacherSubject",
                newName: "IX_TeacherSubject_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSubjects_SubjectId",
                table: "TeacherSubject",
                newName: "IX_TeacherSubject_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectStatements_SubjectId",
                table: "SubjectStatement",
                newName: "IX_SubjectStatement_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectStatements_StatementId",
                table: "SubjectStatement",
                newName: "IX_SubjectStatement_StatementId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentStatements_StudentId",
                table: "StudentStatement",
                newName: "IX_StudentStatement_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentStatements_StatementId",
                table: "StudentStatement",
                newName: "IX_StudentStatement_StatementId");

            migrationBuilder.RenameIndex(
                name: "IX_Statements_JournalId",
                table: "Statement",
                newName: "IX_Statement_JournalId");

            migrationBuilder.RenameIndex(
                name: "IX_SemesterSubjects_SubjectId",
                table: "SemesterSubject",
                newName: "IX_SemesterSubject_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SemesterSubjects_SemesterId",
                table: "SemesterSubject",
                newName: "IX_SemesterSubject_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Journals_SemesterId",
                table: "Journal",
                newName: "IX_Journal_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Journals_GroupId",
                table: "Journal",
                newName: "IX_Journal_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Chairs_FacultyId",
                table: "Chair",
                newName: "IX_Chair_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherSubject",
                table: "TeacherSubject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectStatement",
                table: "SubjectStatement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentStatement",
                table: "StudentStatement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statement",
                table: "Statement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SemesterSubject",
                table: "SemesterSubject",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Semester",
                table: "Semester",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Journal",
                table: "Journal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chair",
                table: "Chair",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDateUTC = table.Column<DateTime>(nullable: false),
                    FacultyId = table.Column<int>(nullable: true),
                    Number = table.Column<long>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Course_FacultyId",
                table: "Course",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Chair_ChairId",
                table: "AspNetUsers",
                column: "ChairId",
                principalTable: "Chair",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chair_Faculties_FacultyId",
                table: "Chair",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Course_CourseId",
                table: "Groups",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Journal_Groups_GroupId",
                table: "Journal",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Journal_Semester_SemesterId",
                table: "Journal",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterSubject_Semester_SemesterId",
                table: "SemesterSubject",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterSubject_Subjects_SubjectId",
                table: "SemesterSubject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statement_Journal_JournalId",
                table: "Statement",
                column: "JournalId",
                principalTable: "Journal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentStatement_Statement_StatementId",
                table: "StudentStatement",
                column: "StatementId",
                principalTable: "Statement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentStatement_AspNetUsers_StudentId",
                table: "StudentStatement",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectStatement_Statement_StatementId",
                table: "SubjectStatement",
                column: "StatementId",
                principalTable: "Statement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectStatement_Subjects_SubjectId",
                table: "SubjectStatement",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubject_Subjects_SubjectId",
                table: "TeacherSubject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubject_AspNetUsers_TeacherId",
                table: "TeacherSubject",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
