using System;

namespace HeroesIIII.Models.Skills
{
    public class Revive : Skill
    {
        private int _revivePercent = 60;
        private int _remainingLives = 1;
        public Revive(Game game) : base(game)
        {
            Name = "Revive";
            Id = 5;
            game.DeathEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var hero = ((Game)sender).Hero;
            if (_remainingLives-- >= 1)
                hero.CurrentHealth = hero.MaximumHealth * _revivePercent / 100;
        }
    }
}
