using DS_.net.Business;
using DS_.net.Data;
using DS_.net.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace DS_.net.Views
{
    public partial class NotesWindow : Window
    {
        private readonly NoteService _noteService = new NoteService();
        private readonly MatiereService _matiereService = new MatiereService();
        private readonly AppDbContext _context = new AppDbContext();

        public NotesWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var etudiants = _context.Etudiants.ToList();
            CmbEtudiant.ItemsSource = etudiants;
            CmbEtudiant.DisplayMemberPath = "NomComplet";

            var matieres = _matiereService.GetAll();
            CmbMatiere.ItemsSource = matieres;
            CmbMatiere.DisplayMemberPath = "Nom";

            DgNotes.ItemsSource = _context.Notes
                .Include(n => n.Etudiant)
                .Include(n => n.Matiere)
                .ToList();
        }

        private void BtnAjouterNote_Click(object sender, RoutedEventArgs e)
        {
            if (CmbEtudiant.SelectedItem == null || CmbMatiere.SelectedItem == null
                || string.IsNullOrEmpty(TxtNote.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(TxtNote.Text, out double valeur) || valeur < 0 || valeur > 20)
            {
                MessageBox.Show("La note doit être entre 0 et 20.", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var etudiant = (Etudiant)CmbEtudiant.SelectedItem;
            var matiere = (Matiere)CmbMatiere.SelectedItem;

            var note = new Note
            {
                EtudiantId = etudiant.Id,
                MatiereId = matiere.Id,
                Valeur = valeur,
                Date = DateTime.Now
            };

            _noteService.Add(note);
            LoadData();
            TxtNote.Text = "";
            MessageBox.Show("Note ajoutée avec succès !", "Succès",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnAjouterMatiere_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNomMatiere.Text) || string.IsNullOrEmpty(TxtCoeff.Text))
            {
                MessageBox.Show("Veuillez remplir le nom et le coefficient.", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(TxtCoeff.Text, out double coeff))
            {
                MessageBox.Show("Coefficient invalide.", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var matiere = new Matiere
            {
                Nom = TxtNomMatiere.Text.Trim(),
                Coefficient = coeff
            };

            _matiereService.Add(matiere);
            LoadData();
            TxtNomMatiere.Text = "";
            TxtCoeff.Text = "";
            MessageBox.Show("Matière ajoutée !", "Succès",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}