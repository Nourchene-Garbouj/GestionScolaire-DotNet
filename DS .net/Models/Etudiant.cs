namespace DS_.net.Models
{
    public class Etudiant
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public DateTime DateNaissance { get; set; }
        public string Classe { get; set; } = string.Empty;

        // Relation : un étudiant a plusieurs notes
        public List<Note> Notes { get; set; } = new List<Note>();
        public string NomComplet => $"{Nom} {Prenom}";
    }
    }