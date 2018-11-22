using System;

namespace HeroesIIII.Models.Skills
{
    public class Regenerate : Skill
    {
        private int _heal = 20;
        public Regenerate(Game game) : base(game)
        {
            Name = "Regenerate";
            Description = $"Regenerates {_heal}% of the Hero's health points after battle.";
            game.GetHitEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var hero = ((Game)sender).Hero;
            hero.CurrentHealth += hero.MaximumHealth * _heal / 100;
        }
    }
}
