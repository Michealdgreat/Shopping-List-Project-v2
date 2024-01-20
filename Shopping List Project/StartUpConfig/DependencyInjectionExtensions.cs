using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using ShoppingLibrary.DataAccess;
using System.Runtime.CompilerServices;
using System.Text;

namespace Shopping_List_Project.StartUpConfig;

public static class DependencyInjectionExtensions
{
    public static void AddShopServices(this WebApplicationBuilder builder)
    {

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        builder.Services.AddSingleton<IShopListData, ShopListData>();
        builder.Services.AddAuthorization(opts =>
        {
            opts.FallbackPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
        });

        builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer(opts =>
            {
                opts.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration.GetValue<string>("Authentication:Issuer"),
                    ValidAudience = builder.Configuration.GetValue<string>("Authentication:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(
                        builder.Configuration.GetValue<string>("Authentication:SecretKey")))

                };
            });

        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

    }

    public static void AddShophealthCheck(this WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("Default"));
    }

}