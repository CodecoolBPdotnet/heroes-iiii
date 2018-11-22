using HeroesIIII.Models;
using HeroesIIII.Models.Generators;
using HeroesIIII.Models.Skills;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            if (_game.Hero == null)
                return Redirect("/");
            return View();
        }
    }
}