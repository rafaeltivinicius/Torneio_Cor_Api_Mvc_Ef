using ApiTorneioValoran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTorneioValoran.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        IEnumerable<Team> Get();
        Team Get(int id);
        List<Team> GetByIdAll(int[] listId);
        Team Save(Team item);
        Team Update(Team item);
        bool Delete(Team item);
    }
}
