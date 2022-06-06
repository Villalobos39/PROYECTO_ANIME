using AnimeWebApi.Engine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeWebApi.AnimeWebService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherAnimeController : Controller
    {
        private static readonly string[] Summaries = new[]
        {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};

        private readonly ILogger<WeatherAnimeController> _logger;

        public WeatherAnimeController(ILogger<WeatherAnimeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherAnime")]
        public IEnumerable<WeatherAnime> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherAnime
            {
                Date = DateTime.Now.AddDays(index),
                //TemperatureC = Random.Shared.Next(-20, 55),
                //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
