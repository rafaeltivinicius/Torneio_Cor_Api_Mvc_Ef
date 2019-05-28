using ApiTorneioValoran.Models;
using System.Collections.Generic;

namespace ApiTorneioValoran.Blls.Interfaces
{
    public interface ITeamBll
    {
        List<Team> SaveTeam(List<Team> teams);
        bool DeleteAllTemas();

        bool DeleteAll();
    }
}
