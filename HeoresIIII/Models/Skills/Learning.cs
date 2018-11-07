using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HeroesIIII.Models.Skills.Skill;

namespace HeroesIIII.Models.Skills
{
    public  class Learning : Skill
    {
        public Learning()
        {
            Name = "Learning";
            Id = 3;
            ActivateOn = ActivateOnEnum.OnVictory;
        }

        public override void Effect()
        {
            throw new NotImplementedException();
        }
    }
}
