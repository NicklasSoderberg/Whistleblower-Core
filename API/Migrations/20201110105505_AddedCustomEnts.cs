using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddedCustomEnts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    ConversationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    WhistleID = table.Column<int>(nullable: false),
                    Sender = table.Column<int>(nullable: false),
                    Sent = table.Column<DateTime>(nullable: false),
                    Read = table.Column<DateTime>(nullable: false),
                    FileID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.ConversationID);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Base64 = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    WhistleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileID);
                });

            migrationBuilder.CreateTable(
                name: "Whistles",
                columns: table => new
                {
                    WhistleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LawyerID = table.Column<Guid>(nullable: false),
                    AboutInfo = table.Column<string>(nullable: true),
                    WhenInfo = table.Column<string>(nullable: true),
                    WhereInfo = table.Column<string>(nullable: true),
                    DescriptionInfo = table.Column<string>(nullable: true),
                    OtherEmployeeInfo = table.Column<string>(nullable: true),
                    CurrentStatus = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RemovedAdminID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Whistles", x => x.WhistleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Whistles");
        }
    }
}
