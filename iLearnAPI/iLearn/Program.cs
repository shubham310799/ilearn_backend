using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OMS.Services;
using OMS.Services.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
string jwtSecret = string.Empty;
// Add services to the container.

builder.Services.AddControllers();
builder.Configuration.AddAzureKeyVault(new Uri(builder.Configuration.GetValue<string>("SecretManagerSettings:SecretManagerURL") ?? ""), new DefaultAzureCredential());

builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();

jwtSecret = builder.Configuration[builder.Configuration["SecretManagerSettings:AuthTokenKey"] ?? ""] ?? "";

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "http://localhost:6379";
    options.InstanceName = "redis-cache";
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
    {
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "validIssuer",
                ValidAudience = "validAudience",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
            };
        }
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
