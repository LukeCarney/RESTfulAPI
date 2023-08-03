using RESTfulAPI;
using System;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Infrastructure.IServices;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


var configuration = builder.Configuration;

builder.Services.Configure<ServiceNameOptions>(configuration.GetSection(ServiceNameOptions.Key));

builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    object value = options.UseSqlServer(configuration.GetConnectionString("Default"), sqlServerOptions =>
    {
        sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 4,
            maxRetryDelay: TimeSpan.FromDays(1),
            errorNumbersToAdd: Array.Empty<int>());
    });



});
builder.Services.AddSingleton<IConfiguration>(provider => configuration);

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
