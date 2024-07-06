using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfintyHibotPlt.Migrations
{
    public partial class agregarcampocliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "clinica",
                table: "Conversations",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clinica",
                table: "Conversations");
        }
    }
}
