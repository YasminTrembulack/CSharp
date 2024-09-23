using Microsoft.EntityFrameworkCore;

namespace Musify.Models;

public class MusifyContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<Music> Musics { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<MusicGenre> MusicGenres { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Music>()
            .HasMany<MusicGenre>()
            .WithOne(mg => mg.Music);

        builder.Entity<Genre>()
            .HasMany<MusicGenre>()
            .WithOne(mg => mg.Genre);

        builder.Entity<Music>()
            .HasOne<User>()         
            .WithMany(); 

        builder.Entity<User>()
            .HasMany<Music>()         
            .WithOne(); 
    }
}