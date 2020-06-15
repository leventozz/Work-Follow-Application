using Microsoft.EntityFrameworkCore.Migrations;

namespace OZProje.ToDo.DataAccess.Migrations
{
    public partial class AppUserTaskRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Works",
                table: "Works");

            migrationBuilder.RenameTable(
                name: "Works",
                newName: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AppUserId",
                table: "Tasks",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_AppUserId",
                table: "Tasks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AppUserId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AppUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Works");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Works",
                table: "Works",
                column: "Id");
        }
    }
}
