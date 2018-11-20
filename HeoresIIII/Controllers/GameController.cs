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

        public GameController(ApiContext context, Game game)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}