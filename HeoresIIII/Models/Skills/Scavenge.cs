using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HeroesIIII.Models.Skills.Skill;

namespace HeroesIIII.Models.Skills
{
    public class Scavenge : Skill
    {
        public Scavenge()
        {
            Name = "Scavenge";
            Id = 6;
            ActivateOn = ActivateOnEnum.OnVictory;
        }

        public override void Effect()
        {
            throw new NotImplementedException();
        }
    }
}
