using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HeroesIIII.Models.Skills.Skill;

namespace HeroesIIII.Models.Skills
{
    public  class Regenerate : Skill
    {
        public Regenerate(Hero hero, Game game) : base(game)
        {
            Name = "Regenerate";
            Id = 4;
            game.GetHitEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
