using Microsoft.AspNetCore.Mvc;
using SalesOrderManager.DAL;

namespace SalesOrderManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : Controller
    {
        private readonly IStateRepository _stateRepository;

        public StateController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetStates()
        {
            return Ok(_stateRepository.GetAllStates());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetStateById(int id)
        {
            return Ok(_stateRepository.GetStateById(id));
        }
    }
}
