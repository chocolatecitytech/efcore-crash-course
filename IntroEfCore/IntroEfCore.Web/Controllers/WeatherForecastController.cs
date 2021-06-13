using System;
using System.Collections.Generic;
using System.Linq;
using IntroEfCore.Web.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IntroEfCore.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly FlightControlContext _flightControl;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, FlightControlContext flightControl)
        {
            _logger = logger;
            _flightControl = flightControl;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_flightControl.Flights.ToList());
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
