using Microsoft.AspNetCore.Authentication;
using NewNexum.Profile.Api;
using NewNexum.WebApi.Core.Authentication.Claims;
using NewNexum.WebApi.Core.Configurations;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.InstallServices(builder.Configuration,
    NewNexum.WebApi.Core.AssemblyReference.Assembly,
    AssemblyReference.Assembly
);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("All");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
