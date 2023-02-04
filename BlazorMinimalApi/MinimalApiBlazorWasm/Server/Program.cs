using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Server.Custom;
using Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c=> 
{
    c.SwaggerDoc("v1", new OpenApiInfo
    { 
        Title ="Minimal API - Blazor Wasm - Classlib",
        Description="Projeto 3 Camadas - Simple Post",
        Contact= new OpenApiContact() { Name= "Washington Gomes", Email="oktuga@gmail.com", Url= new Uri("https://www.linkedin.com/in/criarsite/")},
        License= new OpenApiLicense() {Name="MIT", Url= new Uri("https://opensource.org/license/MIT")}

    });
});

builder.Services.AddDbContext<Contexto>(options =>
{ 
  options.UseSqlite("Data Source=./Data/MiniCourseDb.db");
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

 




app.ConfigureCustomRoutes();

app.Run();
 