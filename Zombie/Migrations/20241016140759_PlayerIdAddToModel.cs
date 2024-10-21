using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zombie.Migrations
{
    /// <inheritdoc />
    public partial class PlayerIdAddToModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "GameDatas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "GameDatas");
        }
    }
}
