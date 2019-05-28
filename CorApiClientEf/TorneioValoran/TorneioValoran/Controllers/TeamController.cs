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
        public IActionResult Create([FromBody]List<Team> teams)
        {
            var result = _repositoryTeam.Create(teams);

            return View("Index");
        }
    }
}


