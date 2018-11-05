using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models.Skills
{
    public class Revive : Skill
    {
        public Revive()
        {
            Name = "Revive";
            ActivateOn = ActivateOnEnum.OnDeath;
        }

        public override void Effect()
        {
            throw new NotImplementedException();
        }
    }
}
