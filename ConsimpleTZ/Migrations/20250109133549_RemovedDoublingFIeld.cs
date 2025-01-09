using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsimpleTZ.Migrations
{
    /// <inheritdoc />
    public partial class RemovedDoublingFIeld : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
