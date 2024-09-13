using Microsoft.EntityFrameworkCore;

namespace PokeAPI.Models;

public class PokedexContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<Stats> Stats { get; set; }
    public DbSet<Type> Types { get; set; }
    public DbSet<TypeEffect> TypeEffects { get; set; }
    public DbSet<Generation> Generations { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Type

        builder.Entity<Type>()
            .HasMany<Pokemon>()
            .WithOne(p => p.MainType)
            .OnDelete(DeleteBehavior.Restrict);
    
        builder.Entity<Type>()
            .HasMany<Pokemon>()
            .WithOne(p => p.SecondType)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Type>()
            .HasMany<TypeEffect>()
            .WithOne(te => te.Attacker)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Type>()
            .HasMany<TypeEffect>()
            .WithOne(te => te.Receiver)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region Stats

        builder.Entity<Stats>()
            .HasOne<Pokemon>()
            .WithOne()
            .HasForeignKey<Pokemon>(p => p.MaxStatsId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Entity<Stats>()
            .HasOne<Pokemon>()
            .WithOne()
            .HasForeignKey<Pokemon>(p => p.BaseStatsId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Stats>()
            .HasOne<Pokemon>()
            .WithOne()
            .HasForeignKey<Pokemon>(p => p.MinStatsId)
            .OnDelete(DeleteBehavior.Restrict);
        
        #endregion

        builder.Entity<Generation>()
            .HasMany<Pokemon>()
            .WithOne(p => p.IntroducedIn)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Pokemon>()
            .HasOne<Pokemon>()
            .WithOne()
            .HasForeignKey<Pokemon>(p => p.EvolvesFrom)
            .OnDelete(DeleteBehavior.Restrict);
    }
}