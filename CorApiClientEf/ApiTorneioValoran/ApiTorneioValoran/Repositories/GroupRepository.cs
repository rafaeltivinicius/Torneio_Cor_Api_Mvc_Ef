using ApiTorneioValoran.Data;
using ApiTorneioValoran.Models;
using ApiTorneioValoran.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiTorneioValoran.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly StoreDataContext _context;

        public GroupRepository(StoreDataContext context)
        {
            _context = context;

        }

        public bool Delete(Group item)
        {
            try
            {
                _context.Group.Remove(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteAll()
        {
            var resut = Get();
            _context.Group.RemoveRange(_context.Group);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<Group> Get()
        {
            return _context.Group
                        .Include(x => x.Teams).AsNoTracking().ToList();
        }

        public Group Get(int id)
        {
            return _context.Group.Include(x => x.Match)
                        .Include(x => x.Teams).Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Group> GetbyPhase(int fase)
        {
            return _context.Group.Include(x => x.Match)
                        .Include(x => x.Teams).Where(x => x.Fase == fase).ToList();
        }

        public Group Save(Group item)
        {
            try
            {
                item.Teams.ToList().ForEach(s => _context.Entry(s).State = EntityState.Modified);

                _context.Group.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Group Update(Group item)
        {
            try
            {
                _context.Entry<Group>(item).State = EntityState.Modified;
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
