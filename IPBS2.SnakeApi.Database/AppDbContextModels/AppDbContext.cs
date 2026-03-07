using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IPBS2.SnakeApi.Database.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Snake> Snakes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Snake;User Id=sa;Password=sasa@123;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Snake>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Snakes__3214EC07BBD8FA34");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EngName).HasMaxLength(200);
            entity.Property(e => e.IsDanger).HasMaxLength(10);
            entity.Property(e => e.IsPoison).HasMaxLength(10);
            entity.Property(e => e.Mmname)
                .HasMaxLength(200)
                .HasColumnName("MMName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
