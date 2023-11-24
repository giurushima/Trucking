using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Trucking.Context;
using System.Text;
using System.Text.Json.Serialization;
using AutoMapper;
using Trucking.Services;
using Trucking.Services.Trips;
using Trucking.Services.Truckers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TruckContext>(dbContextOptions => dbContextOptions.UseSqlite(
    builder.Configuration["ConnectionStrings:TruckingConnectionString"]));

builder.Services.AddScoped<IInfoTripsRepository, InfoTripsRepository>();
builder.Services.AddScoped<IInfoTruckersRepository, InfoTruckersRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
