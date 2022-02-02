using Microsoft.EntityFrameworkCore.Migrations;

namespace DEMO.EmployeeAPI.Repositories.Migrations
{
    public partial class AddedNewFieldIsActiveForEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Employee");
        }
    }
}
