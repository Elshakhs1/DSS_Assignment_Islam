using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSS_Assignment_Islam.Migrations
{
    public partial class DBCircus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Circuses",
                columns: table => new
                {
                    CircusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CircusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CircusLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circuses", x => x.CircusID);
                });

            migrationBuilder.CreateTable(
                name: "Tricks",
                columns: table => new
                {
                    TrickID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrickName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tricks", x => x.TrickID);
                });

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActorAge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActorSpacielity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CircusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorID);
                    table.ForeignKey(
                        name: "FK_Actors_Circuses_CircusID",
                        column: x => x.CircusID,
                        principalTable: "Circuses",
                        principalColumn: "CircusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acts",
                columns: table => new
                {
                    ActID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorID = table.Column<int>(type: "int", nullable: false),
                    TrickID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acts", x => x.ActID);
                    table.ForeignKey(
                        name: "FK_Acts_Actors_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actors",
                        principalColumn: "ActorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acts_Tricks_TrickID",
                        column: x => x.TrickID,
                        principalTable: "Tricks",
                        principalColumn: "TrickID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_CircusID",
                table: "Actors",
                column: "CircusID");

            migrationBuilder.CreateIndex(
                name: "IX_Acts_ActorID",
                table: "Acts",
                column: "ActorID");

            migrationBuilder.CreateIndex(
                name: "IX_Acts_TrickID",
                table: "Acts",
                column: "TrickID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acts");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Tricks");

            migrationBuilder.DropTable(
                name: "Circuses");
        }
    }
}
