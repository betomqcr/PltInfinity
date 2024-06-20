using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfintyHibotPlt.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Conversations_ConversationidConversation",
                table: "Messages");

            migrationBuilder.AlterColumn<long>(
                name: "ConversationidConversation",
                table: "Messages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Conversations_ConversationidConversation",
                table: "Messages",
                column: "ConversationidConversation",
                principalTable: "Conversations",
                principalColumn: "idConversation",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Conversations_ConversationidConversation",
                table: "Messages");

            migrationBuilder.AlterColumn<long>(
                name: "ConversationidConversation",
                table: "Messages",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Conversations_ConversationidConversation",
                table: "Messages",
                column: "ConversationidConversation",
                principalTable: "Conversations",
                principalColumn: "idConversation");
        }
    }
}
