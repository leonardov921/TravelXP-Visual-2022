using Dynamitey;
using Microsoft.EntityFrameworkCore;
using TravelXP.Moviles.API.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");

// Registrar servicio para la conexión con MySQL
builder.Services.AddDbContext<APPDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 23)))); // Ajusta la versión según sea necesario

// Configuración CORS para permitir cualquier origen durante el desarrollo
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuración CORS para permitir cualquier origen durante el desarrollo
app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

// Middleware para manejar las solicitudes CORS OPTIONS preflight
app.Use(async (context, next) =>
{
    if (context.Request.Headers.ContainsKey("Origin"))
    {
        context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
        context.Response.Headers.Append("Access-Control-Allow-Headers", "Content-Type");
        context.Response.Headers.Append("Access-Control-Allow-Methods", "Get, Post, Put, Delete, OPTIONS");
        if (context.Request.Method == "OPTIONS")
        {
            context.Response.StatusCode = 200;
            await context.Response.CompleteAsync();
            return;
        }
    }
    await next();
});

// Eliminar la autenticación y autorización
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();
