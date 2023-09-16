using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace honey_inventory_practice.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoneyInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeClass = table.Column<int>(type: "int", nullable: false),
                    Honey_Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Honey_Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceClass = table.Column<int>(type: "int", nullable: false),
                    Number_of_Bottles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoneyInventories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoneyInventories");
        }
    }
}
