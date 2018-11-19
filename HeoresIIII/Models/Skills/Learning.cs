using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HeroesIIII.Models.Skills.Skill;

namespace HeroesIIII.Models.Skills
{
    public  class Learning : Skill
    {
        public Learning(Hero hero, Game game) : base(game)
        {
            Name = "Learning";
            Id = 3;
            game.WinBattleEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
