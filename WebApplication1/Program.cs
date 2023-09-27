using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication1.Data;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.Repositories.Implementations;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Implementations;
using WebApplication1.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<SeatManagementDbContext>(options => options.UseSqlServer("name=ConnectionStrings:Default"));
builder.Services.AddScoped<IRepository<BuildingLookUp>, BuildingLookUpRepo>();
builder.Services.AddScoped<IRepository<CityLookUp>, CityLookUpRepo>();
builder.Services.AddScoped<IRepository<Facility>, FacilityRepo>();
builder.Services.AddScoped<IRepository<Seat>, SeatRepo>();
builder.Services.AddScoped<IRepository<Cabin>, CabinRepo>();
builder.Services.AddScoped<IRepository<MeetingRoom>, MeetingRoomRepo>();
builder.Services.AddScoped<IRepository<Amenity>, AmenityRepo>();
builder.Services.AddScoped<IRepository<RoomAmenityMap>, RoomAmenityMapRepo>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepo>();
builder.Services.AddScoped<IRepository<DepartmentLookup>, DepartmentLookupRepo>();
builder.Services.AddScoped<IRepository<AssetAllocation>, AssetAllocationRepo>();
builder.Services.AddScoped<IRepository<AssetLookup>, AssetLookUpRepo>();




builder.Services.AddScoped<IBuildingRepo, BuildingLookUpRepo>();
builder.Services.AddScoped<ICityRepo, CityLookUpRepo>();
builder.Services.AddScoped<ISeatRepo, SeatRepo>();
builder.Services.AddScoped<ICabinRepo, CabinRepo>();
builder.Services.AddScoped<IRoomRepo, MeetingRoomRepo>();
builder.Services.AddScoped<IAllocationRepo, AssetAllocationRepo>();




builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IFacilityService, FacilityService>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped<ICabinService, CabinService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IAmenityService, AmenityService>();
builder.Services.AddScoped<IRoomAmenityMapService, RoomAmenityMapService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IAllocationService, AllocationService>();
builder.Services.AddScoped<IAssetLookupService, AssetLookupService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAuthentication(authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
 .AddJwtBearer(options =>
 {
     var keyBytes = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Jwt:Key"));

     options.SaveToken = true;
     options.TokenValidationParameters = new TokenValidationParameters
     {
       IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
       ValidateLifetime = true,
       ValidateAudience = false,
       ValidateIssuer = false,
       ClockSkew = TimeSpan.Zero
     };
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.Run();
