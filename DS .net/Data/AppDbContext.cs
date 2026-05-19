using Microsoft.EntityFrameworkCore;
using DS_.net.Models;

namespace DS_.net.Data
{
    public class AppDbContext : DbContext
    {
        // Les tables de la base de données
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-N7QPPPB\\SQLEXPRESS;Database=GestionScolaireDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ajouter un admin par défaut
            modelBuilder.Entity<Utilisateur>().HasData(
                new Utilisateur
                {
                    Id = 1,
                    Login = "Nourchene",
                    MotDePasse = "admin123",
                    Role = "Admin"
                },
                new Utilisateur
                {
                    Id = 2,
                    Login = "prof",
                    MotDePasse = "prof123",
                    Role = "Professeur"
                }
            );
        }
    }
}