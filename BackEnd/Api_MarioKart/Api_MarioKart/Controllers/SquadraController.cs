using Api_MarioKart.Dto;
using Api_MarioKart.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_MarioKart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquadraController : ControllerBase
    {
        private readonly SquadraService _service;

        public SquadraController(SquadraService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllPer());
        }

        [HttpPost("inserisci")]
        public IActionResult InserisciPersonaggio(SquadraDto objSq)
        {
            if (_service.InsertSquadra(objSq))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("modifica")]
        public IActionResult ModificaPersonaggio(SquadraDto objSq)
        {
            if (_service.ModifySquadra(objSq))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
