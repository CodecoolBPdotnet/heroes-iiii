using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HeroesIIII.Models.Skills.Skill;

namespace HeroesIIII.Models.Skills
{
    public class Revive : Skill
    {
        public Revive(Hero hero, Game game) : base(game)
        {
            Name = "Revive";
            Id = 5;
            game.DeathEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
