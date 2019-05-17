using ApiTorneioValoran.Models;
using System.Collections.Generic;

namespace ApiTorneioValoran.Blls.Interfaces
{
    public interface IMatchBll
    {
        List<Match> StarMatch(List<Group> groups);
        List<Match> OverMatch(List<Match> matchsin);
        List<Match> SaveMatch(List<Match> matchs);
    }
}
