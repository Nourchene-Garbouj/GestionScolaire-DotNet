using DS_.net.Data;
using DS_.net.Models;
using Microsoft.EntityFrameworkCore;

namespace DS_.net.Business
{
    public class EtudiantService
    {
        private readonly AppDbContext _context;

        public EtudiantService()
        {
            _context = new AppDbContext();
        }

        // Récupérer tous les étudiants
        public List<Etudiant> GetAll()
        {
            return _context.Etudiants.Include(e => e.Notes).ToList();
        }

        // Ajouter un étudiant
        public void Add(Etudiant etudiant)
        {
            _context.Etudiants.Add(etudiant);
            _context.SaveChanges();
        }

        // Modifier un étudiant
        public void Update(Etudiant etudiant)
        {
            _context.Etudiants.Update(etudiant);
            _context.SaveChanges();
        }

        // Supprimer un étudiant
        public void Delete(int id)
        {
            var etudiant = _context.Etudiants.Find(id);
            if (etudiant != null)
            {
                _context.Etudiants.Remove(etudiant);
                _context.SaveChanges();
            }
        }
    }
}