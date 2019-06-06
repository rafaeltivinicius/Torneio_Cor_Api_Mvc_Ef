using ApiTorneioValoran.Blls.Interfaces;
using ApiTorneioValoran.Models;
using ApiTorneioValoran.Repositories.Interfaces;
using System.Collections.Generic;

namespace ApiTorneioValoran.Blls
{
    public class TeamBll : ITeamBll
    {
        private readonly ITeamRepository _repositoryTeam;
        private readonly IGroupBll _bllGroup;
        private readonly IMatchBll _bllMatch;

        public TeamBll(ITeamRepository teamRepository, IGroupBll groupBll,IMatchBll matchBll)
        {
            _bllGroup = groupBll;
            _repositoryTeam = teamRepository;
            _bllMatch = matchBll;

        }

        public List<Team> SaveTeam(List<Team> teams)
        {
            if (!DeleteAll())
                return null;

            var teamsCreate = new List<Team>();

            foreach (var team in teams)
            {
                teamsCreate.Add(_repositoryTeam.Save(team));
            }

            return teamsCreate;
        }

        public bool DeleteAllTemas()
        {
            if(_repositoryTeam.DeleteAll())
            return true;

            return false;
        }

        public bool DeleteAll()
        {

            if (!_bllMatch.DeleteAllMatch())
                return false;

            if (!DeleteAllTemas()) 
            return false;

            if (!_bllGroup.DeleteAllGroup())
                return false;


            return true;
        }
    }
}
