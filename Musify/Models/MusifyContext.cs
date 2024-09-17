using Microsoft.EntityFrameworkCore;
using Musify.Models;

namespace Musify.Models;

public class MusicContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<MusicInfo> MusicInfos { get; set; }
    public DbSet<VideoClip> VideoClips { get; set; }
    public DbSet<Music> Musics { get; set; }
    public DbSet<Genre> Genres { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<MusicInfo>()
            .HasMany(mi => mi.Genres)
            .WithMany(g => g.Musics)
            .UsingEntity(j => j.ToTable("MusicGenre")); 

        builder.Entity<Genre>()
            .HasMany(g => g.Musics)
            .WithMany(mi => mi.Genres)
            .UsingEntity(j => j.ToTable("MusicGenre")); 

        builder.Entity<MusicInfo>()
            .HasOne<Music>()              
            .WithMany()                  
            .HasForeignKey(mi => mi.Music) 
            .OnDelete(DeleteBehavior.Cascade); 

        builder.Entity<MusicInfo>()
            .HasOne<VideoClip>()         
            .WithMany()                  
            .HasForeignKey(mi => mi.VideoClip) 
            .OnDelete(DeleteBehavior.Cascade); 
    }
}