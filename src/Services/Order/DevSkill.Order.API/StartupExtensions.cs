

using DevSkill.Order.Application;
using DevSkill.Catalog.Persistence;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using DevSkill.Order.Persistence;
using DevSkill.Order.Application.Contracts;
using DevSkill.Order.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using MassTransit;
using DevSkill.Order.API.Consumers;

namespace DevSkill.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(
    this WebApplicationBuilder builder)
    {
        AddSwagger(builder.Services);

        builder.Services.AddPersistenceServices(builder.Configuration);
        builder.Services.AddApplicationServices();

        builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
              .AddJwtBearer(o =>
              {
                  o.RequireHttpsMetadata = false;
                  o.SaveToken = false;
                  o.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.Zero,
                      ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                      ValidAudience = builder.Configuration["JwtSettings:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
                  };

                  o.Events = new JwtBearerEvents()
                  {
                      OnAuthenticationFailed = c =>
                      {
                          c.NoResult();
                          c.Response.StatusCode = 500;
                          c.Response.ContentType = "text/plain";
                          return c.Response.WriteAsync(c.Exception.ToString());
                      },
                      OnChallenge = context =>
                      {
                          context.HandleResponse();
                          context.Response.StatusCode = 401;
                          context.Response.ContentType = "application/json";
                          var result = JsonSerializer.Serialize("401 Not authorized");
                          return context.Response.WriteAsync(result);
                      },
                      OnForbidden = context =>
                      {
                          context.Response.StatusCode = 403;
                          context.Response.ContentType = "application/json";
                          var result = JsonSerializer.Serialize("403 Not authorized");
                          return context.Response.WriteAsync(result);
                      }
                  };
              });

        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumer<CheckoutMessageConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });

        return builder.Build();

    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevSkill API");
            });
        }

        app.UseHttpsRedirection();

        //app.UseRouting();

        app.UseAuthentication();

        app.UseCors("Open");

        app.UseAuthorization();

        app.MapControllers();

       // app.UseAzServiceBusConsumer();

        return app;

    }
    private static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
              {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                });

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "DevSkill API",
            });

           // c.OperationFilter<FileResultContentTypeOperationFilter>();
        });
    }

    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        try
        {
            var dbContext = scope.ServiceProvider.GetService<DevSkillDbContext>();
            if (dbContext != null)
            {
               // await dbContext.Database.EnsureDeletedAsync();
                await dbContext.Database.MigrateAsync();
            }

        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
            logger.LogError(ex, "An error occurred while migrating the database.");
        }
    }
}


