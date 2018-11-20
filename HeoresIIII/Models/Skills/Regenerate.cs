using System;

namespace HeroesIIII.Models.Skills
{
    public class Regenerate : Skill
    {
        private int _regeneratePercent = 20;
        public Regenerate(Game game) : base(game)
        {
            Name = "Regenerate";
            Id = 4;
            game.GetHitEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var hero = ((Game)sender).Hero;
            hero.CurrentHealth += hero.MaximumHealth * _regeneratePercent / 100;
        }
    }
}
