using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipPregledaController : ControllerBase
    {
        private readonly ITipPregledaService _tipPregledaService;
        public TipPregledaController(ITipPregledaService tipPregledaService)
        {
            _tipPregledaService = tipPregledaService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_tipPregledaService.GetAll()); //sta ako ne uspe da vrati sve?
        }
    }
}
