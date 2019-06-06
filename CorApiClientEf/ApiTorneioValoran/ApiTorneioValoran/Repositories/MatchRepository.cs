using ApiTorneioValoran.Data;
using ApiTorneioValoran.Models;
using ApiTorneioValoran.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApiTorneioValoran.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly StoreDataContext _context;

        public MatchRepository(StoreDataContext context)
        {
            _context = context;
        }

        public bool Delete(Match item)
        {
            _context.Match.Remove(item);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteAll()
        {
            var resut = Get();
            _context.Match.RemoveRange(_context.Match);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<Match> Get()
        {
            return _context.Match.AsNoTracking().ToList();
        }

        public Match Get(int id)
        {
            return _context.Match.Include(x => x.Group)
                        .Include(x => x.RsultTeamChampion).Where(x => x.Id == id).FirstOrDefault();
        }

        public Match Save(Match item)
        {
            _context.Match.Add(item);
            _context.SaveChanges();

            return item;
        }

        public Match Update(Match item)
        {
            _context.Entry<Match>(item).State = EntityState.Modified;
            _context.SaveChanges();

            return item;
        }
    }
}
