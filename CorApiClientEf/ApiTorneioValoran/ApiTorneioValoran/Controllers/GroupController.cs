using ApiTorneioValoran.Blls.Interfaces;
using ApiTorneioValoran.Models;
using ApiTorneioValoran.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTorneioValoran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _repositoryGroup;
        private readonly ITeamRepository _repositoryTeam;
        private readonly IGroupBll _groupBll;

        public GroupController(IGroupRepository repositoryGroup, ITeamRepository teamRepository, IGroupBll groupBll)
        {
            _repositoryGroup = repositoryGroup;
            _repositoryTeam = teamRepository;
            _groupBll = groupBll;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositoryGroup.Get());
        }

        [Route("GetById/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var reult = _repositoryGroup.Get(id);

            if (reult == null)
                return NotFound();

            return Ok(reult);
        }

        [Route("GetGroupLastFase")]
        [HttpGet]
        public IActionResult GetbyPhase()
        {
            var reult = _groupBll.GetGroupLastFase();

            if (reult == null)
                return NotFound();

            return Ok(reult);
        }

        [Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            if (!_groupBll.GroupTeamLink())
                return BadRequest();

            return new CreatedResult("", _groupBll.GetGroupLastFase());
        }

        [HttpPut]
        public IActionResult Update([FromBody]Group model)
        {
            var result = _repositoryGroup.Update(model);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

    }
}