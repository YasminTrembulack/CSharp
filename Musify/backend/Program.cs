using Microsoft.EntityFrameworkCore;

using Musify.Models;
using Musify.Repositories;
using Musify.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MusicContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQL-Server"))
);

builder.Services.AddScoped<IMusicRepository, MusicRepository>();
builder.Services.AddScoped<IMusicInfoRepository, MusicInfoRepository>();
builder.Services.AddScoped<IMusicUploadService, DefaultMusicUploadService>();
builder.Services.AddSingleton<FileUploadRequestQueueService>();
builder.Services.AddHostedService<UploadBackgroundService>();

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