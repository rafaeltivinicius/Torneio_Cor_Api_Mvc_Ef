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
    public class MatchController : Controller
    {
        private readonly IMatchRepository _repositoryMatch;

        public MatchController(IMatchRepository matchRepository)
        {
            _repositoryMatch = matchRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenerateMatch()
        {
            var result =  _repositoryMatch.Create();

            TempData.Put("resultMatch", result);

            return RedirectToAction("LoadLastGroupWitchResult", "Group");
        }
    }
}