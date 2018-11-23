using System;

namespace HeroesIIII.Models.Skills
{
    public class CounterAttack : Skill
    {
        private int _chance = 30;
        public CounterAttack(Game game) : base(game)
        {
            Name = "Counter Attack";
            Description = $"When hit, gives a {_chance}% chance of attacking the enemy back.";
            game.GetHitEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var hero = ((Game)sender).Hero;
            var target = ((GameEventArgs)e).Enemy;
            if (new Random().Next(100) < _chance)
            {
                var damage = hero.Attack(target);
                ((GameEventArgs)e).Result.FightLog.Add(("Hero", $"{hero.FirstName} counterattacked with {damage} damage!"));
            }
        }
    }
}
