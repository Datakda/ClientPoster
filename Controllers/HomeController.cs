using ClientPoster.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientPoster.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(MinMax model)
        {

            if (ModelState.IsValid)
            {
                if (model.Min >= model.Max) 
                {
                    ViewBag.Message = "Минимальное число должно быть меньше максимального.";
                    return View();

                }
                var json = JsonSerializer.Serialize<MinMax>(model);
                WebRequest request = WebRequest.Create($"http://185.195.26.249:7777/api/GetRandom?minmax={json}");
                WebResponse response = await request.GetResponseAsync();
                string rnd;
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        rnd = reader.ReadToEnd();
                    }
                }
                response.Close();

                ViewBag.rnd = rnd;
                return View();

            }
            

            return View();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
