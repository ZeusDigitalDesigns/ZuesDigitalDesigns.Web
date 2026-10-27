using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZuesDigitalDesigns.Migrations
{
    /// <inheritdoc />
    public partial class FixProjectSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DesignId",
                table: "Projects",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projects",
                newName: "DesignId");
        }
    }
}
