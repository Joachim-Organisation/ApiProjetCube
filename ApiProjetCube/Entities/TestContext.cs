using ApiProjetCube.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetCube.Entities
{
    public partial class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DocumentImage> DocumentImages { get; set; }
        public virtual DbSet<DocumentPdf> DocumentPdfs { get; set; }
        public virtual DbSet<MessageForum> MessagesForums { get; set; }
        public virtual DbSet<Ressource> Ressources { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SubjectForum> SubjectsForums { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentImage>(entity =>
            {
                entity.HasOne(d => d.Ressource)
                    .WithMany(p => p.DocumentImages)
                    .HasForeignKey(d => d.IdRessource)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_DocumentImages_Ressources");
            });

            modelBuilder.Entity<DocumentPdf>(entity =>
            {
                entity.HasOne(d => d.Ressource)
                    .WithMany(p => p.DocumentPdfs)
                    .HasForeignKey(d => d.IdRessource)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_DocumentPdfs_Ressources");
            });

            modelBuilder.Entity<MessageForum>(entity =>
            {
                entity.HasOne(d => d.Utilisateur)
                    .WithMany(p => p.MessagesForums)
                    .HasForeignKey(d => d.IdUtilisateur)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MessagesForums_Utilisateurs");
            });

            modelBuilder.Entity<Ressource>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Ressources)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Ressources_Categories");

                entity.HasOne(d => d.Utilisateur)
                    .WithMany(p => p.Ressources)
                    .HasForeignKey(d => d.IdUtilisateur)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Ressources_Utilisateurs");
            });

            modelBuilder.Entity<SubjectForum>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubjectsForums)
                    .HasForeignKey(d => d.IdCategorie)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SubjectsForums_Categories");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Utilisateurs)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Utilisateurs_Roles");
            });

         
        }
    }
}
