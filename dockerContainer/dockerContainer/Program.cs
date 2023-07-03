using dockerContainer.Context;
using dockerContainer.Model;
using dockerContainer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var host = builder.Configuration["DBHOST"] ?? "localhost";
var port = builder.Configuration["DBPORT"] ?? "3306";
var password = builder.Configuration["DBPASSWORD"] ?? "159753";

//var host = builder.Configuration["DBHOST"] ?? "localhost";
//var port = 3306;
//var password = 159753;

//string mySqlConnection = $"Server={host}; Port={port}; Database=testeDocker; Uid=root; Pwd={password}";
string mySqlConnection = $"server={host};userid=root;pwd={password};port={port};database=DockerCompose";


//var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ITesteDockerRepository, TesteDockerRepository>();


builder.Services.AddDbContext<TesteDockerContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddControllers();

var app = builder.Build();


PopulaDb.IncluiDadosDb(app);

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();