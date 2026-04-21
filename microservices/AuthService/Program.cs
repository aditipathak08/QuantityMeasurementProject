using QuantityMeasurementApp.Service;
using QuantityMeasurementApp.Repository;
using QuantityMeasurementApp.API.Middleware;
using QuantityMeasurementApp.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text;
using NLog;
using NLog.Web;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Setup NLog
var logger = LogManager.Setup()
    .LoadConfigurationFromFile("Logging/NLog.config")
    .GetCurrentClassLogger();

builder.Logging.ClearProviders();
builder.Logging.AddConsole(); 

try
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                           ?? "Server=127.0.0.1,1433;Database=QuantityMeasurementDB;User Id=sa;Password=Your_Password123;TrustServerCertificate=True;";
    
    builder.Services.AddDbContext<QuantityMeasurementDbContext>(options =>
        options.UseSqlServer(connectionString));

    var redisConnection = builder.Configuration["Redis:ConnectionString"] ?? "localhost:6379";
    var redisOptions = ConfigurationOptions.Parse(redisConnection);
    redisOptions.AbortOnConnectFail = false; 
    builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisOptions));
    builder.Services.AddScoped<RedisCacheService>();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth Microservice API", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme.",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                },
                new string[] { }
            }
        });
    });

    var jwtKey = builder.Configuration["Jwt:Key"] ?? "THIS_IS_A_SECURE_32_CHARACTER_KEY_!!!";
    builder.Services.AddSingleton(new JwtService(jwtKey));
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IAuthService, AuthService>();

    var key = Encoding.UTF8.GetBytes(jwtKey);
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<QuantityMeasurementDbContext>();
        int retryCount = 10;
        while (retryCount > 0)
        {
            try
            {
                dbContext.Database.EnsureCreated();
                Console.WriteLine("✅ Database connected successfully.");
                break;
            }
            catch
            {
                retryCount--;
                if (retryCount == 0) throw;
                Console.WriteLine($"⏳ Database not ready. Retrying... ({retryCount} attempts left)");
                Thread.Sleep(3000);
            }
        }
    }

    app.UseMiddleware<ExceptionMiddleware>();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"❌ AuthService Startup failed: {ex.Message}");
    throw;
}
finally
{
    LogManager.Shutdown();
}
