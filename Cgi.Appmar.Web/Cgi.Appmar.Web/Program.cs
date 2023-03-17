using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Interfaces.Services;
using Cgi.Appmar.Repositories;
using Cgi.Appmar.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AppmarContext, AppmarContext>();
builder.Services.AddTransient<IVesselServices, VesselServices>();
builder.Services.AddTransient<IVesselRepository, VesselRepository>();

var connectionString = builder.Configuration.GetConnectionString("APPMAR");

builder.Services.AddDbContext<AppmarContext>(options =>
      options.UseSqlServer(connectionString));

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
