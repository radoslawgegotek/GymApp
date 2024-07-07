using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ticketPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "TicketTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "TicketTypes");
        }
    }
}
