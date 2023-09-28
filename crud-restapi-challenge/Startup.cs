using crud_restapi_challenge;
using crud_restapi_challenge.Dao;
using crud_restapi_challenge.Dao.Interfaces;
using crud_restapi_challenge.Repositories;
using crud_restapi_challenge.Repositories.Interfaces;
using crud_restapi_challenge.Services;
using crud_restapi_challenge.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Configure the database context
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IItemDao, ItemDao>();
        services.AddScoped<IItemService, ItemService>();

        // Register Swagger
        services.AddSwaggerGen(c =>{
            c.SwaggerDoc("v1", new OpenApiInfo{
                Title = "crud-restapi-challenge .NET",
                Version = "v1",
                Description = "My CRUD REST API Challenge .NET application for grad challenge 3"
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Configure error handling for production
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger();

        // Enable middleware to serve Swagger UI (HTML, JS, CSS, etc.).
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
        });

        // Configure routing, middleware, etc.
        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" }
            );
        });
    }
}