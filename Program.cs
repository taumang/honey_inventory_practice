global using honey_inventory_practice.Services.HoneyInventoryService;
global using honey_inventory_practice.Models;
global using System.Text.Json.Serialization;// for [JsonConverter(typeof(JsonStringEnumConverter))] in EnumClass files

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
