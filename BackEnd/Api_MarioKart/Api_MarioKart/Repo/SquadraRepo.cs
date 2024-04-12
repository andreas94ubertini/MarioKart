﻿using Api_MarioKart.Models;

namespace Api_MarioKart.Repo
{
    public class SquadraRepo : IRepo<Squadra>
    {
        #region Inizializzazione

        private readonly MarioKartContext _context;

        public SquadraRepo(MarioKartContext context)
        {
            _context = context;
        }

        #endregion
        public bool Create(Squadra entity)
        {
            try
            {
                _context.Squadra.Add(entity);
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
            Squadra? s = GetByCod(codice);
            if (s != null)
            {
                _context.Remove(s);
                return true;
            }
            return false;
        }

        public IEnumerable<Squadra> GetAll()
        {
            return _context.Squadra.ToList();

        }

        public Squadra? GetByCod(string codice)
        {
            return _context.Squadra.FirstOrDefault(p => p.Codice == codice);

        }

        public bool Update(Squadra entity)
        {
            try
            {
                _context.Squadra.Update(entity);
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