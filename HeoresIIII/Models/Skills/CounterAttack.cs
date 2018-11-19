using System;

namespace HeroesIIII.Models.Skills
{
    public class CounterAttack : Skill
    {
        public CounterAttack(Hero hero, Game game) : base(game)
        {
            Name = "Counter Attack";
            Id = 1;
            game.GetHitEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var hero = ((Game)sender).Hero;
            var target = ((GameEventArgs)e).Target;
            hero.Attack(target);
            Console.WriteLine($"{hero} attacked {target} back!");
        }
    }
}
