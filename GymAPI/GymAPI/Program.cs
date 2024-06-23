using Gym.BLL_EF;
using Gym.DAL;
using Gym.Model.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("MSSQLConnection")
                ?? throw new InvalidOperationException("Connection string not found");

builder.Services.AddBLL();
builder.Services.AddDAL(connectionString);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "GymAppClient",
        policy =>
        {
            policy.WithOrigins(builder.Configuration.GetSection("AppConfig:Audience").Value!)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
});

var app = builder.Build();
app.UseCors("GymAppClient");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapIdentityApi<AppUser>();

app.Run();
