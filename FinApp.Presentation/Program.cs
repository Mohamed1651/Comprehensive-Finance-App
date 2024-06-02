using ShinyCollectorPlatform.Presentation;
using ShinyCollectorPlatform.Application;
using ShinyCollectorPlatform.Application.Services;
using ShinyCollectorPlatform.Domain.Entities;
using ShinyCollectorPlatform.Domain.Interfaces;
using ShinyCollectorPlatform.Infrastructure;
using ShinyCollectorPlatform.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGenericService<Course>, CourseService>();
builder.Services.AddScoped<IGenericRepository<Course>, CourseRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
//builder.Services.AddAuthentication().AddGoogle(googleOptions =>
//{
//    //Application breaks if values are not provided.
//    googleOptions.ClientId = configuration["GoogleOAuth:ClientId"];
//    googleOptions.ClientSecret = configuration["GoogleOAuth:ClientSecret"];
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    ConfigureCors.InitializeCors(app);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
