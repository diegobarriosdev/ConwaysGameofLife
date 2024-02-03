using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConwaysGameofLife.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifyinPropertiesColRowOnBoardEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cols",
                table: "BoardsEntity");

            migrationBuilder.DropColumn(
                name: "Rows",
                table: "BoardsEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cols",
                table: "BoardsEntity",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rows",
                table: "BoardsEntity",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
