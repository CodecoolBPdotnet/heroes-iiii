using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeroesIIII.Models;
using HeroesIIII.Models.Generators;

namespace HeroesIIII.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var Herogen = new HeroGenerator();
            var Hero = Herogen.GenerateNewRandomHero();
            var Enemygen = new EnemyGenerator();
            var Enemy = Enemygen.GenerateRandomEnemy(Hero.Level);
            var Game = new Game
            {
                Hero = Hero,
                Enemy = Enemy
            };
            Game.Fight();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
