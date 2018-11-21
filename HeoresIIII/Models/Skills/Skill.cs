using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroesIIII.Models.Skills
{
    public class Skill
    {
        [NotMapped]
        public Game Game { get; private set; }
        public Skill(Game game)
        {
            Game = game;
            Game.Hero.LearnedSkills.Add(GetType());
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual void Effect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
