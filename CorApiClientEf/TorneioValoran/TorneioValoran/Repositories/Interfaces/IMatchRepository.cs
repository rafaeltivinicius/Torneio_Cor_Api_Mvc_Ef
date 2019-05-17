using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneioValoran.Models;

namespace TorneioValoran.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        List<Match> ListGroup();
        List<Match> Create();
    }
}
