using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HeroesIIII.Models.Skills.Skill;

namespace HeroesIIII.Models.Skills
{
    public class CriticalStrike : Skill
    {
        public CriticalStrike()
        {
            Name = "Critical Strike";
            Id = 2;
            ActivateOn = ActivateOnEnum.OnAttack;
        }

        public override void Effect()
        {
            throw new NotImplementedException();
        }
    }
}
