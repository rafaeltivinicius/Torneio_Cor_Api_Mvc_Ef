using ApiTorneioValoran.Blls.Interfaces;
using ApiTorneioValoran.Models;
using ApiTorneioValoran.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiTorneioValoran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _repositoryTeam;
        private readonly IGroupRepository _repositoryGroup;
        private readonly ITeamBll _TeamBll;

        public TeamController(ITeamRepository teamRepository, IGroupRepository repositoryGroup, ITeamBll teamBll)
        {
            _repositoryGroup = repositoryGroup;
            _repositoryTeam = teamRepository;
            _TeamBll = teamBll;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositoryTeam.Get());
        }

        [Route("GetById/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _repositoryTeam.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create([FromBody]List<Team> model)
        {
            var result = _TeamBll.SaveTeam(model);

            if (result == null)
                return BadRequest();

            return new CreatedResult("Team create", result);
        }
    }
}


