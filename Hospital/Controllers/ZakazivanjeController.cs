using Hospital.Domain;
using Hospital.Models;
using Hospital.Service;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZakazivanjeController : ControllerBase
    {
        private readonly IZakazivanjePregledaService _zakazivanjePregledaService;

        public ZakazivanjeController(IZakazivanjePregledaService zakazivanjePregledaService)
        {
            _zakazivanjePregledaService = zakazivanjePregledaService;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_zakazivanjePregledaService.GetAll());
        }

        [HttpGet("{id}", Name = "GetZakazivanjePregleda")]

        public IActionResult Get(int id)
        {
            if (id < 0) return BadRequest(new ServiceResult<ZakazivanjePregleda>(false, "'id' manji od 0."));
            var zakazivanjePregleda = _zakazivanjePregledaService.Get(id);
            if (zakazivanjePregleda == null) return NotFound(new ServiceResult<ZakazivanjePregleda>(false, "Zakazivanje pregleda nije pronadjeno."));
            return Ok(zakazivanjePregleda);
        }

        [HttpPost]
        public IActionResult Post(CreateZakazivanjePregledaDto zakazivanjePregleda)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var zakazivanje = new ZakazivanjePregleda
            {
                KlijentId = zakazivanjePregleda.KlijentId,
                TipPregledaId = zakazivanjePregleda.TipPregledaId,
                RasporedId = zakazivanjePregleda.RasporedId,
                TerminId = zakazivanjePregleda.TerminId,
                Napomena = zakazivanjePregleda.Napomena
            };

            var result = _zakazivanjePregledaService.Add(zakazivanje);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Put(UpdateZakazivanjePregledaDto zakazivanjePregleda)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (zakazivanjePregleda.Id < 0)
                return BadRequest(new ServiceResult<ZakazivanjePregleda>(false, "'id' manji od 0."));

            var zakazivanje = _zakazivanjePregledaService.Get(zakazivanjePregleda.Id);
            if (zakazivanje == null)
                return NotFound(new ServiceResult<ZakazivanjePregleda>(false, "Zakazivanje pregleda nije pronadjeno."));

            zakazivanje.Napomena = zakazivanjePregleda.Napomena;
            zakazivanje.RasporedId = zakazivanjePregleda.RasporedId;
            zakazivanje.TerminId = zakazivanjePregleda.TerminId;


            var result = _zakazivanjePregledaService.Update(zakazivanje);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest(new ServiceResult<ZakazivanjePregleda>(false, "'id' manji od 0."));

            var zakazivanjePregleda = _zakazivanjePregledaService.Get(id);
            if (zakazivanjePregleda == null)
                return NotFound(new ServiceResult<ZakazivanjePregleda>(false, "Zakazivanje pregleda nije pronadjeno."));

            var result = _zakazivanjePregledaService.Delete(zakazivanjePregleda);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);

        }
    }
}
