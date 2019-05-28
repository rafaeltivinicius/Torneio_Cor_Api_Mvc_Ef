using ApiTorneioValoran.Blls.Interfaces;
using ApiTorneioValoran.Models;
using ApiTorneioValoran.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiTorneioValoran.Blls
{
    public class MatchBll : IMatchBll
    {
        private readonly IMatchRepository _repositorymatch;
        private readonly IGroupRepository _repositoryGroup;

        public MatchBll(IGroupRepository repositoryGroup, IMatchRepository matchRepository)
        {
            _repositoryGroup = repositoryGroup;
            _repositorymatch = matchRepository;
        }

        public List<Match> StarMatch(List<Group> groups)
        {
            var matchs = new List<Match>();

            foreach (var group in groups)
            {
                matchs.Add(new Match
                {
                    Date = DateTime.Now,
                    IdGrupo = group.Id,
                    Group = group
                });
            }

            return matchs;
        }

        public List<Match> OverMatch(List<Match> matchs)
        {
            var matchsOver = new List<Match>();

            foreach (var match in matchs)
            {
                var teamA = match.Group.Teams.First();
                var teamB = match.Group.Teams.Last();

                Random random = new Random();
                int result = random.Next(1, 10);

                if (result >= 5) {
                    match.IdRsultTeamChampion = teamA.Id;
                    match.RsultTeamChampion = teamA;
                }
                else
                {
                    match.IdRsultTeamChampion = teamB.Id;
                    match.RsultTeamChampion = teamB;
                }

                matchsOver.Add(match);
            }

            return matchsOver;
        }

        public List<Match> SaveMatch(List<Match> matchs)
        {
            var matchCreate = new List<Match>();

            foreach (var match in matchs)
            {
                matchCreate.Add(_repositorymatch.Save(match));
            }

            return matchCreate;
        }

        public bool DeleteAllMatch()
        {
            if(_repositorymatch.DeleteAll())
            return true;

            return false;
        }

    }
}
