using AutoMapper;
using DBApiTutorial.Features.Addition.Map;
using DBApiTutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = TutorialDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate=False; Application Intent = ReadWrite; Multi Subnet Failover=False";


builder.Services.AddDbContext<CompanyDBContext>(options => options.UseSqlServer(connectionString));

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
