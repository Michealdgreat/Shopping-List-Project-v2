using ShoppingLibrary.ShoppingListModel;
using ShoppingLibrary.DataAccess;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SymmetricSecurityKey = Microsoft.IdentityModel.Tokens.SymmetricSecurityKey;
using Shopping_List_Project.StartUpConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddShopServices(); //from dependency injection flder
builder.AddShophealthCheck(); // ''

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health").AllowAnonymous();

app.Run();