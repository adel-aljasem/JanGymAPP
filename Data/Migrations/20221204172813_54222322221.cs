using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JanGym.Migrations
{
    public partial class _54222322221 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "RegisterNewTraineeModel",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "RegisterNewTraineeModel",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
