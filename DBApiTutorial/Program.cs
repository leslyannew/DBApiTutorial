using AutoMapper;
using DBApiTutorial.Features.Addition.Map;
using DBApiTutorial.GamePublisher;
using DBApiTutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext <CompanyDBContext> (options =>
    options.UseSqlServer(builder.Configuration["TutorialDB"]));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new OfficeProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

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
