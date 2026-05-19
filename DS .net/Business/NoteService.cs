using DS_.net.Data;
using DS_.net.Models;
using Microsoft.EntityFrameworkCore;

namespace DS_.net.Business
{
    public class NoteService
    {
        private readonly AppDbContext _context;

        public NoteService()
        {
            _context = new AppDbContext();
        }

        public void Add(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public List<Note> GetByEtudiant(int etudiantId)
        {
            return _context.Notes
                .Include(n => n.Matiere)
                .Where(n => n.EtudiantId == etudiantId)
                .ToList();
        }

        // Calculer la moyenne d'un étudiant
        public double GetMoyenne(int etudiantId)
        {
            var notes = _context.Notes
                .Include(n => n.Matiere)
                .Where(n => n.EtudiantId == etudiantId)
                .ToList();

            if (!notes.Any()) return 0;

            double totalCoeff = notes.Sum(n => n.Matiere.Coefficient);
            double totalPoints = notes.Sum(n => n.Valeur * n.Matiere.Coefficient);

            return totalCoeff == 0 ? 0 : totalPoints / totalCoeff;
        }
    }
}