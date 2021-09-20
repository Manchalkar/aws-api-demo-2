using Etools.Services.Implementations;
using Etools.WebApi.ViewModels;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etools.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private IDemoService DemoService;

        public DemoController(IConfiguration configuration, IDemoService demoService)
        {
            this._configuration = configuration;
            this.DemoService = demoService;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            DemoService.Get();

            return Ok();
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Post(vmDemo model)
        {
            DemoService.Post(model.Id,model.Name,model.Age);

            return Ok();
        }
    }
}
