# Official JSX Web API of the jSilvestri.com BETA v 2024 Web API Demo Collection

The `JsxWebAPI` application (i.e., jSilvestri.com BETA v2024 Web API) is a free, open-source, reusable ASP.NET Core 8 Web API. It is part of the jSilvestri.com 2024 Web API Demo Collections and is designed to create secure RESTful Web API endpoints. It leverages ASP.NET Core 8 controllers or minimal APIs, with optional support for OpenAPI and authentication, backed by JWT tokens. This library promotes code reuse, reduces duplication, and simplifies maintenance, ensuring secure access through JWT-based authentication and authorization.

## Overview

The `jSilvestri.com BETA v 2024` mobile and web applications, developed for most smart phones, tablets and desktop computers, was created to showcase a wide range of skills to potential clients and employers, while providing helpful information to fellow developers, demos for interview talks, access to resumes, etc.

The `JsxWebAPI` application (i.e., jSilvestri.com BETA v2024 Web API) is a free, open-source, reusable ASP.NET Core 8 Web API. It is part of the jSilvestri.com 2024 Web API Demo Collections and is designed to create secure RESTful Web API endpoints. It leverages ASP.NET Core 8 controllers or minimal APIs, with optional support for OpenAPI and authentication, backed by JWT tokens. This library promotes code reuse, reduces duplication, and simplifies maintenance, ensuring secure access through JWT-based authentication and authorization.

Many applications in the `Custom jSilvestri.com BETA v 2024 Web API Demo Collection`, such as the `Angular Web API Demo`, `Blazor Web API Demo`, `React Web API Demo`, and `Vue Web API Demo` applications will use this project to reference common features throughout the collective applications.

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

A future version of this documentation will have examples of how we use each front end client application to retrieve data from the same Web API.

## Planned Evolution of jSilvestri.com BETA v2024 Web API Demo Collection

Depending on when you visit this demo application, it may look very different from your previous visit. I am not talking about common checkins to improve the applications. I am talking about noticable, planned, development that will shape each application in accordance to the grand design. In other words, the variability is intentional. 

The purpose of this project, and its associated projects, is to showcase my basic skills in the technologies I am currently exploring in 2024. By leveraging my 20 years of experience in full stack development and solution architecting, I aim to address areas often overlooked in typical online examples, such as security, object-oriented coding, and the transformation of existing assets, templates, and projects into custom creative designs that support specific objectives.

The target technologies and project structures include **AngularJS**, **Vue**, **ReactJS**, and **Blazor**, all of which access the same Web API project using ASP.NET Core 8 and Visual Studio 2022 (or higher).

### Source Control Strategies

There are typically two primary ways to handle source control for multiple projects:

1. **Monorepo**: Storing all projects within a single GitHub repository. This approach simplifies managing dependencies and integrations between projects and ensures consistency across the solution.
2. **Multi-repo**: Creating separate GitHub repositories for each project. This approach provides greater modularity and allows each project to evolve independently, which can be beneficial if projects have different development cycles or teams.

We will use a combination of both approaches. This hybrid method allows potential clients, employers, and fellow developers to download and run the applications they are most interested in as standalone projects (i.e., AngularJS, Vue, ReactJS, or Blazor), all accessing the same Web API project using ASP.NET Core 8 and Visual Studio 2022 (or higher), each with their own project and solution. Additionally, this approach ensures we can also create a project and solution that includes all applications, facilitating easy transitions between tiers for various needs (i.e., jSilvestri.com BETA v2024 Web API Demo Collection Project).

### Project Development Steps - Phase 1:

While this workflow may change, the steps I am taking to conclude all aspects of the project development are as follows:

1. **Add a Class Library**: Add a new ASP.NET Core Class Library project and solution. This project will serve as the common place where we share the most common class and interface parts we want to use across all applications, such as Constants, Enums, Helpers, etc.
   
2. **Add a Web API Project**: Add a new ASP.NET Core Web API project and solution. This project will serve as the backend API that the frontend projects will communicate with.

3. **Add a Shared Assets Project**: Add a new ASP.NET Core project and solution that will handle common, static, assets and resources, shared across all applications. This project will serve as the resource project with all HTML, CSS, JS, Images and other creative all projects will use to carry the same theme, look and feel across applications. For now, all projects will use the basic, out-of-the-box vanilla assets.

4. **Add Frontend Projects**:
   - Add separate projects and solutions for AngularJS, Vue, ReactJS, and Blazor. We will initially choose the appropriate project templates provided by Visual Studio.
   - For AngularJS, Vue, and ReactJS, we will consider creating separate ASP.NET Core Web Application projects and choosing the respective frontend frameworks (Angular, Vue.js, React.js) during project creation.
   - For Blazor, we will create a Blazor WebAssembly or Blazor Server project, depending on your preference. If I have bandwidth, I may also create a Blazor Hybrid Project, which is relatively new to the scene.

5. **Setup Communication**:
   - Each frontend project (AngularJS, Vue, ReactJS, Blazor) will make HTTP requests to the Web API project to fetch data or perform operations. For the first iteration of data, we will use some static weather data. 

6. **Configure Routes**:
   - We will define appropriate routes in our Web API project to handle incoming requests from the frontend projects.
   - We will implement controllers and actions to handle these routes and interact with our data layer.

7. **Web API Shared Models and Services**:
   - We will consider creating shared models and services that can be used across both the Web API project and the frontend projects. This will help in maintaining consistency and reducing duplication of code.

8. **Authentication and Authorization (Optional)**:
   - Implement authentication and authorization mechanisms in Web API project if required (final version should).

9. **Testing and Debugging**:
   - Test the communication between the frontend projects and the Web API project.
   - Debug any issues that arise during development.

10. **Deployment**:
    - Deploy the Web API project and frontend projects to the desired hosting environment. Ensure that all projects are configured correctly for production.

11. **Continuous Integration and Continuous Deployment (CI/CD)**:
    - Set up CI/CD pipelines to automate the build and deployment process for your solution.


### Project Development Steps - Phase 2:

While this workflow may change, the steps I am taking to conclude all aspects of the project development are as follows:

1. **Update Class Library**: Update ASP.NET Core Class Library project and solution parts we want to use across all applications, such as Constants, Enums, Helpers, etc.
   
2. **Update Web API Project**: Update ASP.NET Core Web API project and solution. This project will serve as the backend API that the frontend projects will communicate with.

3. **Update Shared Assets Project**: Update new ASP.NET Core project and solution that will handle common, static, assets and resources, shared across all applications. This project will serve as the resource project with all HTML, CSS, JS, Images and other creative all projects will use to carry the same theme, look and feel across applications.

4. **Add All Frontend Projects, Assets Projects & Web API to jSilvestri.com BETA v2024 Web API Demo Collection Soluions**:
   - Clone all projects and add them to the jSilvestri.com BETA v2024 Web API Demo Collection project for full access and testing of all projects in one, unified, location.

5. **Setup Communication**:
   - Each frontend project (AngularJS, Vue, ReactJS, Blazor) will make HTTP requests to the Web API project to fetch data or perform operations. The final version will access real-time weather data from one or more weather APIs available today.
   - Ensure that CORS (Cross-Origin Resource Sharing) is properly configured in the Web API project to allow requests from the frontend projects.

6. **Configure Routes**:
   - We will define appropriate routes in our Web API project to handle incoming requests from the frontend projects.
   - We will implement controllers and actions to handle these routes and interact with our data layer.

7. **Shared Models and Services**:
   - We will consider creating shared models and services in their own project, as opposed to housing them in the Web API project that can be used across both the Web API project and the frontend projects. This will help in maintaining consistency and reducing duplication of code.
   - An eventual version of this approach will leverage a structure where we have specific repositories for each service along with a generic repository to handle common CRUD operations, following a design pattern like the Repository Pattern.

8. **Authentication and Authorization (Optional)**:
   - We will use JWT (JSON Web Tokens) for authentication and role-based authorization.

9. **Testing and Debugging**:
   - Test the communication between the frontend projects and the Web API project.
   - Debug any issues that arise during development.

10. **Deployment**:
    - Deploy the Web API project and frontend projects to the desired hosting environment. Ensure that all projects are configured correctly for production.

11. **Continuous Integration and Continuous Deployment (CI/CD)**:
    - Set up CI/CD pipelines to automate the build and deployment process for your solution.

**Copyright © 2024 - All Rights Reserved by Jason Silvestri**
