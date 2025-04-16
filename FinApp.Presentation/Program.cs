using FinApp.Presentation;
using FinApp.Domain.Entities;
using FinApp.Domain.Interfaces;
using FinApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Data.SqlClient;
using FinApp.Application.Interfaces;
using FinApp.Application.Services;
using FinApp.Infrastructure.Repositories;
using FinApp.Presentation.Dtos;
using FinApp.Presentation.Mappings;
using FinApp.Presentation.Middleware;

namespace FinApp.Presentation;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
        builder.Services.AddScoped<IGenericService<User>, UserService>();
        builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

        var app = builder.Build();

        app.Use(async (ctx, next) =>
        {
            var start = DateTimeOffset.UtcNow;
            await next.Invoke(ctx);
            app.Logger.LogInformation($"Request {ctx.Request.Path}: {(DateTime.Now - start).TotalMilliseconds}");
        });

        app.UseMiddleware<ExceptionHandlingMiddleware>();

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
    }
}