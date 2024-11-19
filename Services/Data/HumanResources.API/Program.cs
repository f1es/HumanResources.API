using HumanResources.API.Extensions;
using HumanResources.API.Middlewares;
using HumanResources.Infrastructure.Context;
using HumanResources.Infrastructure.Extensions;
using HumanResources.Usecase.Extensions;
using HumanResources.Usecase.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

LogManager.Setup().LoadConfigurationFromFile("/nlog.config");

builder.Services.ConfigureControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureLogger();
builder.Services.ConfigureWebLogger();
builder.Services.ConfigureMapperProfiles();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();
builder.Services.ConfigureValidators();
builder.Services.ConfigureCors();
builder.Services.ConfigureDbContext(builder);
builder.Services.ConfigureAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseWebSockets();
app.UseMiddleware<ExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<WebSocketMiddleware>();

app.Run();
