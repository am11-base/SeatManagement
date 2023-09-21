using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class updated1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetsLookup_AssetTypeId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Employees_EmployeeId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Cabins_Facilities_FacilityId",
                table: "Cabins");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_DepartmentLookup_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Buildings_FacilityCityId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_Cities_FacilityBuildingId",
                table: "Facilities");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingRooms_Facilities_FacilityId",
                table: "MeetingRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenitiesMap_Amenities_AmenityId",
                table: "RoomAmenitiesMap");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenitiesMap_MeetingRooms_RoomId",
                table: "RoomAmenitiesMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Facilities_FacilityId",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenitiesMap",
                table: "RoomAmenitiesMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingRooms",
                table: "MeetingRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cabins",
                table: "Cabins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetsLookup",
                table: "AssetsLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assets",
                table: "Assets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amenities",
                table: "Amenities");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameTable(
                name: "RoomAmenitiesMap",
                newName: "RoomAmenityMap");

            migrationBuilder.RenameTable(
                name: "MeetingRooms",
                newName: "MeetingRoom");

            migrationBuilder.RenameTable(
                name: "Facilities",
                newName: "Facility");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "CityLookUp");

            migrationBuilder.RenameTable(
                name: "Cabins",
                newName: "Cabin");

            migrationBuilder.RenameTable(
                name: "Buildings",
                newName: "BuildingLookup");

            migrationBuilder.RenameTable(
                name: "AssetsLookup",
                newName: "AssetLookup");

            migrationBuilder.RenameTable(
                name: "Assets",
                newName: "AssetAllocation");

            migrationBuilder.RenameTable(
                name: "Amenities",
                newName: "Amenity");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_FacilityId",
                table: "Seat",
                newName: "IX_Seat_FacilityId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenitiesMap_RoomId",
                table: "RoomAmenityMap",
                newName: "IX_RoomAmenityMap_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenitiesMap_AmenityId",
                table: "RoomAmenityMap",
                newName: "IX_RoomAmenityMap_AmenityId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingRooms_FacilityId",
                table: "MeetingRoom",
                newName: "IX_MeetingRoom_FacilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Facilities_FacilityCityId",
                table: "Facility",
                newName: "IX_Facility_FacilityCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Facilities_FacilityBuildingId",
                table: "Facility",
                newName: "IX_Facility_FacilityBuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employee",
                newName: "IX_Employee_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Cabins_FacilityId",
                table: "Cabin",
                newName: "IX_Cabin_FacilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_EmployeeId",
                table: "AssetAllocation",
                newName: "IX_AssetAllocation_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_AssetTypeId",
                table: "AssetAllocation",
                newName: "IX_AssetAllocation_AssetTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "SeatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenityMap",
                table: "RoomAmenityMap",
                column: "RoomAmenityMapId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingRoom",
                table: "MeetingRoom",
                column: "MeetingRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facility",
                table: "Facility",
                column: "FacilityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityLookUp",
                table: "CityLookUp",
                column: "CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cabin",
                table: "Cabin",
                column: "CabinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingLookup",
                table: "BuildingLookup",
                column: "BuildingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetLookup",
                table: "AssetLookup",
                column: "AssetTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetAllocation",
                table: "AssetAllocation",
                column: "AssetAllocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amenity",
                table: "Amenity",
                column: "AmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocation_AssetLookup_AssetTypeId",
                table: "AssetAllocation",
                column: "AssetTypeId",
                principalTable: "AssetLookup",
                principalColumn: "AssetTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetAllocation_Employee_EmployeeId",
                table: "AssetAllocation",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cabin_Facility_FacilityId",
                table: "Cabin",
                column: "FacilityId",
                principalTable: "Facility",
                principalColumn: "FacilityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_DepartmentLookup_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "DepartmentLookup",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingRoom_Facility_FacilityId",
                table: "MeetingRoom",
                column: "FacilityId",
                principalTable: "Facility",
                principalColumn: "FacilityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenityMap_Amenity_AmenityId",
                table: "RoomAmenityMap",
                column: "AmenityId",
                principalTable: "Amenity",
                principalColumn: "AmenityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenityMap_MeetingRoom_RoomId",
                table: "RoomAmenityMap",
                column: "RoomId",
                principalTable: "MeetingRoom",
                principalColumn: "MeetingRoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Facility_FacilityId",
                table: "Seat",
                column: "FacilityId",
                principalTable: "Facility",
                principalColumn: "FacilityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocation_AssetLookup_AssetTypeId",
                table: "AssetAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetAllocation_Employee_EmployeeId",
                table: "AssetAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Cabin_Facility_FacilityId",
                table: "Cabin");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_DepartmentLookup_DepartmentId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Facility_BuildingLookup_FacilityCityId",
                table: "Facility");

            migrationBuilder.DropForeignKey(
                name: "FK_Facility_CityLookUp_FacilityBuildingId",
                table: "Facility");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingRoom_Facility_FacilityId",
                table: "MeetingRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenityMap_Amenity_AmenityId",
                table: "RoomAmenityMap");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenityMap_MeetingRoom_RoomId",
                table: "RoomAmenityMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Facility_FacilityId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenityMap",
                table: "RoomAmenityMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingRoom",
                table: "MeetingRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facility",
                table: "Facility");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityLookUp",
                table: "CityLookUp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cabin",
                table: "Cabin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingLookup",
                table: "BuildingLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetLookup",
                table: "AssetLookup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetAllocation",
                table: "AssetAllocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amenity",
                table: "Amenity");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameTable(
                name: "RoomAmenityMap",
                newName: "RoomAmenitiesMap");

            migrationBuilder.RenameTable(
                name: "MeetingRoom",
                newName: "MeetingRooms");

            migrationBuilder.RenameTable(
                name: "Facility",
                newName: "Facilities");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "CityLookUp",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Cabin",
                newName: "Cabins");

            migrationBuilder.RenameTable(
                name: "BuildingLookup",
                newName: "Buildings");

            migrationBuilder.RenameTable(
                name: "AssetLookup",
                newName: "AssetsLookup");

            migrationBuilder.RenameTable(
                name: "AssetAllocation",
                newName: "Assets");

            migrationBuilder.RenameTable(
                name: "Amenity",
                newName: "Amenities");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_FacilityId",
                table: "Seats",
                newName: "IX_Seats_FacilityId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenityMap_RoomId",
                table: "RoomAmenitiesMap",
                newName: "IX_RoomAmenitiesMap_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenityMap_AmenityId",
                table: "RoomAmenitiesMap",
                newName: "IX_RoomAmenitiesMap_AmenityId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingRoom_FacilityId",
                table: "MeetingRooms",
                newName: "IX_MeetingRooms_FacilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Facility_FacilityCityId",
                table: "Facilities",
                newName: "IX_Facilities_FacilityCityId");

            migrationBuilder.RenameIndex(
                name: "IX_Facility_FacilityBuildingId",
                table: "Facilities",
                newName: "IX_Facilities_FacilityBuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Cabin_FacilityId",
                table: "Cabins",
                newName: "IX_Cabins_FacilityId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetAllocation_EmployeeId",
                table: "Assets",
                newName: "IX_Assets_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetAllocation_AssetTypeId",
                table: "Assets",
                newName: "IX_Assets_AssetTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "SeatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenitiesMap",
                table: "RoomAmenitiesMap",
                column: "RoomAmenityMapId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingRooms",
                table: "MeetingRooms",
                column: "MeetingRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facilities",
                table: "Facilities",
                column: "FacilityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cabins",
                table: "Cabins",
                column: "CabinId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "BuildingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetsLookup",
                table: "AssetsLookup",
                column: "AssetTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assets",
                table: "Assets",
                column: "AssetAllocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amenities",
                table: "Amenities",
                column: "AmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetsLookup_AssetTypeId",
                table: "Assets",
                column: "AssetTypeId",
                principalTable: "AssetsLookup",
                principalColumn: "AssetTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Employees_EmployeeId",
                table: "Assets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cabins_Facilities_FacilityId",
                table: "Cabins",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "FacilityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_DepartmentLookup_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "DepartmentLookup",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Buildings_FacilityCityId",
                table: "Facilities",
                column: "FacilityCityId",
                principalTable: "Buildings",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facilities_Cities_FacilityBuildingId",
                table: "Facilities",
                column: "FacilityBuildingId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingRooms_Facilities_FacilityId",
                table: "MeetingRooms",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "FacilityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenitiesMap_Amenities_AmenityId",
                table: "RoomAmenitiesMap",
                column: "AmenityId",
                principalTable: "Amenities",
                principalColumn: "AmenityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenitiesMap_MeetingRooms_RoomId",
                table: "RoomAmenitiesMap",
                column: "RoomId",
                principalTable: "MeetingRooms",
                principalColumn: "MeetingRoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Facilities_FacilityId",
                table: "Seats",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "FacilityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
