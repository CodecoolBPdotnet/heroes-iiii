using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HeroesIIII.Models.Skills.Skill;

namespace HeroesIIII.Models.Skills
{
    public  class Regenerate : Skill
    {
        public Regenerate()
        {
            Name = "Regenerate";
            Id = 4;
            ActivateOn = ActivateOnEnum.OnVictory;
        }

        public override void Effect()
        {
            throw new NotImplementedException();
        }
    }
}
