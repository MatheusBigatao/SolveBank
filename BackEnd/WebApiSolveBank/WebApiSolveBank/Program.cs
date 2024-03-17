using Microsoft.EntityFrameworkCore;
using SolveBank.Entities.Models;
using SolveBank.Infrastructure;
using SolveBank.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adicionando InfrastructureModule
builder.Services.AddInfrastructure();

builder.Services.AddDbContext<SolveBankDbConfig>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DbConectionTest"));
});

//Adicionando Congiguração de E-mail
builder.Services.Configure<EmailConfiguracao>(builder.Configuration.GetSection("SmptConfig"));

//Adidicionando Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        string[] origins = { "http://localhost:4200", "" };
        builder.
         WithOrigins(origins)
         .WithMethods("GET", "POST", "PUT", "PATCH", "DELETE")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials(); ;
    });
});

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
