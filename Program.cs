global using Microsoft.EntityFrameworkCore;
global using AutoMapper;
global using honey_inventory_practice.Dtos.InventoryHoney;
global using honey_inventory_practice.Services.HoneyInventoryService;
global using honey_inventory_practice.Models;
global using System.Text.Json.Serialization;
using honey_inventory_practice.Data;// for [JsonConverter(typeof(JsonStringEnumConverter))] in EnumClass files

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<DataContext>(
    options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Register AutoMapper to implement it
builder.Services.AddAutoMapper(typeof(Program).Assembly);
//Injection section
builder.Services.AddScoped<IHoneyInventoryService,HoneyInventoryService>();

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
