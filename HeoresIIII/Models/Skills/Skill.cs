using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models.Skills
{
    public class Skill
    {
        [NotMapped]
        public Game Game { get; private set; }
        public Skill(Game game)
        {
            Game = game;
            game.Hero.LearnedSkills.Add(this);
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual void Effect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
