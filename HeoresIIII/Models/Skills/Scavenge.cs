using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models.Skills
{
    public class Scavenge : Skill
    {
        public Scavenge()
        {
            Name = "Scavenge";
            ActivateOn = ActivateOnEnum.OnVictory;
        }

        public override void Effect()
        {
            throw new NotImplementedException();
        }
    }
}
