using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
    }
}
