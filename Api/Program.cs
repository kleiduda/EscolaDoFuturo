using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.services;
using Repository.DataBase;
using Repository.DapperConfig;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

//
builder.Services.AddScoped<IAlunoService,AlunoService>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
//
builder.Services.AddScoped<IResponsavelRepository, ResponsavelRepository>();
builder.Services.AddScoped<IResponsavelService, ResponsavelService>();

builder.Services.AddScoped<DbSession>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Adiciona o User Secrets ao builder de configuração
var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

builder.Services.AddSingleton<IConfiguration>(configuration);

//autommaper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Adiciona a connection string do User Secrets à sua aplicação
var connectionString = configuration.GetConnectionString("SqlString");

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
