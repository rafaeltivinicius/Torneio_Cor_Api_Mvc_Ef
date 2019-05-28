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
                return false;
            }
        }
       
        public List<Group> GetGroupFullValidated()
        {
            var groups = _repositoryGroup.Get().ToList();
            var groupValid = new List<Group>();
            var groupFull = new List<Group>();
            var validGroupChampion = 2;

            if ((groups.Count() % 2) != 0)
                groups.RemoveAt(groups.Count - 1);

            try
            {
                foreach (var group in groups)
                {
                    groupValid.Add(group);

                    if (groupValid.Count() >= validGroupChampion)
                    {
                        groupFull.AddRange(groupValid);

                        validGroupChampion = validGroupChampion * 2;
                    }
                }

                return groupFull;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int GetFaseGroup()
        {
            var fases =  _repositoryGroup.Get().Select(x => x.Fase).ToList().Max();

            return fases;
        }

        public bool DeleteAllGroup()
        {
            if(_repositoryGroup.DeleteAll())
            return true;

            return false;
        }
    }
}
