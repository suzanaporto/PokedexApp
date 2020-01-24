using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokedexApp.Data;
using PokedexApp.Models;

namespace PokedexApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Pokemon> list = new List<Pokemon>();
            Task.Run(async () =>
            {
                list = await FetchData.GetPokemon();
            }).GetAwaiter().GetResult();
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [Route("/{id}")]
        [Route("/Pokemon/{id}")]
        public IActionResult Pokemon(int id)
        {
            PokemonInfo pokemon = new PokemonInfo();
            Task.Run(async () =>
            {
                pokemon = await FetchData.GetPokemonInfo(id);
            }).GetAwaiter().GetResult();
            return View(pokemon);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}