using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWebHostEnvironment _webHostEnv;

        public WeatherForecastController(IConfiguration configuration, IWebHostEnvironment webHostEnv, ILogger<WeatherForecastController> logger)
        {
            _configuration = configuration;
            _webHostEnv = webHostEnv;
            _logger = logger;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            int rangeStart = 1;
            int rangeEnd = 2;
            if (_webHostEnv.IsDevelopment())
            {
                rangeStart = 1;
                rangeEnd = 2;
            } else if( _webHostEnv.IsEnvironment("CustomEnv_HTTP"))
            {
                rangeStart = 1;
                rangeEnd = 3;
            }
            var setting1 = _configuration["MySettings:Setting1"];
            var setting2 = _configuration["MySettings:Setting2"];

            //Console.WriteLine(setting1);
            //Console.WriteLine(setting2);

            return Enumerable.Range(rangeStart, rangeEnd).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
