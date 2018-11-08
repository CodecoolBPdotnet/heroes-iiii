using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HeroesIIII.Controllers
{
    public class GameController : Controller
    {
        private static int testHeroCounter = 0;
        private readonly ApiContext _context;

        public GameController(ApiContext context)
        {
            _context = context;

            CreateTestHero();
        }

        private void CreateTestHero()
        {
            if (testHeroCounter < 1)
            {
                var generator = new Models.Generators.HeroGenerator();
                var testHero = generator.GenerateNewRandomHero();
                _context.Heroes.Add(testHero);
                _context.SaveChanges(); 
            }

            testHeroCounter ++;
        }


        public IActionResult Index()
        {

            return View();
        }
    }
}