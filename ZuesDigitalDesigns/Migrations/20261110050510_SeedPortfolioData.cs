using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZuesDigitalDesigns.Migrations
{
    /// <inheritdoc />
    public partial class SeedPortfolioData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "ImagePath", "RepoUrl", "Title" },
                values: new object[,]
                {
                    { 1, "Automated telemetry dashboard monitoring real-time inventory and machine health across a fleet of smart vending machines in Pierce County.", "~/images/snacks-logo.png", "", "Sasquatch Snacks Dashboard" },
                    { 2, "Nexus Sports Center is a comprehensive sports management web app.It streamlines operations by allowing users to create teams, manage player rosters, and assign home venues. With intuitive tools to schedule matches, log game results, and seamlessly filter historical scores, it serves as the ultimate hub for organizing competitive play.", "~/images/Nexus-logo.jpeg", "", "Nexus Sports Center" },
                    { 3, "A full-stack .NET 10 MVC portal designed to eliminate the logistical chaos of running a modern dance studio. Features include class registration, secure tuition billing, competition tracking, and role-based dashboards for directors, instructors, and parents.", "~/images/dance-logo.jpeg", "", "Dance Studio Management" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
