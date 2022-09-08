using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bourque.EMAILQueue.EntityFramework.Migrations
{
    public partial class initialtablesetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailServers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SmtpServerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmtpServerUserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailServers", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "EmailQueueRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromEmailEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailQueueRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailQueueRecords_EmailServers_FromEmailEmail",
                        column: x => x.FromEmailEmail,
                        principalTable: "EmailServers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAttachements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QueueRecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAttachements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAttachements_EmailQueueRecords_QueueRecordId",
                        column: x => x.QueueRecordId,
                        principalTable: "EmailQueueRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailAttachements_QueueRecordId",
                table: "EmailAttachements",
                column: "QueueRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailQueueRecords_FromEmailEmail",
                table: "EmailQueueRecords",
                column: "FromEmailEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailAttachements");

            migrationBuilder.DropTable(
                name: "EmailQueueRecords");

            migrationBuilder.DropTable(
                name: "EmailServers");
        }
    }
}
