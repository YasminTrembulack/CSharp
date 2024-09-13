using Microsoft.EntityFrameworkCore;

using PokeAPI.Models;
// using PokeAPI.Repositories;
// using PokeAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PokedexContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQL-Server"))
);

// builder.Services.AddScoped<ITeamRepository, TeamRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();