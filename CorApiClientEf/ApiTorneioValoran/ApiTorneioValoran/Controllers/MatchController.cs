using ApiTorneioValoran.Blls.Interfaces;
using ApiTorneioValoran.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiTorneioValoran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchRepository _repositoryMatch;
        private readonly IGroupRepository _repositoryGroup;
        private readonly IMatchBll _bllMatch;
        private readonly IGroupBll _bllGroup;

        public MatchController(IMatchRepository matchRepository, IGroupRepository groupRepository, IMatchBll matchBll, IGroupBll groupBll)
        {
            _repositoryMatch = matchRepository;
            _repositoryGroup = groupRepository;
            _bllMatch = matchBll;
            _bllGroup = groupBll;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositoryMatch.Get());
        }

        [Route("GetById/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _repositoryMatch.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            var fase = _bllGroup.GetLastFase();

            var groups = _bllGroup.GetGroupLastFase();

            var matchs = _bllMatch.StarMatch(groups.ToList());

            var overMatchs = _bllMatch.OverMatch(matchs);

            var matchFull = _bllMatch.SaveMatch(overMatchs);

            var teamWiner = matchFull.Select(x => x.RsultTeamChampion).ToList();
            //valida exception
            var result = _bllGroup.GroupTeamLink(fase+1, teamWiner);

            if (matchFull == null)
                return BadRequest();

            return new CreatedResult("Team create", matchFull);
        }
    }
}