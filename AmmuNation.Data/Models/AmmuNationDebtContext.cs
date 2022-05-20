// <copyright file="AmmuNationDebtContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace AmmuNation.Data.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    /// <summary>
    /// Ammunation debt context.
    /// </summary>
    public partial class AmmuNationDebtContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AmmuNationDebtContext"/> class.
        /// </summary>
        public AmmuNationDebtContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AmmuNationDebtContext"/> class.
        /// </summary>
        /// <param name="options">options.</param>
        public AmmuNationDebtContext(DbContextOptions<AmmuNationDebtContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets manufacturers.
        /// </summary>
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        /// <summary>
        /// Gets or sets models.
        /// </summary>
        public virtual DbSet<Model> Models { get; set; }

        /// <summary>
        /// Lazy load.
        /// </summary>
        /// <param name="optionsBuilder">options.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename= |DataDirectory|\\AmmuNationDB.mdf;Integrated Security=True");
            }
        }

        /// <summary>
        /// Model creating.
        /// </summary>
        /// <param name="modelBuilder">builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer");

                entity.Property(e => e.ManufacturerId)
                    .ValueGeneratedNever()
                    .HasColumnName("manufacturer_id");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nev");

                entity.Property(e => e.SzarmazasiHely)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("szarmazasi_hely");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("Model");

                entity.Property(e => e.ModelId)
                    .ValueGeneratedNever()
                    .HasColumnName("model_id");

                entity.Property(e => e.Kaliber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("kaliber");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Nev)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nev");

                entity.Property(e => e.Pontossag).HasColumnName("pontossag");

                entity.Property(e => e.Selected).HasColumnName("selected");

                entity.Property(e => e.Stabilitas).HasColumnName("stabilitas");

                entity.Property(e => e.Suly).HasColumnName("suly");

                entity.Property(e => e.Tipus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tipus");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK__Model__manufactu__25869641");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
