using System;

namespace HeroesIIII.Models.Skills
{
    public class Revive : Skill
    {
        private int _chance = 60;
        private int _remainingLives = 1;
        public Revive(Game game) : base(game)
        {
            Name = "Revive";
            Description = $"Has a {_chance}% of reviving the Hero {_remainingLives} time(s).";
            game.DeathEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var hero = ((Game)sender).Hero;
            if (new Random().Next(100) < _chance && _remainingLives-- >= 1)
                hero.CurrentHealth = hero.MaximumHealth * _chance / 100;
        }
    }
}
