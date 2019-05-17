using ApiTorneioValoran.Models;
using System.Collections.Generic;

namespace ApiTorneioValoran.Blls.Interfaces
{
    public interface IGroupBll
    {
        bool GroupTeamLink(int fase = 1,List<Team> teams = null);
        List<Group> GetGroupFullValidated();
        int GetFaseGroup();
    }
}
