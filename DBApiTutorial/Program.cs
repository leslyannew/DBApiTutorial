using AutoMapper;
using MediatR;
using DBApiTutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System;
using DBApiTutorial.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<OrgDBContext>(options => 
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ApiTutorialDB"]));

/*
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new OfficeProfile());
});

IMapper _mapper = mapperConfig.CreateMapper();
*/

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());


builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IOfficeRepository, OfficeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.MapControllers();

app.Run();
