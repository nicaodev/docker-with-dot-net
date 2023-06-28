using dockerContainer.Context;
using dockerContainer.Model;
using dockerContainer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var host = builder.Configuration["DBHOST"] ?? "localhost";
var port = builder.Configuration["DBPORT"] ?? "3306";
var password = builder.Configuration["DBPASSWORD"] ?? "159753";

string mySqlConnection = $"server={host};userid=root;pwd={password};port={port};database=testeDocker";

builder.Services.AddDbContext<TesteDockerContext>(opt => opt.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddControllers();

builder.Services.AddTransient<ITesteDockerRepository, TesteDockerRepository>();

var app = builder.Build();

PopulaDb.IncluiDadosDb(app);

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();