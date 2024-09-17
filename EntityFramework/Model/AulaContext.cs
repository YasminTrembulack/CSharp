using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Model;

public partial class AulaContext : DbContext
{
    public AulaContext()
    {
    }

    public AulaContext(DbContextOptions<AulaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipamento> Equipamentos { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<EventoEquipamento> EventoEquipamentos { get; set; }

    public virtual DbSet<EventoPessoa> EventoPessoas { get; set; }

    public virtual DbSet<Pessoa> Pessoas { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-001YU\\SQLEXPRESS;Initial Catalog=Aula;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipamento>(entity =>
        {
            entity.HasKey(e => e.Idequipamento).HasName("PK__Equipame__33802392F336EF72");

            entity.ToTable("Equipamento");

            entity.Property(e => e.Idequipamento)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("IDEquipamento");
            entity.Property(e => e.Idsala)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("IDSala");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdsalaNavigation).WithMany(p => p.Equipamentos)
                .HasForeignKey(d => d.Idsala)
                .HasConstraintName("FK__Equipamen__IDSal__3C69FB99");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Idevento).HasName("PK__Evento__E6305302F5EBBE97");

            entity.ToTable("Evento");

            entity.Property(e => e.Idevento)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("IDEvento");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DtHrFim).HasColumnType("datetime");
            entity.Property(e => e.DtHrInicio).HasColumnType("datetime");
            entity.Property(e => e.Idsala)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("IDSala");

            entity.HasOne(d => d.IdsalaNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.Idsala)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Evento__IDSala__398D8EEE");
        });

        modelBuilder.Entity<EventoEquipamento>(entity =>
        {
            entity.HasKey(e => e.IdeventoEquipamento).HasName("PK__EventoEq__B904D924B2266085");

            entity.ToTable("EventoEquipamento");

            entity.Property(e => e.IdeventoEquipamento)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("IDEventoEquipamento");
            entity.Property(e => e.Idequipamento)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("IDEquipamento");
            entity.Property(e => e.Idevento)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("IDEvento");

            entity.HasOne(d => d.IdequipamentoNavigation).WithMany(p => p.EventoEquipamentos)
                .HasForeignKey(d => d.Idequipamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventoEqu__IDEqu__45F365D3");

            entity.HasOne(d => d.IdeventoNavigation).WithMany(p => p.EventoEquipamentos)
                .HasForeignKey(d => d.Idevento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventoEqu__IDEve__44FF419A");
        });

        modelBuilder.Entity<EventoPessoa>(entity =>
        {
            entity.HasKey(e => e.IdeventoPessoa).HasName("PK__EventoPe__7B7723B99226B442");

            entity.ToTable("EventoPessoa");

            entity.Property(e => e.IdeventoPessoa)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("IDEventoPessoa");
            entity.Property(e => e.Idevento)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("IDEvento");
            entity.Property(e => e.Idpessoa)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("IDPessoa");
            entity.Property(e => e.PapelEvento)
                .HasMaxLength(75)
                .IsUnicode(false);

            entity.HasOne(d => d.IdeventoNavigation).WithMany(p => p.EventoPessoas)
                .HasForeignKey(d => d.Idevento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventoPes__IDEve__412EB0B6");

            entity.HasOne(d => d.IdpessoaNavigation).WithMany(p => p.EventoPessoas)
                .HasForeignKey(d => d.Idpessoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventoPes__IDPes__4222D4EF");
        });

        modelBuilder.Entity<Pessoa>(entity =>
        {
            entity.HasKey(e => e.Idpessoa).HasName("PK__Pessoa__970F52C6483D5F43");

            entity.ToTable("Pessoa");

            entity.Property(e => e.Idpessoa)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("IDPessoa");
            entity.Property(e => e.Categoria)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.Idsala).HasName("PK__Sala__C6F3BA0FFD3C91A7");

            entity.ToTable("Sala");

            entity.Property(e => e.Idsala)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("IDSala");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
