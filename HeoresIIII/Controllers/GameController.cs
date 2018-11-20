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

            //CreateTestHero();
            //TestFight();
        }

        private void TestFight()
        {
            var hero = _context.Heroes.First();
            var game = new Game
            {
                Hero = hero
            };
            var enemyGenerator = new EnemyGenerator();
            var skill = new CriticalStrike(game.Hero, game);
            var en = enemyGenerator.GenerateRandomEnemy(hero.Level);
            game.Fight(en);
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