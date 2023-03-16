using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cgi.Appmar.Web.Models;

public partial class AppmarContext : DbContext
{
    public AppmarContext()
    {
    }

    public AppmarContext(DbContextOptions<AppmarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactType> ContactTypes { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VersselStatus> VersselStatuses { get; set; }

    public virtual DbSet<VersselType> VersselTypes { get; set; }

    public virtual DbSet<Vessel> Vessels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PT-L163963;Database=appmar;Trusted_Connection=True; Integrated Security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacts__3214EC0731A93242");

            entity.Property(e => e.Value).HasMaxLength(150);

            entity.HasOne(d => d.ContactType).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ContactTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_contacts_contacttypes");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ContactCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_contacts_usersI");

            entity.HasOne(d => d.UpdateByNavigation).WithMany(p => p.ContactUpdateByNavigations)
                .HasForeignKey(d => d.UpdateBy)
                .HasConstraintName("fk_contacts_usersII");
        });

        modelBuilder.Entity<ContactType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactT__3214EC0733EB123B");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC07EE7CE0CB");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07301C04AE");

            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC073EF35F1E");

            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.PasswordHash).HasMaxLength(150);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_usersI");

            entity.HasOne(d => d.UpdateByNavigation).WithMany(p => p.InverseUpdateByNavigation)
                .HasForeignKey(d => d.UpdateBy)
                .HasConstraintName("fk_users_usersII");
        });

        modelBuilder.Entity<VersselStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VersselS__3214EC07D830C20A");

            entity.ToTable("VersselStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<VersselType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VersselT__3214EC0765B36853");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Vessel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vessels__3214EC07152D7AE7");

            entity.Property(e => e.BreadthItc).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.DeadWeightTons).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.DepthItc).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Former).HasMaxLength(200);
            entity.Property(e => e.FromRegistry).HasMaxLength(100);
            entity.Property(e => e.FullLoadDisplacement).HasMaxLength(100);
            entity.Property(e => e.GrossTonnage).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.HullIdentificationNumber).HasMaxLength(100);
            entity.Property(e => e.HullMaterial).HasMaxLength(100);
            entity.Property(e => e.LengthItc).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.LengthOvehal).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.LightShipDisplacement).HasMaxLength(100);
            entity.Property(e => e.MainEngineBuilder).HasMaxLength(200);
            entity.Property(e => e.MainEngineFuelType).HasMaxLength(100);
            entity.Property(e => e.MainEnginesStrokeType).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NegTonnage).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.NoAndTypeOfEngine).HasMaxLength(200);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.PlaceBuilt).HasMaxLength(100);
            entity.Property(e => e.PretendedAreaOfNavigation).HasMaxLength(100);
            entity.Property(e => e.PreviousFlag).HasMaxLength(100);
            entity.Property(e => e.RegistrationPort).HasMaxLength(200);
            entity.Property(e => e.RegistryNumber).HasMaxLength(100);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.TotalPowerKw).HasMaxLength(100);

            entity.HasOne(d => d.VesselStatus).WithMany(p => p.Vessels)
                .HasForeignKey(d => d.VesselStatusId)
                .HasConstraintName("fk_vessels_vesselstatus");

            entity.HasOne(d => d.VesselType).WithMany(p => p.Vessels)
                .HasForeignKey(d => d.VesselTypeId)
                .HasConstraintName("fk_vessels_vesseltypes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
