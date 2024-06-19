using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfintyHibotPlt.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bitacora",
                columns: table => new
                {
                    idBitacora = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jsonEntrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    idConversation = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacora", x => x.idBitacora);
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    idConversation = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    contactPhoneWA = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    idItemInfinity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agenteEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idHibotConversation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.idConversation);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    idMessages = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personContent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idHibotMessages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    media = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mediaType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConversationidConversation = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.idMessages);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_ConversationidConversation",
                        column: x => x.ConversationidConversation,
                        principalTable: "Conversations",
                        principalColumn: "idConversation");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationidConversation",
                table: "Messages",
                column: "ConversationidConversation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacora");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Conversations");
        }
    }
}
