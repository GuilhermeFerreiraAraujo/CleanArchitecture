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

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<ActivityStatus> ActivityStatuses { get; set; }

    public virtual DbSet<ActivitySubType> ActivitySubTypes { get; set; }

    public virtual DbSet<ActivityType> ActivityTypes { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Approval> Approvals { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactType> ContactTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<DocumentTypeVesselType> DocumentTypeVesselTypes { get; set; }

    public virtual DbSet<Entity> Entities { get; set; }

    public virtual DbSet<EntityType> EntityTypes { get; set; }

    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<FeeChargedStatus> FeeChargedStatuses { get; set; }

    public virtual DbSet<FeeGroup> FeeGroups { get; set; }

    public virtual DbSet<Feechaged> Feechageds { get; set; }

    public virtual DbSet<Feetype> Feetypes { get; set; }

    public virtual DbSet<Lookup> Lookups { get; set; }

    public virtual DbSet<LookupEntityValue> LookupEntityValues { get; set; }

    public virtual DbSet<LookupValue> LookupValues { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<OrganizationType> OrganizationTypes { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolesPermission> RolesPermissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VersselStatus> VersselStatuses { get; set; }

    public virtual DbSet<VersselType> VersselTypes { get; set; }

    public virtual DbSet<Vessel> Vessels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=appmar;Trusted_Connection=True; Integrated Security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activiti__3214EC0725687E33");

            entity.Property(e => e.CsrDocNum).HasMaxLength(200);
            entity.Property(e => e.RejectDesc).HasMaxLength(200);

            entity.HasOne(d => d.ActivitySubtype).WithMany(p => p.Activities)
                .HasForeignKey(d => d.ActivitySubtypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_activities_activitiessubtypes");

            entity.HasOne(d => d.ActivityType).WithMany(p => p.Activities)
                .HasForeignKey(d => d.ActivityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_activities_activitytype");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ActivityCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_activities_usersI");

            entity.HasOne(d => d.UpdateByNavigation).WithMany(p => p.ActivityUpdateByNavigations)
                .HasForeignKey(d => d.UpdateBy)
                .HasConstraintName("fk_activities_usersII");

            entity.HasOne(d => d.Vessel).WithMany(p => p.Activities)
                .HasForeignKey(d => d.VesselId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_activities_vessels");
        });

        modelBuilder.Entity<ActivityStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activity__3214EC0717FBB615");

            entity.ToTable("ActivityStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ActivitySubType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activity__3214EC073903B28B");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ActivityType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Activity__3214EC07247234B0");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3214EC0714ABC60C");

            entity.Property(e => e.Address1).HasMaxLength(200);
            entity.Property(e => e.Address2).HasMaxLength(200);
            entity.Property(e => e.Address3).HasMaxLength(200);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.PostalCode).HasMaxLength(100);

            entity.HasOne(d => d.Country).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_addresses_countries");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AddressCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_addresses_usersI");

            entity.HasOne(d => d.UpdateByNavigation).WithMany(p => p.AddressUpdateByNavigations)
                .HasForeignKey(d => d.UpdateBy)
                .HasConstraintName("fk_addresses_usersII");
        });

        modelBuilder.Entity<Approval>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Approval__3214EC07AA46094E");

            entity.Property(e => e.Comment).HasMaxLength(200);

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.Approvals)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("fk_approvals_users");

            entity.HasOne(d => d.Entity).WithMany(p => p.Approvals)
                .HasForeignKey(d => d.EntityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_approvals_entities");

            entity.HasOne(d => d.EntityType).WithMany(p => p.Approvals)
                .HasForeignKey(d => d.EntityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_approvals_entitytypes");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07010F9DCF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacts__3214EC076C8127B2");

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
            entity.HasKey(e => e.Id).HasName("PK__ContactT__3214EC076F8072BF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Countrie__3214EC07017AFAF7");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC07CAD7CA9D");

            entity.Property(e => e.DocPath).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UniqueTrackNumber).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DocumentCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_documents_usersI");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Documents)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("fk_documents_documenttypes");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.DocumentUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("fk_documents_usersII");

            entity.HasOne(d => d.Vessel).WithMany(p => p.Documents)
                .HasForeignKey(d => d.VesselId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_documents_vessels");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC075F230C37");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<DocumentTypeVesselType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DocumentTypeVesselType");

            entity.HasOne(d => d.DocumentType).WithMany()
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_documenttypeVesseltype_documenttype");

            entity.HasOne(d => d.VesselType).WithMany()
                .HasForeignKey(d => d.VesselTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_documenttypeVesseltype_vesseltype");
        });

        modelBuilder.Entity<Entity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Entities__3214EC0795C8DB1F");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<EntityType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EntityTy__3214EC0717A6AB61");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Fees__3214EC072223BCBA");

            entity.Property(e => e.Value).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.FeeGroup).WithMany(p => p.Fees)
                .HasForeignKey(d => d.FeeGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fees_feegroups");

            entity.HasOne(d => d.FeeType).WithMany(p => p.Fees)
                .HasForeignKey(d => d.FeeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fees_feetyps");
        });

        modelBuilder.Entity<FeeChargedStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FeeCharg__3214EC074F67011D");

            entity.ToTable("FeeChargedStatus");

            entity.Property(e => e.Dsc).HasMaxLength(1);
            entity.Property(e => e.Name).HasMaxLength(1);
        });

        modelBuilder.Entity<FeeGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FeeGroup__3214EC07893F87AA");

            entity.Property(e => e.Dsc).HasMaxLength(1);
            entity.Property(e => e.Name).HasMaxLength(1);
        });

        modelBuilder.Entity<Feechaged>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feechage__3214EC07722443E0");

            entity.ToTable("Feechaged");

            entity.HasOne(d => d.FeeStatus).WithMany(p => p.Feechageds)
                .HasForeignKey(d => d.FeeStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_feechaged_feechargedstatus");
        });

        modelBuilder.Entity<Feetype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feetypes__3214EC07243DB3AF");

            entity.Property(e => e.Dsc).HasMaxLength(1);
            entity.Property(e => e.Name).HasMaxLength(1);
        });

        modelBuilder.Entity<Lookup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lookups__3214EC07E34A821C");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<LookupEntityValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LookupEn__3214EC0766AB58EB");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Value).HasMaxLength(100);

            entity.HasOne(d => d.EntityType).WithMany(p => p.LookupEntityValues)
                .HasForeignKey(d => d.EntityTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_lookupentityvalues_entitytypes");
        });

        modelBuilder.Entity<LookupValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LookupVa__3214EC07EFACB639");

            entity.Property(e => e.Value).HasMaxLength(200);

            entity.HasOne(d => d.Lookup).WithMany(p => p.LookupValues)
                .HasForeignKey(d => d.LookupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_lookupvalues_lookups");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Organiza__3214EC07406C2D0A");

            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.FiscalNumber).HasMaxLength(100);
            entity.Property(e => e.Imo).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.OrganizationCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_organizations_usersI");

            entity.HasOne(d => d.OrganizationType).WithMany(p => p.Organizations)
                .HasForeignKey(d => d.OrganizationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_organizations_organizationtypes");

            entity.HasOne(d => d.UpdateByNavigation).WithMany(p => p.OrganizationUpdateByNavigations)
                .HasForeignKey(d => d.UpdateBy)
                .HasConstraintName("fk_organizations_usersII");
        });

        modelBuilder.Entity<OrganizationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Organiza__3214EC0721B9E9CA");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC07171D5238");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(150);

            entity.HasOne(d => d.Category).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_permissions_categories");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07C78709D5");

            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<RolesPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolesPer__3214EC0789DDAB39");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolesPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rolespermissions_permissions");

            entity.HasOne(d => d.Role).WithMany(p => p.RolesPermissions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rolespermissions_roles");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0741A8EC5F");

            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.PasswordHash).HasMaxLength(150);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("fk_users_usersI");

            entity.HasOne(d => d.UpdateByNavigation).WithMany(p => p.InverseUpdateByNavigation)
                .HasForeignKey(d => d.UpdateBy)
                .HasConstraintName("fk_users_usersII");
        });

        modelBuilder.Entity<VersselStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VersselS__3214EC075F291709");

            entity.ToTable("VersselStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<VersselType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VersselT__3214EC071D5E3C19");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dsc).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Vessel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vessels__3214EC076F5DBE44");

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

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.VesselCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_vessels_usersI");

            entity.HasOne(d => d.UpdateByNavigation).WithMany(p => p.VesselUpdateByNavigations)
                .HasForeignKey(d => d.UpdateBy)
                .HasConstraintName("fk_vessels_usersII");

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
