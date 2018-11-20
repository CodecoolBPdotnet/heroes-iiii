using System;

namespace HeroesIIII.Models.Skills
{
    public class CriticalStrike : Skill
    {
        public CriticalStrike(Game game) : base(game)
        {
            Name = "Critical Strike";
            Id = 2;
            game.AttackEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var hero = ((Game)sender).Hero;
            var target = ((GameEventArgs)e).Enemy;
            hero.Attack(target);
            Console.WriteLine($"{hero} dealt double damage!");
        }
    }
}
