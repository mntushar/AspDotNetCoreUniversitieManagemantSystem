using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class relStudentAndDept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Student_DeptId",
                table: "Student",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department_DeptId",
                table: "Student",
                column: "DeptId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department_DeptId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_DeptId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Student");
        }
    }
}
