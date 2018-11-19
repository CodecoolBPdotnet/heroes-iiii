using System;

namespace HeroesIIII.Models.Skills
{
    public class CriticalStrike : Skill
    {
        public CriticalStrike(Hero hero, Game game) : base(game)
        {
            Name = "Critical Strike";
            Id = 2;
            game.AttackEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            Hero hero = ((Game)sender).Hero;
            hero.Attack(((GameEventArgs)e).Target);
            Console.WriteLine($"{hero} dealt double damage!");
        }
    }
}
