using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfintyHibotPlt.Migrations
{
    public partial class MejoraErrorBitacora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErroresBitacora",
                columns: table => new
                {
                    idError = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    menssageError = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErroresBitacora", x => x.idError);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErroresBitacora");
        }
    }
}
