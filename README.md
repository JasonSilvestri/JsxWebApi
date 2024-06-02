# Official JSX Web API of the jSilvestri.com BETA v 2024 Web API Demo Collection

The `JsxWebAPI` application (i.e., jSilvestri.com BETA v 2024 Web API) in specific, is a FREE, open-source, custom, reusable, jSilvestri.com 2024 Web API Demo Collections ASP.NET Core 8 Web API, used for creating RESTful Web API secure end points, leveraging Asp.NET Core 8 controllers or minimal APIs, with optional support for OpenAPI and authentication, and backed by JWT Tokens.

## Overview

The `jSilvestri.com BETA v 2024` mobile and web applications, developed for most smart phones, tablets and desktop computers, was created to showcase a wide range of skills to potential clients and employers, while providing helpful information to fellow developers, demos for interview talks, access to resumes, etc.

The `JsxWebAPI` application (i.e., jSilvestri.com BETA v 2024 Web API) in specific, is a FREE, open-source, custom, reusable, jSilvestri.com 2024 Web API Demo Collections ASP.NET Core 8 Web API, used for creating RESTful Web API secure end points, leveraging Asp.NET Core 8 controllers or minimal APIs, with optional support for OpenAPI and authentication, and backed by JWT Tokens. This library promotes code reuse, reduces duplication, and simplifies maintenance, and uses JWT tokens for authentication and authorization to ensure secure access. 

Many applications in the `Custom jSilvestri.com BETA v 2024 Web API Demo Collection`, such as the `Angular Web API Demo`, `Blazor Web API Demo`, `React Web API Demo`, and `Vue Web API Demo` applications will use this project to reference common features throughout the collective applications.

**Copyright © 2024 All Rights Reserved by Jason Silvestri**

## Project Structure

The project is organized into the following structure:

### Key Components

- **Controllers**: Contains API controllers for handling RESTful HTTP requests.
- **Models**: Contains data models used in the application.
- **Services**: Contains service classes for business logic.
- **Program.cs**: Configures the application and its middleware.
- **appsettings.json**: Configuration file for application settings.

### Key Project References

- **Jsx Web API (You Are Here)**: Contains RESTful Web API secure end points, using Asp.NET Core 8 controllers or minimal APIs, with optional support for OpenAPI and authentication, and additional JWT authentication.

- **Jsx Class Library**: Contains constant values used across the application, such as JWT settings.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022 or higher](https://visualstudio.microsoft.com/)
- [Visit jSilvestri.com BETA v 2024 Demos for More Details](https://jsilvestri.com/home/demo)
  
### Installation

1. **Clone the repository**:

    ```bash
    git clone https://github.com/JasonSilvestri/JsxWebApi.git
    ```


2. **Open the solution in Visual Studio**:

    - Open `JsxWebApi.sln` in Visual Studio.

3. **Restore NuGet packages**:

    - Right-click on the solution in Solution Explorer and select `Restore NuGet Packages`.

4. **Build the project**:

    - Right-click on the solution in Solution Explorer and select `Build Solution`.

### Configuration

1. **Update appsettings.json**:

    ```json
    {
      "Jwt": {
        "Key": "YourSuperSecretKey",
        "Issuer": "YourIssuer",
        "Audience": "YourAudience",
        "ExpiresInMinutes": 60
      }
    }
    ```

2. **Configure JWT in Program.cs**:

    ```csharp
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

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
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

    builder.Services.AddAuthorization();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
    ```

### Usage
A future version of this documentation will have examples of how we use basic features of the Web API. 

### Secondary Usage (Web API Demo Apps in Angular, Blazor, React, Vue, etc.)

A future version of this documentation will have examples of how we use each front end client application to retrieve a response from the same Web API demos.
