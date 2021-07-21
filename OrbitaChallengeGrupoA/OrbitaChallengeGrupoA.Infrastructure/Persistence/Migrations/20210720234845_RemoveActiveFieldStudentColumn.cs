using Microsoft.EntityFrameworkCore.Migrations;

namespace OrbitaChallengeGrupoA.Infrastructure.Persistence.Migrations
{
    public partial class RemoveActiveFieldStudentColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Students",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
