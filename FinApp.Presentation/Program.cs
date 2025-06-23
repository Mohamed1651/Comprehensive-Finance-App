using FinApp.Presentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Data.SqlClient;
using FinApp.Infrastructure.Repositories;
using FinApp.Application.Dtos;
using FinApp.Presentation.Mappings;
using FinApp.Presentation.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FinApp.Application.Commands.CreateUser;
using FinApp.Domain.Interfaces;
using FinApp.Domain.Entities;
using FinApp.Domain.Aggregates;
using FinApp.Infrastructure.Contexts;
using FinApp.Domain.Events;

namespace FinApp.Presentation;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        var oidcSettings = builder.Configuration.GetSection("OIDC").Get<OIDCSettingsDto>() ?? new OIDCSettingsDto();
        // Add services to the container.
        builder.Services.Configure<OIDCSettingsDto>(builder.Configuration.GetSection("OIDC"));
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Authority = oidcSettings.Authority;
            options.Audience = oidcSettings.ClientId;

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = oidcSettings.Authority,
                ValidateAudience = true,
                ValidAudience = oidcSettings.ClientId,
                ValidateLifetime = true
            }; 

            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    Console.WriteLine("Token validation failed: " + context.Exception.Message);
                    return Task.CompletedTask;
                },
                OnTokenValidated = context =>
                {
                    Console.WriteLine("Token validated.");
                    return Task.CompletedTask;
                }
            };
        });

        builder.Services.AddAuthorization();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", builder =>
            {
                builder.WithOrigins("https://localhost:5173")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials();
            });
        });

        builder.Services.AddControllers();
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(CreateUserHandler).Assembly, typeof(AccountCreatedEventHandler).Assembly);
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
        builder.Services.AddScoped<IRepository<AccountAggregate>, AccountRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        builder.Services.AddDbContext<UserDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
        builder.Services.AddDbContext<FinanceDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
        var app = builder.Build();

        app.UseCustomExceptionHandler();

        using (var scope = app.Services.CreateScope())
        {
            var userdbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
            userdbContext.Database.Migrate();

            var financedbContext = scope.ServiceProvider.GetRequiredService<FinanceDbContext>();
            financedbContext.Database.Migrate();
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors("AllowFrontend");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}