using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Olivia.Entities;
using Olivia.Repositories;
using Olivia.Services;

var builder = WebApplication.CreateBuilder(args);

// add database options
builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection("DatabaseOptions"));

// configure swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddApplicationDbContext();
builder.Services.AddOliviaRepositories();
builder.Services.AddOliviaServices();

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
