using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContosoUniversity.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_CourseId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "Enrollments");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_CourseId",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseId");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Credits", "Title" },
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
                columns: new[] { "ID", "EnrollmentDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carson Alexander" },
                    { 2, new DateTime(2017, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meredith Alonso" },
                    { 3, new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arturo Anand" },
                    { 4, new DateTime(2017, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gytis Barzdukas" },
                    { 5, new DateTime(2017, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yan Li" },
                    { 6, new DateTime(2016, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peggy Justice" },
                    { 7, new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura Norman" },
                    { 8, new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nino Olivetto" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentID", "CourseId", "Grade", "StudentID" },
                values: new object[,]
                {
                    { 1, 1, 0, 1 },
                    { 2, 2, 2, 1 },
                    { 3, 3, 1, 1 },
                    { 4, 4, 1, 2 },
                    { 5, 5, 4, 2 },
                    { 6, 6, 4, 2 },
                    { 7, 1, null, 3 },
                    { 8, 1, null, 4 },
                    { 9, 2, 4, 4 },
                    { 10, 3, 2, 5 },
                    { 11, 4, null, 6 },
                    { 12, 5, 0, 7 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentID",
                table: "Enrollments",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentID",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentID",
                table: "Enrollment",
                newName: "IX_Enrollment_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollment",
                newName: "IX_Enrollment_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_CourseId",
                table: "Enrollment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
