using ApiTorneioValoran.Blls.Interfaces;
using ApiTorneioValoran.Models;
using ApiTorneioValoran.Repositories.Interfaces;
using System.Collections.Generic;

namespace ApiTorneioValoran.Blls
{
    public class TeamBll : ITeamBll
    {
        private readonly IGroupRepository _repositoryGroup;
        private readonly ITeamRepository _repositoryTeam;

        public TeamBll(IGroupRepository repositoryGroup, ITeamRepository teamRepository)
        {
            _repositoryGroup = repositoryGroup;
            _repositoryTeam = teamRepository;
        }

        public List<Team> SaveTeam(List<Team> teams)
        {
            var teamsCreate = new List<Team>();

            foreach (var team in teams)
            {
                teamsCreate.Add(_repositoryTeam.Save(team));
            }

            return teamsCreate;
        }
    }
}
