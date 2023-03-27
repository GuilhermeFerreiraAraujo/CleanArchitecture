using Cgi.Appmar.Interfaces.Repositories;
using Cgi.Appmar.Interfaces.Services;
using Cgi.Appmar.Repositories;
using Cgi.Appmar.Services;
using Cgi.Appmar.Web.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Events.OnRedirectToLogin = (context) =>
        {
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AppmarContext, AppmarContext>();
builder.Services.AddTransient<IVesselServices, VesselServices>();
builder.Services.AddTransient<IUserServices, UserServices>();

builder.Services.AddTransient<IVesselRepository, VesselRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

var connectionString = builder.Configuration.GetConnectionString("APPMAR");

builder.Services.AddDbContext<AppmarContext>(options =>
      options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowAnyOrigin()); // allow credentials

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
