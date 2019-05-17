using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TorneioValoran.Models;
using TorneioValoran.Repositories.Interfaces;
using TorneioValoran.Util;
using TorneioValoran.ViewModel;

namespace TorneioValoran.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupRepository _repositoryGroup;

        public GroupController(IGroupRepository repositoryGroup)
        {
            _repositoryGroup = repositoryGroup;
        }

        public IActionResult Index()
        {
            var groups = TempData.Get<List<Match>>("Match");

            if (groups == null) {
                 var result = _repositoryGroup.Create();
                return View(PirmaryLoad(_repositoryGroup.ListGroup().ToList()));
            }
            else
                return View(NextLoad(groups));

        }



        public List<ListMatchViewModel>  PirmaryLoad(List<Group> groups)
        {
            var result = new List<ListMatchViewModel>(); 

            foreach (var item in groups)
            {
                result.Add(new ListMatchViewModel
                {
                    Id = item.Id,
                    Group = item.Name,
                    TeamA = item.Teams.First().Name,
                    TeamB = item.Teams.Last().Name,
                    TeamWinner = string.Empty
                });
            }

            return result;
        }

        public List<ListMatchViewModel>  NextLoad(List<Match> groups)
        {
            var result = new List<ListMatchViewModel>();

            foreach (var item in groups)
            {
                result.Add(new ListMatchViewModel
                {
                    Id = item.Group.Id,
                    Group = item.Group.Name,
                    TeamA = item.Group.Teams.First().Name,
                    TeamB = item.Group.Teams.Last().Name,
                    TeamWinner = item.RsultTeamChampion.Name
                });
            }
            return result;
        }

    }
}