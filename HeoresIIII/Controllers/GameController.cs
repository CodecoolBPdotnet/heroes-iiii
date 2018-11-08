using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeroesIIII.Models.Generators;
using HeroesIIII.Models;

namespace HeroesIIII.Controllers
{
    public class GameController : Controller
    {
        private readonly ApiContext _context;
        private readonly Game _game;

        public GameController(ApiContext context, Game game)
        {
            _context = context;
            _game = game;
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}