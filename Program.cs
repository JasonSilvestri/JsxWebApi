
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JsxClassLibrary;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Original out-of-the-box Swagger settings
// builder.Services.AddSwaggerGen();

// Modified Swagger settings for custom jSX Web API Demos
builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc(JsxConstants.AppCards.AppSwaggerCards.SwagVersion, new OpenApiInfo
    {
        Version = JsxConstants.AppCards.AppSwaggerCards.JsxWebApi.SwagDoc.SwagVersion,
        Title = JsxConstants.AppCards.AppSwaggerCards.JsxWebApi.SwagDoc.Title,
        Description = JsxConstants.AppCards.AppSwaggerCards.JsxWebApi.SwagDoc.Description,
        TermsOfService = new Uri(JsxConstants.AppCards.AppSwaggerCards.JsxWebApi.SwagDoc.TermsOfService),
        Contact = new OpenApiContact
        {
            Name = JsxConstants.AppCards.AppSwaggerCards.JsxWebApi.Contact.Name,
            Email = JsxConstants.AppCards.AppSwaggerCards.JsxWebApi.Contact.Email,
            Url = new Uri(JsxConstants.AppCards.AppSwaggerCards.JsxWebApi.Contact.PrimaryUrl)
        },
        License = new OpenApiLicense
        {
            Name = JsxConstants.AppCards.AppSwaggerCards.JsxWebApi.License.Mit.Name,
            Url = new Uri(JsxConstants.AppCards.AppSwaggerCards.JsxWebApi.License.Mit.Url)
        }

    });

});


// Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration[JsxConstants.JsxAppDemoSettings.JwtIssuer],
        ValidAudience = builder.Configuration[JsxConstants.JsxAppDemoSettings.JwtAudience],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration[JsxConstants.JsxAppDemoSettings.JwtKey]))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{ // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

    // Original out-of-the-box Swagger settings
    // app.UseSwagger();
    // app.UseSwaggerUI();

    // Modified Swagger settings for custom jSX Web API Demos
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = JsxConstants.AppCards.AppSwaggerCards.JsxWebApi.SwagDoc.IsSwagSerializeAsV2;
    });

    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint(JsxConstants.AppCards.AppSwaggerCards.JsxWebApi.SwagDoc.SwagEndPointUri, JsxConstants.AppCards.AppSwaggerCards.JsxWebApi.SwagDoc.SwagVersion);
        // This next line is recommended, but actually produces a white, blank page
        // options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();