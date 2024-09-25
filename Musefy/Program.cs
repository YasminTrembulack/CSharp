using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Musify.Models;
using Musify.Repositories;
using Musify.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(x =>
{	
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
     x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]!)),

        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],

        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"] 
    };
});


builder.Services.AddDbContext<MusifyContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQL-Server"))
);

builder.Services.AddScoped<IMusicRepository, MusicInfoRepositoryService>();
builder.Services.AddScoped<IMusicPiecesRepository, MusicPiecesRepositoryService>();
builder.Services.AddScoped<IUserRepository, UserReposritoryService>();
builder.Services.AddScoped<IMusicUploadService, DefaultMusicUploadService>();
builder.Services.AddSingleton<FileUploadRequestQueueService>();
builder.Services.AddHostedService<UploadBackgroundService>();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();