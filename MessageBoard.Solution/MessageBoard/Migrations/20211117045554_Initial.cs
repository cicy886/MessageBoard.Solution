using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(20) CHARACTER SET utf8mb4", maxLength: 20, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    MessageDescription = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Age", "Date", "MessageDescription", "UserName" },
                values: new object[,]
                {
                    { 1, 17, "11-14-2021", "hey pablo ", "Matilda" },
                    { 2, 21, "06-31-1908", "oooooh you nasty", "Rexie" },
                    { 3, 35, "09-26-1998", "who are you sisi", "Matilda" },
                    { 4, 15, "02-10-1996", "My butt itches", "Pip" },
                    { 5, 22, "11-15-1999", "ya that sisi is one looker", "Bartholomew" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
