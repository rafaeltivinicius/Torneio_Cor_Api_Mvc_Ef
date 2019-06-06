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
        public List<ListMatchViewModel> dataTable { get; set; }
        private static bool PrimayAcess = true;

        public GroupController(IGroupRepository repositoryGroup)
        {
            this.dataTable = new List<ListMatchViewModel>();
            _repositoryGroup = repositoryGroup;
        }

        public IActionResult Index()
        {
            if (PrimayAcess)
                PrimaryLoad();

            return View(dataTable);
        }

        public IActionResult PrimaryLoad()
        {
            dataTable = PirmaryLoad(_repositoryGroup.Create());
            PrimayAcess = false;

            return View("Index");
        }

        public IActionResult LoadLastGroupNotResult()
        {
            dataTable = PirmaryLoad(_repositoryGroup.ListGroupFase());

            return View("Index", dataTable);
        }

        public IActionResult LoadLastGroupWitchResult()
        {
            dataTable = NextLoad(TempData.Get<List<Match>>("resultMatch"));

            return View("Index",dataTable);
        }

        public List<ListMatchViewModel> PirmaryLoad(List<Group> groups)
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

        public List<ListMatchViewModel> NextLoad(List<Match> groups)
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