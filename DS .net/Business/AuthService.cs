using DS_.net.Data;
using DS_.net.Models;

namespace DS_.net.Business
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService()
        {
            _context = new AppDbContext();
        }

        public Utilisateur? Login(string login, string motDePasse)
        {
            return _context.Utilisateurs
                .FirstOrDefault(u => u.Login == login && u.MotDePasse == motDePasse);
        }
    }
}