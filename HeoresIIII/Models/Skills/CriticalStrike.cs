using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models.Skills
{
    public class CriticalStrike : Skill
    {
        public CriticalStrike()
        {
            Name = "Critical Strike";
            ActivateOn = ActivateOnEnum.OnAttack;
        }

        public override void Effect()
        {
            throw new NotImplementedException();
        }
    }
}
