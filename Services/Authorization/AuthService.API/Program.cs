using AuthService.API.Extensions;
using AuthService.Infrastructure.Extensions;
using AuthService.Usecase.Extensions;
using IdentityServer4.Stores;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureIdentityServer4();
builder.Services.ConfigureDbContext(builder);
builder.Services.ConfigureMapper();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureUsecases();
builder.Services.ConfigureLogging();
builder.Services.ConfigureCors();

//builder.Services.AddScoped<IClientStore, CustomClientStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseIdentityServer();

app.MapControllers();

app.Run();
