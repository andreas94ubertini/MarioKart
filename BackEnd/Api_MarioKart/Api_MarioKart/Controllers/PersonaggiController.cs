using Api_MarioKart.Dto;
using Api_MarioKart.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_MarioKart.Controllers
{
    [Route("api/personaggi")]
    [ApiController]
    public class PersonaggiController : ControllerBase
    {
        private readonly PersonaggiService _service;

        public PersonaggiController(PersonaggiService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllPer());
        }

        [HttpPost("inserisci")]
        public IActionResult InserisciProdotto(PersonaggiDto objPer)
        {
            if (_service.InsertPersonaggio(objPer))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
