using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HeroesIIII.Models.Skills.Skill;

namespace HeroesIIII.Models.Skills
{
    public class Scavenge : Skill
    {
        public Scavenge(Hero hero, Game game) : base(game)
        {
            Name = "Scavenge";
            Id = 6;
            game.WinBattleEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
