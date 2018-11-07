using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HeroesIIII.Models.Skills.Skill;

namespace HeroesIIII.Models.Skills
{
    public class Revive : Skill
    {
        public Revive()
        {
            Name = "Revive";
            Id = 5;
            ActivateOn = ActivateOnEnum.OnDeath;
        }

        public override void Effect()
        {
            throw new NotImplementedException();
        }
    }
}
