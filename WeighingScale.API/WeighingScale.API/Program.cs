using Microsoft.EntityFrameworkCore;
using WeighingScale.API.Data;
using WeighingScale.API.Repository;
using WeighingScale.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<OrderWalaDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("OrderWalaConnection"),
        new MySqlServerVersion(new Version(8, 0, 30)) // Use your MySQL version
    ));

builder.Services.AddScoped<ISalesService, SalesService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
