namespace DS_.net.Models
{
    public class Note
    {
        public int Id { get; set; }
        public double Valeur { get; set; }
        public DateTime Date { get; set; }

        // Relation avec Etudiant
        public int EtudiantId { get; set; }
        public Etudiant Etudiant { get; set; } = null!;

        // Relation avec Matiere
        public int MatiereId { get; set; }
        public Matiere Matiere { get; set; } = null!;
    }
}