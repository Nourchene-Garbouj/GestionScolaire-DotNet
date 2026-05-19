using DS_.net.Data;
using DS_.net.Models;

namespace DS_.net.Business
{
    public class MatiereService
    {
        private readonly AppDbContext _context;

        public MatiereService()
        {
            _context = new AppDbContext();
        }

        public List<Matiere> GetAll()
        {
            return _context.Matieres.ToList();
        }

        public void Add(Matiere matiere)
        {
            _context.Matieres.Add(matiere);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var matiere = _context.Matieres.Find(id);
            if (matiere != null)
            {
                _context.Matieres.Remove(matiere);
                _context.SaveChanges();
            }
        }
    }
}