using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroesIIII.Models.Skills
{
    public abstract class Skill
    {
        [NotMapped]
        public Game Game { get; private set; }
        public Skill(Game game)
        {
            Game = game;
            Game.Hero.LearnedSkills.Add(GetType());
        }
        public string Name { get; set; }
        public string Description {get; set;}

        public abstract void Effect(object sender, EventArgs e);
    }
}
