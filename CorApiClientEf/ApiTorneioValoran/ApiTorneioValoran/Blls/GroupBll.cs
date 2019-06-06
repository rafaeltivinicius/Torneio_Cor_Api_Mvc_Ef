using ApiTorneioValoran.Blls.Interfaces;
using ApiTorneioValoran.Models;
using ApiTorneioValoran.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiTorneioValoran.Blls
{
    public class GroupBll : IGroupBll
    {
        private readonly IGroupRepository _repositoryGroup;
        private readonly ITeamRepository _repositoryTeam;

        public GroupBll(IGroupRepository repositoryGroup, ITeamRepository teamRepository)
        {
            _repositoryGroup = repositoryGroup;
            _repositoryTeam = teamRepository;
        }

        public bool GroupTeamLink(int fase = 1, List<Team> teamss = null)
        {
            var teams = teamss == null ? _repositoryTeam.Get().ToList() : teamss;
            var groups = _repositoryGroup.Get();
            var nameNreGrou = groups.Count();
            List<Team> teamGroup = new List<Team>();

            try
            {
                foreach (var team in teams)
                {
                    teamGroup.Add(team);

                    if (teamGroup.Count() >= 2)
                    {
                        var group = _repositoryGroup.Save(new Group("Group - " + nameNreGrou++, teamGroup, fase));

                        teamGroup = new List<Team>();
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<Group> GetGroupLastFase()
        {
            return _repositoryGroup.GetbyPhase(GetLastFase()).ToList();
        }

        public int GetLastFase()
        {
            return _repositoryGroup.Get().Select(x => x.Fase).ToList().Max();
        }

        public bool DeleteAllGroup()
        {
            if(_repositoryGroup.DeleteAll())
            return true;

            return false;
        }
    }
}
