using Microsoft.AspNetCore.Mvc;
using Wikipedia.Services.Interfaces;
using Wikipedia.Services.Models;
using Wikipedia.Services.Services;

namespace Widipedia.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FloatNumberController : ControllerBase
    {
        private readonly IFloatNumberStatisticService _statisticsService;

        public FloatNumberController(IFloatNumberStatisticService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet("{term, language}")]
        public async Task<FloatNumberStatistic> GetFloatNumberStatistics(string term, string language)
        {
            //var statistics = await _statisticsService.GetFloatNumberStatistics(term);
            //return Ok(statistics);
            return await _statisticsService.GetFloatNumberStatistics(term, language);
        }
    }
}


