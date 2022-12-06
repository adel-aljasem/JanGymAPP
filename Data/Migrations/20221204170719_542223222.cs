using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JanGym.Migrations
{
    public partial class _542223222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "RegisterNewTraineeModel",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterNewTraineeModel_Phone",
                table: "RegisterNewTraineeModel",
                column: "Phone",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RegisterNewTraineeModel_Phone",
                table: "RegisterNewTraineeModel");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "RegisterNewTraineeModel",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
