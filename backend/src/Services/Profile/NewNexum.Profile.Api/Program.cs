using Microsoft.EntityFrameworkCore;
using NewNexum.Profile.Api.Configurations;
using NewNexum.Profile.Persistence;
using NewNexum.WebApi.Core.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAuthConfiguration(builder.Configuration);
builder.Services.AddCorsConfiguration();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(""));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCorsConfiguration();

app.UseRouting();

app.UseAuthConfiguration();

app.MapControllers();

app.Run();
