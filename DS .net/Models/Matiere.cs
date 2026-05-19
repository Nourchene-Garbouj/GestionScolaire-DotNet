namespace DS_.net.Models
{
    public class Matiere
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public double Coefficient { get; set; }

        // Relation : une matière a plusieurs notes
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}