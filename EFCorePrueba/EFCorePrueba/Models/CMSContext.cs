using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCorePrueba.Models
{
    public partial class CMSContext : DbContext
    {
        public CMSContext()
        {
        }

        public CMSContext(DbContextOptions<CMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<ContentProperty> ContentProperty { get; set; }
        public virtual DbSet<ContentTaxonomy> ContentTaxonomy { get; set; }
        public virtual DbSet<ConversationContent> ConversationContent { get; set; }
        public virtual DbSet<DescriptionContent> DescriptionContent { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupType> GroupType { get; set; }
        public virtual DbSet<ImageContent> ImageContent { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PermissionRole> PermissionRole { get; set; }
        public virtual DbSet<PriceContent> PriceContent { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Taxonomy> Taxonomy { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-9DDA1MMG\\SQLEXPRESS;Initial Catalog=CMS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.IdParent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdType)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.InverseIdParentNavigation)
                    .HasForeignKey(d => d.IdParent)
                    .HasConstraintName("FK_Content_IdParent");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Content)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Content_IdType_Type");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Content)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Content_IdUser_User");
            });

            modelBuilder.Entity<ContentProperty>(entity =>
            {
                entity.HasKey(e => new { e.IdContent, e.IdProperty });

                entity.Property(e => e.IdContent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdProperty)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContentNavigation)
                    .WithMany(p => p.ContentProperty)
                    .HasForeignKey(d => d.IdContent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContentProperty_IdContent_Content");

                entity.HasOne(d => d.IdPropertyNavigation)
                    .WithMany(p => p.ContentProperty)
                    .HasForeignKey(d => d.IdProperty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContentProperty_IdProperty_Property");
            });

            modelBuilder.Entity<ContentTaxonomy>(entity =>
            {
                entity.HasKey(e => new { e.IdContent, e.IdTaxonomy });

                entity.Property(e => e.IdContent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdTaxonomy)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContentNavigation)
                    .WithMany(p => p.ContentTaxonomy)
                    .HasForeignKey(d => d.IdContent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContentTaxonomy_IdContent_Content");

                entity.HasOne(d => d.IdTaxonomyNavigation)
                    .WithMany(p => p.ContentTaxonomy)
                    .HasForeignKey(d => d.IdTaxonomy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContentTaxonomy_IdTaxonomy_Taxonomy");
            });

            modelBuilder.Entity<ConversationContent>(entity =>
            {
                entity.HasKey(e => e.IdContent);

                entity.Property(e => e.IdContent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.IdVisitor)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdVisitorNavigation)
                    .WithMany(p => p.ConversationContent)
                    .HasForeignKey(d => d.IdVisitor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConversationContent_IdVisitor_Visitor");
            });

            modelBuilder.Entity<DescriptionContent>(entity =>
            {
                entity.HasKey(e => e.IdContent);

                entity.Property(e => e.IdContent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2046)
                    .IsUnicode(false);

                entity.Property(e => e.IdType)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContentNavigation)
                    .WithOne(p => p.DescriptionContent)
                    .HasForeignKey<DescriptionContent>(d => d.IdContent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DescriptionContent_IdContent_Id");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupType>(entity =>
            {
                entity.HasKey(e => new { e.IdGroup, e.IdType });

                entity.Property(e => e.IdGroup)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IdType)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.GroupType)
                    .HasForeignKey(d => d.IdGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupType_IdGroup_Group");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.GroupType)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupType_IdType_Type");
            });

            modelBuilder.Entity<ImageContent>(entity =>
            {
                entity.HasKey(e => e.IdContent);

                entity.Property(e => e.IdContent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContentNavigation)
                    .WithOne(p => p.ImageContent)
                    .HasForeignKey<ImageContent>(d => d.IdContent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ImageContent_IdContent");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IdType)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Permission)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission_IdType_Type");
            });

            modelBuilder.Entity<PermissionRole>(entity =>
            {
                entity.HasKey(e => new { e.IdPermission, e.IdRole });

                entity.Property(e => e.IdPermission)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IdRole)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPermissionNavigation)
                    .WithMany(p => p.PermissionRole)
                    .HasForeignKey(d => d.IdPermission)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermissionRole_IdPermission_Permission");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.PermissionRole)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermissionRole_IdRole_Role");
            });

            modelBuilder.Entity<PriceContent>(entity =>
            {
                entity.HasKey(e => new { e.IdContent, e.IdType });

                entity.Property(e => e.IdContent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IdType)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdContentNavigation)
                    .WithMany(p => p.PriceContent)
                    .HasForeignKey(d => d.IdContent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PriceContent_IdContent_Content");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.PriceContent)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PriceContent_IdType_Type");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.IdParent)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IdType)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.InverseIdParentNavigation)
                    .HasForeignKey(d => d.IdParent)
                    .HasConstraintName("FK_Property_IdParent");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Property)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_IdType_Type");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IdParent)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IdType)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.InverseIdParentNavigation)
                    .HasForeignKey(d => d.IdParent)
                    .HasConstraintName("FK_Role_IdParent");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Role)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Type");
            });

            modelBuilder.Entity<Taxonomy>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IdParent)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IdType)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.InverseIdParentNavigation)
                    .HasForeignKey(d => d.IdParent)
                    .HasConstraintName("FK_Taxonomy_IdParent");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Taxonomy)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Taxonomy_IdType_Type");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IdVisitor)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdVisitorNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdVisitor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USer_IdVisitor_Email");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdRole });

                entity.Property(e => e.IdUser)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.IdRole)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_IdRole");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_IdUser_User");
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });
        }
    }
}
