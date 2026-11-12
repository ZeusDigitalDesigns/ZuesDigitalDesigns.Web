using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZuesDigitalDesigns.Migrations
{
    /// <inheritdoc />
    public partial class AddPortfolioModalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Problem",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Solution",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TechStack",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Problem", "Solution", "TechStack" },
                values: new object[] { "Users needed a fast, reliable, offline desktop tool to generate QR codes without paying for subscription web services.", "Built a standalone, cross-platform desktop application using Avalonia UI for instant, local QR generation.", "C#, .NET 10, Avalonia UI" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Problem", "Solution", "TechStack" },
                values: new object[] { "Local sports leagues lacked a unified system to manage rosters, schedule games, and track historical scores.", "Developed a comprehensive relational database and UI to streamline all league logistics in one hub.", "C#, ASP.NET Core MVC, EF Core, SQL Server" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Problem", "Solution", "TechStack" },
                values: new object[] { "Studio directors were drowning in paper registration forms and disorganized tuition billing processes.", "Created a secure, role-based portal to automate class sign-ups, billing, and competition tracking.", "C#, .NET 10, HTML/CSS, Bootstrap 5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Problem",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Solution",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TechStack",
                table: "Projects");
        }
    }
}
