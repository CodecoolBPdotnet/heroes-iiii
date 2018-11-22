using System;

namespace HeroesIIII.Models.Skills
{
    public class Regenerate : Skill
    {
        private int _heal = 1;
        public Regenerate(Game game) : base(game)
        {
            Name = "Regenerate";
            Description = $"Regenerates {_heal}% of the Hero's health points after battle.";
            game.GetHitEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var hero = ((Game)sender).Hero;
            var heal = hero.MaximumHealth * _heal / 100;
            hero.CurrentHealth += heal;
            ((GameEventArgs)e).Result.FightLog.Add(("Hero", $"{hero.Name} has recovered {heal} points of health."));
        }
    }
}
