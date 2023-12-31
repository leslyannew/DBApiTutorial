using AutoMapper;
using DBApiTutorial.Features.Employees;
using DBApiTutorial.Features.Offices;
using DBApiTutorial.Features.Regions;
using DBApiTutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(options => 
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ApiTutorialDB"]));


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new RegionProfile());
    mc.AddProfile(new OfficeProfile());
    mc.AddProfile(new EmployeeProfile());
});

IMapper _mapper = mapperConfig.CreateMapper();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
