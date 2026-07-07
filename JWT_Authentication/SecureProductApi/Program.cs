using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();//Enables API controllers
builder.Services.AddOpenApi();//Enables Swagger / OpenAPI for testing API

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        //Read JWT Secret Key from appsettings.json
        var jwtKey = builder.Configuration["JwtKey"]
            ?? throw new Exception("JWT Key is missing");
        
        //Token Validation Rules
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,// checks Is token expired?
            ValidateIssuerSigningKey = true,

            ValidIssuer = "SecureApi",
            ValidAudience = "SecureApiUsers",

          //Secret Key for Validation
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)
            )
        };
    });

builder.Services.AddAuthorization(); //Enables:[Authorize],[Authorize(Roles="Admin")] without this rolecheck wont work

var app = builder.Build();//create final app

//  Middleware
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();//JWT tokens are safer over HTTPS

app.UseAuthentication(); //reads jwt from request header,validate token,set user object --must before authorization
app.UseAuthorization();  //Checks:[Authorize],roles,permissions

app.MapControllers();   //connects routes to controller 

app.Run();//start the API



//for installing user-secret key rather than putting in appsettings.json
//dotnet user-secrets init
// dotnet user-secrets set "Jwt:Key" "ThisIsMySuperSecretKey123456789"
