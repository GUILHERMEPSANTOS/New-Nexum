using NewNexum.Profile.Api.Configurations;
using NewNexum.WebApi.Core.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAuthConfiguration(builder.Configuration);
builder.Services.AddCorsConfiguration();

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