using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeroesIIII;
using HeroesIIII.Models;

namespace HeroesIIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly Game _game;

        public HeroController(ApiContext context, Game game)
        {
            _context = context;
            _game = game;
        }

        // GET: api/Hero
        [HttpGet]
        public IEnumerable<Hero> GetHeroes()
        {
            return _context.Heroes;
        }

        // GET: api/Hero/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHero([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hero = await _context.Heroes.FindAsync(id);

            if (hero == null)
            {
                return NotFound();
            }

            return Ok(hero);
        }

        // PUT: api/Hero/5
        [HttpPut("{id}/{attribute}")]
        public async Task<IActionResult> PutHero([FromRoute] int id, [FromRoute] string attribute)
        {
            if (_game.Hero.SkillPoints < 1)
            {
                return StatusCode(400);
            }
            if (attribute == "atk")
            {
                _game.Hero.Damage++;
            }
            else if (attribute == "def")
            {
                _game.Hero.Defense++;
            }
            else if (attribute == "agi")
            {
                _game.Hero.Agility++;
            }
            else if (attribute == "vit")
            {
                _game.Hero.MaximumHealth = _game.Hero.MaximumHealth + 10;
                _game.Hero.CurrentHealth = _game.Hero.CurrentHealth + 10;
                _game.Hero.Vitality++;

            }
            _game.Hero.SkillPoints--;
            _context.Entry(_game.Hero).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        // POST: api/Hero
        [HttpPost]
        public async Task<IActionResult> PostHero([FromBody] Hero hero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHero", new { id = hero.Id }, hero);
        }

        // DELETE: api/Hero/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();

            return Ok(hero);
        }

        private bool HeroExists(int id)
        {
            return _context.Heroes.Any(e => e.Id == id);
        }
    }
}