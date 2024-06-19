using InfintyHibotPlt;
using InfintyHibotPlt.Datos.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => 
              options.UseSqlServer(connectionString));

var app = builder.Build();

startup.Configure(app,app.Environment);

app.Run();
