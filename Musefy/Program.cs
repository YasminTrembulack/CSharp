using Microsoft.EntityFrameworkCore;

using Musify.Models;
using Musify.Repositories;
using Musify.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MusifyContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQL-Server"))
);

builder.Services.AddScoped<IMusicRepository, MusicInfoRepositoryService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowSpecificOrigins", policy  =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Content-Type");
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();