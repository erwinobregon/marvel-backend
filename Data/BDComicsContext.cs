using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiMarvel.Data
{
    public partial class BDComicsContext : DbContext
    {
        public BDComicsContext()
        {
        }

        public BDComicsContext(DbContextOptions<BDComicsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comic> Comics { get; set; } = null!;
        public virtual DbSet<FavoriteComic> FavoriteComics { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

             
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comic>(entity =>
            {
                entity.ToTable("Comic");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Path).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<FavoriteComic>(entity =>
            {
                entity.ToTable("FavoriteComic");

                entity.HasOne(d => d.Comic)
                    .WithMany(p => p.FavoriteComics)
                    .HasForeignKey(d => d.ComicId)
                    .HasConstraintName("FK_FavoriteComic_Comic");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoriteComics)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_FavoriteComic_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Identification).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
