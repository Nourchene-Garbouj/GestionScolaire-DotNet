using DS_.net.Business;
using DS_.net.Data;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace DS_.net.Views
{
    public partial class DashboardWindow : Window
    {
        private readonly AppDbContext _context = new AppDbContext();
        private readonly NoteService _noteService = new NoteService();

        public DashboardWindow()
        {
            InitializeComponent();
            LoadStats();
        }

        private void LoadStats()
        {
            var etudiants = _context.Etudiants.Include(e => e.Notes)
                                              .ThenInclude(n => n.Matiere)
                                              .ToList();

            // Total étudiants
            TxtTotalEtudiants.Text = etudiants.Count.ToString();

            // Moyennes par étudiant
            var moyennes = etudiants.Select(e => new
            {
                e.Nom,
                e.Prenom,
                e.Classe,
                Moyenne = _noteService.GetMoyenne(e.Id),
                Resultat = _noteService.GetMoyenne(e.Id) >= 10 ? "✅ Admis" : "❌ Refusé"
            }).ToList();

            DgMoyennes.ItemsSource = moyennes;

            // Moyenne générale
            if (moyennes.Any())
            {
                double moyenneGen = moyennes.Average(m => m.Moyenne);
                TxtMoyenneGenerale.Text = moyenneGen.ToString("F2");

                // Taux de réussite
                int admis = moyennes.Count(m => m.Moyenne >= 10);
                double taux = (double)admis / moyennes.Count * 100;
                TxtTauxReussite.Text = taux.ToString("F0") + "%";
            }
            else
            {
                TxtMoyenneGenerale.Text = "N/A";
                TxtTauxReussite.Text = "N/A";
            }
        }
    }
}
