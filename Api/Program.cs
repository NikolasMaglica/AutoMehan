using Application.Services;
using Domain.Interface;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DbContextCl>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("konekcija"), sqlOptions =>
        sqlOptions.EnableRetryOnFailure()));
builder.Services.AddTransient<IBlogRepository, BlogRepository>();
builder.Services.AddTransient<IBlogService, BlogService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty; // Postavljanje Swagger UI na root
    });
}

app.MapControllers();
app.Run();