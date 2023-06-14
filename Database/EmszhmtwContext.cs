using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ORM_00.Database;

public partial class EmszhmtwContext : DbContext
{
    public EmszhmtwContext()
    {
    }

    public EmszhmtwContext(DbContextOptions<EmszhmtwContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Documentaccordingtogost> Documentaccordingtogosts { get; set; }

    public virtual DbSet<Documentsduringstage> Documentsduringstages { get; set; }

    public virtual DbSet<Finaldocument> Finaldocuments { get; set; }

    public virtual DbSet<Gostform> Gostforms { get; set; }

    public virtual DbSet<Okp> Okps { get; set; }

    public virtual DbSet<Roleuser> Roleusers { get; set; }

    public virtual DbSet<Stage> Stages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=horton.db.elephantsql.com; Database=emszhmtw; Username=emszhmtw; Password=7cKGKMgyVmLZcGsfIbHhTZZU7ukFag3e");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("btree_gin")
            .HasPostgresExtension("btree_gist")
            .HasPostgresExtension("citext")
            .HasPostgresExtension("cube")
            .HasPostgresExtension("dblink")
            .HasPostgresExtension("dict_int")
            .HasPostgresExtension("dict_xsyn")
            .HasPostgresExtension("earthdistance")
            .HasPostgresExtension("fuzzystrmatch")
            .HasPostgresExtension("hstore")
            .HasPostgresExtension("intarray")
            .HasPostgresExtension("ltree")
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("pg_trgm")
            .HasPostgresExtension("pgcrypto")
            .HasPostgresExtension("pgrowlocks")
            .HasPostgresExtension("pgstattuple")
            .HasPostgresExtension("tablefunc")
            .HasPostgresExtension("unaccent")
            .HasPostgresExtension("uuid-ossp")
            .HasPostgresExtension("xml2");

        modelBuilder.Entity<Documentaccordingtogost>(entity =>
        {
            entity.HasKey(e => e.Iddocument).HasName("documentaccordingtogost_pk");

            entity.ToTable("documentaccordingtogost");

            entity.Property(e => e.Iddocument)
                .ValueGeneratedNever()
                .HasColumnName("iddocument");
            entity.Property(e => e.Documents).HasColumnName("documents");
            entity.Property(e => e.Idstage).HasColumnName("idstage");
            entity.Property(e => e.Regulatorygost).HasColumnName("regulatorygost");

            entity.HasOne(d => d.IddocumentNavigation).WithOne(p => p.Documentaccordingtogost)
                .HasForeignKey<Documentaccordingtogost>(d => d.Iddocument)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("documentaccordingtogost_fk_1");

            entity.HasOne(d => d.IdstageNavigation).WithMany(p => p.Documentaccordingtogosts)
                .HasForeignKey(d => d.Idstage)
                .HasConstraintName("documentaccordingtogost_fk");
        });

        modelBuilder.Entity<Documentsduringstage>(entity =>
        {
            entity.HasKey(e => e.Iddocument).HasName("documentsduringstage_pk");

            entity.ToTable("documentsduringstage");

            entity.Property(e => e.Iddocument)
                .ValueGeneratedNever()
                .HasColumnName("iddocument");
            entity.Property(e => e.Documents).HasColumnName("documents");
            entity.Property(e => e.Formatdocument)
                .HasColumnType("character varying")
                .HasColumnName("formatdocument");
            entity.Property(e => e.Idstage).HasColumnName("idstage");
            entity.Property(e => e.Regulatorygost).HasColumnName("regulatorygost");

            entity.HasOne(d => d.IdstageNavigation).WithMany(p => p.Documentsduringstages)
                .HasForeignKey(d => d.Idstage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("documentsduringstage_fk");
        });

        modelBuilder.Entity<Finaldocument>(entity =>
        {
            entity.HasKey(e => e.Iddocument).HasName("finaldocuments_pk");

            entity.ToTable("finaldocuments");

            entity.Property(e => e.Iddocument)
                .ValueGeneratedNever()
                .HasColumnName("iddocument");
            entity.Property(e => e.Documents).HasColumnName("documents");
            entity.Property(e => e.Idstage).HasColumnName("idstage");
            entity.Property(e => e.Regulatorygost).HasColumnName("regulatorygost");

            entity.HasOne(d => d.IddocumentNavigation).WithOne(p => p.Finaldocument)
                .HasForeignKey<Finaldocument>(d => d.Iddocument)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("finaldocuments_fk_1");

            entity.HasOne(d => d.IdstageNavigation).WithMany(p => p.Finaldocuments)
                .HasForeignKey(d => d.Idstage)
                .HasConstraintName("finaldocuments_fk");
        });

        modelBuilder.Entity<Gostform>(entity =>
        {
            entity.HasKey(e => e.Idgostform).HasName("gostform_pk");

            entity.ToTable("gostform");

            entity.Property(e => e.Idgostform)
                .ValueGeneratedNever()
                .HasColumnName("idgostform");
            entity.Property(e => e.Formdocument).HasColumnName("formdocument");
            entity.Property(e => e.Idstage).HasColumnName("idstage");
        });

        modelBuilder.Entity<Okp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("okp_pk");

            entity.ToTable("okp");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Namecomponent).HasColumnName("namecomponent");
            entity.Property(e => e.Regulatorydocument).HasColumnName("regulatorydocument");
        });

        modelBuilder.Entity<Roleuser>(entity =>
        {
            entity.HasKey(e => e.Idrole).HasName("roleuser_pk");

            entity.ToTable("roleuser");

            entity.Property(e => e.Idrole)
                .ValueGeneratedNever()
                .HasColumnName("idrole");
            entity.Property(e => e.Rolename).HasColumnName("rolename");
        });

        modelBuilder.Entity<Stage>(entity =>
        {
            entity.HasKey(e => e.Idstage).HasName("stages_pk");

            entity.ToTable("stages");

            entity.Property(e => e.Idstage)
                .ValueGeneratedNever()
                .HasColumnName("idstage");
            entity.Property(e => e.Endday).HasColumnName("endday");
            entity.Property(e => e.Idokp).HasColumnName("idokp");
            entity.Property(e => e.Numberofproducts).HasColumnName("numberofproducts");
            entity.Property(e => e.Numberstage).HasColumnName("numberstage");
            entity.Property(e => e.Stagename).HasColumnName("stagename");
            entity.Property(e => e.Startday).HasColumnName("startday");

            entity.HasOne(d => d.IdokpNavigation).WithMany(p => p.Stages)
                .HasForeignKey(d => d.Idokp)
                .HasConstraintName("stages_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("user_pk");

            entity.ToTable("User");

            entity.Property(e => e.Iduser)
                .ValueGeneratedNever()
                .HasColumnName("iduser");
            entity.Property(e => e.Dataregistory).HasColumnName("dataregistory");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Idrole).HasColumnName("idrole");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(100)
                .HasColumnName("patronymic");
            entity.Property(e => e.Userlogin).HasColumnName("userlogin");
            entity.Property(e => e.Userpassword).HasColumnName("userpassword");
        });
        modelBuilder.HasSequence<int>("documentaccordingtogost_iddocument_seq");
        modelBuilder.HasSequence<int>("documentsduringstage_iddocument_seq");
        modelBuilder.HasSequence<int>("finaldocuments_iddocument_seq");
        modelBuilder.HasSequence<int>("gostform_idgostform_seq");
        modelBuilder.HasSequence<int>("okp_id_seq");
        modelBuilder.HasSequence("order_seq");
        modelBuilder.HasSequence("role_seq");
        modelBuilder.HasSequence<int>("stages_id_seq");
        modelBuilder.HasSequence("user_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
