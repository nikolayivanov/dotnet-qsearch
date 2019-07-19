using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Qsearch.WebAng.Models;

namespace Qsearch.WebAng.Controllers
{
    [Route("api/[controller]")]
    public class ClientAppSettingsController : Controller
    {
        private readonly ClientAppSettings _clientAppSettings;

        public ClientAppSettingsController(IOptions<ClientAppSettings> clientAppSettings)
        {
            _clientAppSettings = clientAppSettings.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clientAppSettings);
        }
    }
}
