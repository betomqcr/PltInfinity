using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfintyHibotPlt.Migrations
{
    public partial class EntradaCreacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    idEntrada = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idChat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JsonEntrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaEntrada = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.idEntrada);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrada");
        }
    }
}
