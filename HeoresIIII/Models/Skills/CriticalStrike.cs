using System;

namespace HeroesIIII.Models.Skills
{
    public class CriticalStrike : Skill
    {
        private int _chance = 10;
        public CriticalStrike(Game game) : base(game)
        {
            Name = "Critical Strike";
            Description = $"Gives a {_chance}% chance of dealing double damage.";
            game.AttackEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var hero = ((Game)sender).Hero;
            var target = ((GameEventArgs)e).Enemy;
            if (new Random().Next(100) < _chance)
                hero.Attack(target);
            Console.WriteLine($"{hero} dealt double damage!");
        }
    }
}
