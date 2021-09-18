using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Models;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ILogger<SampleController> _logger;
        private readonly ISampleService _sampleService;
        public SampleController(ILogger<SampleController> logger, ISampleService sampleService)
        {
            _logger = logger;
            _sampleService = sampleService;
        }

        // POST api/<SampleController>
        [HttpPost("[action]")]
        public async Task<IActionResult> Post([FromBody] SampleModel sampleModel)
        {
            var result = await _sampleService.SaveDataAsync(sampleModel);
            return Ok(result);
        }

    }
}
