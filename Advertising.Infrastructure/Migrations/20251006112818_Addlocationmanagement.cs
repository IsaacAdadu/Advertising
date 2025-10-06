using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Advertising.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addlocationmanagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CampaignLocations_CampaignId",
                table: "CampaignLocations");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignLocations_CampaignId_LocationId",
                table: "CampaignLocations",
                columns: new[] { "CampaignId", "LocationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignLocations_LocationId",
                table: "CampaignLocations",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignLocations_Location_LocationId",
                table: "CampaignLocations",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignLocations_Location_LocationId",
                table: "CampaignLocations");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_CampaignLocations_CampaignId_LocationId",
                table: "CampaignLocations");

            migrationBuilder.DropIndex(
                name: "IX_CampaignLocations_LocationId",
                table: "CampaignLocations");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignLocations_CampaignId",
                table: "CampaignLocations",
                column: "CampaignId");
        }
    }
}
