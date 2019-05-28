using ApiTorneioValoran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTorneioValoran.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        IEnumerable<Match> Get();
        Match Get(int id);
        Match Save(Match item);
        Match Update(Match item);
        bool Delete(Match item);
        bool DeleteAll();
    }
}
