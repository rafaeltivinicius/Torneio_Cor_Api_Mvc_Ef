using ApiTorneioValoran.Data;
using ApiTorneioValoran.Models;
using ApiTorneioValoran.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiTorneioValoran.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly StoreDataContext _context;

        public TeamRepository(StoreDataContext context)
        {
            _context = context;
        }

        public bool Delete(Team item)
        {
            _context.Team.Remove(item);
            _context.SaveChanges();

            return true;
        }


        public bool DeleteAll()
        {
            var resut = Get();
            _context.Team.RemoveRange(resut);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<Team> Get()
        {
            return _context.Team.Include(x => x.Group).AsNoTracking().ToList();

        }

        public Team Get(int id)
        {
            return _context.Team.Find(id);
        }

        public List<Team> GetByIdAll(int[] listId)
        {
            return _context.Team.AsNoTracking().Where(x => listId.Contains(x.Id)).ToList();
        }

        public Team Save(Team item)
        {
            try
            {
                _context.Team.Add(item);
                _context.SaveChanges();

                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Team Update(Team item)
        {
            try
            {
                _context.Entry<Team>(item).State = EntityState.Modified;
                _context.SaveChanges();

                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
