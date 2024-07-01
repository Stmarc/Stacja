using Microsoft.AspNetCore.Mvc;
using WeatherAppMVC.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace WeatherAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherContext _context;

        public HomeController(WeatherContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var weatherData = _context.WeatherData.ToList();
            return View(weatherData);
        }

        [HttpPost]
        public IActionResult PostData(string stacja, string dataPomiaru, string godzinaPomiaru, float temperatura, float predkoscWiatru, string kierunekWiatru, float wilgotnoscWzgledna, float sumaOpadu, float cisnienie)
        {
            var weatherData = new WeatherData
            {
                Stacja = stacja,
                DataPomiaru = DateTime.Parse(dataPomiaru),
                GodzinaPomiaru = godzinaPomiaru,
                Temperatura = temperatura,
                PredkoscWiatru = predkoscWiatru,
                KierunekWiatru = kierunekWiatru,
                WilgotnoscWzgledna = wilgotnoscWzgledna,
                SumaOpadu = sumaOpadu,
                Cisnienie = cisnienie
            };

            _context.WeatherData.Add(weatherData);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetWeatherData(string city, string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);

            var data = _context.WeatherData
                .Where(w => w.Stacja == city && w.DataPomiaru >= start && w.DataPomiaru <= end)
                .ToList();

            return Json(data);
        }

        [HttpGet]
        public IActionResult GetWeatherDataForChart(string city, string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);

            var data = _context.WeatherData
                .Where(w => w.Stacja == city && w.DataPomiaru >= start && w.DataPomiaru <= end)
                .OrderBy(w => w.DataPomiaru)
                .Select(w => new
                {
                    w.DataPomiaru,
                    w.Temperatura
                })
                .ToList();

            return Json(data);
        }
    }
}
