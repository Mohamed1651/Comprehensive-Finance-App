using FinApp.Presentation;
using FinApp.Domain.Entities;
using FinApp.Domain.Interfaces;
using FinApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IGenericService<Course>, CourseService>();
//builder.Services.AddScoped<IGenericRepository<Course>, CourseRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
//builder.Services.AddAuthentication().AddGoogle(googleOptions =>
//{
//    //Application breaks if values are not provided.
//    googleOptions.ClientId = configuration["GoogleOAuth:ClientId"];
//    googleOptions.ClientSecret = configuration["GoogleOAuth:ClientSecret"];
//});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

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
