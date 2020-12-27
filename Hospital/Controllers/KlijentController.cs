using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KlijentController:ControllerBase
    {
        private readonly IKlijentService _klijentService;
        public KlijentController(IKlijentService klijentService)
        {
            _klijentService = klijentService;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_klijentService.GetAll());
        }
    }
}
