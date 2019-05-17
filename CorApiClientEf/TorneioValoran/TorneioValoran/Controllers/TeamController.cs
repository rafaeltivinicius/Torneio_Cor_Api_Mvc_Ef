using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TorneioValoran.Models;
using TorneioValoran.Repositories.Interfaces;
using Newtonsoft.Json;


namespace TorneioValoran.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamRepository _repositoryTeam;

        public TeamController(ITeamRepository teamRepository)
        {
            _repositoryTeam = teamRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody]List<Team> model)
        {

            var modell = new List<Team> { new Team { Name = "Time 1" }, new Team { Name = "Time 2" },
            new Team { Name = "Time 3" }, new Team { Name = "Time 4" }};

            var result = _repositoryTeam.Create(modell);

            return View("Index");
        }
    }
}


