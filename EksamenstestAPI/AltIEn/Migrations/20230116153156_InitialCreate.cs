using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AltIEn.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Retter",
                columns: table => new
                {
                    RetId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Navn = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retter", x => x.RetId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredienser",
                columns: table => new
                {
                    IngrediensId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Navn = table.Column<string>(type: "TEXT", nullable: false),
                    RetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredienser", x => x.IngrediensId);
                    table.ForeignKey(
                        name: "FK_Ingredienser_Retter_RetId",
                        column: x => x.RetId,
                        principalTable: "Retter",
                        principalColumn: "RetId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredienser_RetId",
                table: "Ingredienser",
                column: "RetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredienser");

            migrationBuilder.DropTable(
                name: "Retter");
        }
    }
}
