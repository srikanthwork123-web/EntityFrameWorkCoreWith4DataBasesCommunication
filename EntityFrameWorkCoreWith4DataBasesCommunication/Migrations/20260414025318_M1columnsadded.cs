using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Migrations
{
    /// <inheritdoc />
    public partial class M1columnsadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "m1",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "m2",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "m3",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "m4",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "m5",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "m1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "m2",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "m3",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "m4",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "m5",
                table: "Employees");
        }
    }
}
