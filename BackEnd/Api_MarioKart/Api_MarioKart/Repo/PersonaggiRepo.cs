using Api_MarioKart.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_MarioKart.Repo
{
    public class PersonaggiRepo : IRepo<Personaggi>
    {
        #region Inizializzazione

        private readonly MarioKartContext _context;

        public PersonaggiRepo(MarioKartContext context)
        {
            _context = context;
        }
        #endregion
        public bool Create(Personaggi entity)
        {
            try
            {
                _context.Personaggi.Add(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool Delete(string codice)
        {
            Personaggi? p = GetByCod(codice);
            if (p != null)
            {
                _context.Remove(p);
                return true;
            }
            return false;
        }


        public IEnumerable<Personaggi> GetAll()
        {
            return _context.Personaggi.Include(p=>p.SquadraRifNavigation).ToList();
        }

        public Personaggi? GetByCod(string codice)
        {
            return _context.Personaggi.FirstOrDefault(p => p.Codice == codice);
        }

        public bool Update(Personaggi entity)
        {
            try
            {
                _context.Personaggi.Update(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
