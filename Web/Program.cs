using Infrastructure.DB.Contexts;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Web.Middleware;
using MediatR;
using Mapster;
using Application.Mappers.Mapster;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.DB.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddMediatR(Application.AssemblyReference.Assembly);

builder.Services.AddSingleton(GetConfiguredMappingConfig());
builder.Services.AddScoped<IMapper, ServiceMapper>();

builder.Services.AddDbContext<ModsenDbContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("Default"));
});

builder.Services.AddScoped<IRepository<ModsenEvent>, ModsenRepository<ModsenEvent>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

TypeAdapterConfig GetConfiguredMappingConfig()
{
    var cfg = TypeAdapterConfig.GlobalSettings;
    cfg.Scan(Assembly.GetExecutingAssembly(), Application.AssemblyReference.Assembly);
    return cfg;
}