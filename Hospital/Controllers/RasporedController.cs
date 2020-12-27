using Hospital.Domain;
using Hospital.Service;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("controller")]
    public class RasporedController:ControllerBase
    {
        private readonly IRasporedService _rasporedService;
        public RasporedController(IRasporedService rasporedService)
        {
            _rasporedService = rasporedService;
        }

        [HttpGet("{doktorId}")]
        public IActionResult GetAll(int doktorId)
        {
            if (doktorId < 0)
                return BadRequest(new ServiceResult<Raspored>(false, "'id' manji od 0"));
            return Ok(_rasporedService.GetAll(doktorId));
        }
    }
}
