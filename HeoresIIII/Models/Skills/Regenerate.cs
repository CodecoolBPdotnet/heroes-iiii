using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models.Skills
{
    public class Regenerate : Skill
    {
        public Regenerate()
        {
            Name = "Regenerate";
            ActivateOn = ActivateOnEnum.OnVictory;
        }

        public override void Effect()
        {
            throw new NotImplementedException();
        }
    }
}
