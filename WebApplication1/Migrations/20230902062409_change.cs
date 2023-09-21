using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facility_BuildingLookup_FacilityCityId",
                table: "Facility");

            migrationBuilder.DropForeignKey(
                name: "FK_Facility_CityLookUp_FacilityBuildingId",
                table: "Facility");

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_BuildingLookup_FacilityBuildingId",
                table: "Facility",
                column: "FacilityBuildingId",
                principalTable: "BuildingLookup",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_CityLookUp_FacilityCityId",
                table: "Facility",
                column: "FacilityCityId",
                principalTable: "CityLookUp",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facility_BuildingLookup_FacilityBuildingId",
                table: "Facility");

            migrationBuilder.DropForeignKey(
                name: "FK_Facility_CityLookUp_FacilityCityId",
                table: "Facility");

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_BuildingLookup_FacilityCityId",
                table: "Facility",
                column: "FacilityCityId",
                principalTable: "BuildingLookup",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facility_CityLookUp_FacilityBuildingId",
                table: "Facility",
                column: "FacilityBuildingId",
                principalTable: "CityLookUp",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
