using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class SeatManagementDbContext : DbContext
    {
        public SeatManagementDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Amenity> Amenity { get; set; }
        public DbSet<AssetAllocation> AssetAllocation { get; set; }
        public DbSet<AssetLookup> AssetLookup { get; set; }
        public DbSet<BuildingLookUp> BuildingLookup { get; set; }
        public DbSet<Cabin> Cabin { get; set; }
        public DbSet<CityLookUp> CityLookUp { get; set; }
        public DbSet<DepartmentLookup> DepartmentLookup { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Facility> Facility { get; set; }
        public DbSet<MeetingRoom> MeetingRoom { get; set; }
        public DbSet<RoomAmenityMap> RoomAmenityMap { get; set; }
        public DbSet<Seat> Seat { get; set; }
    }
}
