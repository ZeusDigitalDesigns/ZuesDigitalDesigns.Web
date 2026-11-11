using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZuesDigitalDesigns.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedPortfolioProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImagePath", "Title" },
                values: new object[] { "QRForge is a custom, cross-platform QR Code Generator built with C# and .NET 10. Featuring a sleek industrial UI theme, this tool is designed for developers and users who need to generate and log QR codes efficiently.", "/images/qrforge-logo.png", "QRForge" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Nexus Sports Center is a comprehensive sports management web app. It streamlines operations by allowing users to create teams, manage player rosters, and assign home venues. With intuitive tools to schedule matches, log game results, and seamlessly filter historical scores, it serves as the ultimate hub for organizing competitive play.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImagePath", "Title" },
                values: new object[] { "Automated telemetry dashboard monitoring real-time inventory and machine health across a fleet of smart vending machines in Pierce County.", "/images/snacks-logo.png", "Sasquatch Snacks Dashboard" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Nexus Sports Center is a comprehensive sports management web app.It streamlines operations by allowing users to create teams, manage player rosters, and assign home venues. With intuitive tools to schedule matches, log game results, and seamlessly filter historical scores, it serves as the ultimate hub for organizing competitive play.");
        }
    }
}
