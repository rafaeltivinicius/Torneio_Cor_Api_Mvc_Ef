using ApiTorneioValoran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTorneioValoran.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        IEnumerable<Group> Get();
        Group Get(int id);
        IEnumerable<Group> GetbyPhase(int id);
        Group Save(Group item);
        Group Update(Group item);
        bool Delete(Group item);
    }
}
