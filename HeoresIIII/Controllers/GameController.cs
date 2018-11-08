using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeroesIIII.Models.Generators;

namespace HeroesIIII.Controllers
{
    public class GameController : Controller
    {
        private readonly ApiContext _context;

        public GameController(ApiContext context)
        {
            _context = context;

            CreateTestHero();
        }

        private void CreateTestHero()
        {
            if (!_context.Heroes.Any())
            {
                var generator = new HeroGenerator();
                var testHero = generator.GenerateNewRandomHero();
                _context.Heroes.Add(testHero);
                _context.SaveChanges(); 
            }
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}