namespace DS_.net.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string MotDePasse { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // "Admin" ou "Professeur"
    }
}