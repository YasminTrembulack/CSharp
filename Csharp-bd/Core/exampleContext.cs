using Microsoft.EntityFrameworkCore;

using Csharp_bd.Core.Mapping;

using Csharp_bd.Domain.Models;

namespace Csharp_bd.Core;

public partial class exampleContext : DbContext
{
    public exampleContext() {}

    public exampleContext(DbContextOptions<exampleContext> options)
         : base(options)
    {}
    public virtual DbSet<Cliente> ClienteList { get; set; }
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"Data Source=CA-C-0064W\SQLEXPRESS;Initial Catalog=example; Integrated Security=True; Trust Server Certificate=True");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteClassMap());
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
