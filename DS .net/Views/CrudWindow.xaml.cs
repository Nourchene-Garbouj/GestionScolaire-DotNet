using DS_.net.Business;
using DS_.net.Models;
using System.Windows;
using System.Windows.Controls;

namespace DS_.net.Views
{
    public partial class CrudWindow : Window
    {
        private readonly EtudiantService _etudiantService = new EtudiantService();
        private string _role;
        private Etudiant? _selectedEtudiant;

        public CrudWindow(string role)
        {
            InitializeComponent();
            _role = role;
            TxtRole.Text = $"👤 Connecté en tant que : {role}";
            LoadEtudiants();
        }

        private void LoadEtudiants()
        {
            DgEtudiants.ItemsSource = _etudiantService.GetAll();
        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNom.Text) || string.IsNullOrEmpty(TxtPrenom.Text))
            {
                MessageBox.Show("Veuillez remplir Nom et Prénom.", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var etudiant = new Etudiant
            {
                Nom = TxtNom.Text.Trim(),
                Prenom = TxtPrenom.Text.Trim(),
                DateNaissance = DpDateNaissance.SelectedDate ?? DateTime.Now,
                Classe = TxtClasse.Text.Trim()
            };

            _etudiantService.Add(etudiant);
            LoadEtudiants();
            ClearForm();
            MessageBox.Show("Étudiant ajouté avec succès !", "Succès",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEtudiant == null)
            {
                MessageBox.Show("Veuillez sélectionner un étudiant.", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _selectedEtudiant.Nom = TxtNom.Text.Trim();
            _selectedEtudiant.Prenom = TxtPrenom.Text.Trim();
            _selectedEtudiant.DateNaissance = DpDateNaissance.SelectedDate ?? DateTime.Now;
            _selectedEtudiant.Classe = TxtClasse.Text.Trim();

            _etudiantService.Update(_selectedEtudiant);
            LoadEtudiants();
            ClearForm();
            MessageBox.Show("Étudiant modifié avec succès !", "Succès",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEtudiant == null)
            {
                MessageBox.Show("Veuillez sélectionner un étudiant.", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show($"Supprimer {_selectedEtudiant.Nom} {_selectedEtudiant.Prenom} ?",
                "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _etudiantService.Delete(_selectedEtudiant.Id);
                LoadEtudiants();
                ClearForm();
            }
        }

        private void DgEtudiants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedEtudiant = DgEtudiants.SelectedItem as Etudiant;
            if (_selectedEtudiant != null)
            {
                TxtNom.Text = _selectedEtudiant.Nom;
                TxtPrenom.Text = _selectedEtudiant.Prenom;
                DpDateNaissance.SelectedDate = _selectedEtudiant.DateNaissance;
                TxtClasse.Text = _selectedEtudiant.Classe;
            }
        }

        private void ClearForm()
        {
            TxtNom.Text = "";
            TxtPrenom.Text = "";
            DpDateNaissance.SelectedDate = null;
            TxtClasse.Text = "";
            _selectedEtudiant = null;
        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            var dashboard = new DashboardWindow();
            dashboard.Show();
        }

        private void BtnNotes_Click(object sender, RoutedEventArgs e)
        {
            var notesWindow = new NotesWindow();
            notesWindow.Show();
        }
    }
}