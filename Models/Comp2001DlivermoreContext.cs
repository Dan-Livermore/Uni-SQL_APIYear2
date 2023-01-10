using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CW2_TrailService.Models.DB;

namespace CW2_TrailService.Models;

public partial class Comp2001DlivermoreContext : DbContext
{
    public Comp2001DlivermoreContext()
    {
    }

    public Comp2001DlivermoreContext(DbContextOptions<Comp2001DlivermoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Creator> Creators { get; set; }

    public virtual DbSet<Detail> Details { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    public virtual DbSet<Trail> Trails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=COMP2001_DLivermore; User Id=DLivermore; Password=KnwS907+; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("pk_Account");

            entity.ToTable("Account", "CW2");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Creator>(entity =>
        {
            entity.HasKey(e => e.CreatorId).HasName("pk_Creator");

            entity.ToTable("Creator", "CW2");

            entity.Property(e => e.CreatorId).HasColumnName("Creator_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TrailId).HasColumnName("Trail_ID");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Creators)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("fk_Creator2");

            entity.HasOne(d => d.Trail).WithMany(p => p.Creators)
                .HasForeignKey(d => d.TrailId)
                .HasConstraintName("fk_Creator1");
        });

        modelBuilder.Entity<Detail>(entity =>
        {
            entity.HasKey(e => e.DetailsId).HasName("pk_details");

            entity.ToTable("Details", "CW2");

            entity.Property(e => e.DetailsId).HasColumnName("Details_ID");
            entity.Property(e => e.DistanceMiles).HasColumnName("Distance (miles)");
            entity.Property(e => e.ElevationMeters).HasColumnName("Elevation (meters)");
            entity.Property(e => e.NumberOfMarkers).HasColumnName("Number of Markers");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.PlaceId).HasName("pk_Place");

            entity.ToTable("Place", "CW2");

            entity.Property(e => e.PlaceId).HasColumnName("Place_ID");
            entity.Property(e => e.Area)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DetailsId).HasColumnName("Details_ID");
            entity.Property(e => e.Difficulty)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RouteType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Route_Type");

            entity.HasOne(d => d.Details).WithMany(p => p.Places)
                .HasForeignKey(d => d.DetailsId)
                .HasConstraintName("fk_Place");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.HasKey(e => e.SiteId).HasName("pk_Site");

            entity.ToTable("Site", "CW2");

            entity.Property(e => e.SiteId).HasColumnName("Site_ID");
            entity.Property(e => e.PlaceId).HasColumnName("Place_ID");
            entity.Property(e => e.TrailId).HasColumnName("Trail_ID");

            entity.HasOne(d => d.Place).WithMany(p => p.Sites)
                .HasForeignKey(d => d.PlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Site2");

            entity.HasOne(d => d.Trail).WithMany(p => p.Sites)
                .HasForeignKey(d => d.TrailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Site1");
        });

        modelBuilder.Entity<Trail>(entity =>
        {
            entity.HasKey(e => e.TrailId).HasName("pk_trail");

            entity.ToTable("Trail", "CW2", tb => tb.HasTrigger("AddPhoto"));

            entity.Property(e => e.TrailId).HasColumnName("Trail_ID");
            entity.Property(e => e.Photos)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TrailDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Trail_Description");
            entity.Property(e => e.TrailName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Trail_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<CW2_TrailService.Models.DB.InsertOutput> InsertOutput { get; set; } = default!;

    public DbSet<CW2_TrailService.Models.DB.DeleteOutput> DeleteOutput { get; set; } = default!;
}
