using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneioValoran.Models;

namespace TorneioValoran.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        List<Team> ListTeam();

        List<Team> Create(List<Team> teams);
    }
}
