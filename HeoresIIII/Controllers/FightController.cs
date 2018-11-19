using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroesIIII.Models;
using HeroesIIII.Models.Generators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroesIIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FightController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly Game _game;

        public FightController(ApiContext context, Game game)
        {
            _context = context;
            _game = game;
        }

        // GET: api/Fight
        [HttpGet]
        public void Fight()
        {
            var EnemyGenerator = new EnemyGenerator();
            _game.Fight(EnemyGenerator.GenerateRandomEnemy(_game.Account.Hero.Level));
            _context.Entry(_game.Hero).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}