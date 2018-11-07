using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HeroesIIII.Models.Skills.Skill;

namespace HeroesIIII.Models.Skills
{
    public class CounterAttack : Skill
    {
        public CounterAttack()
        {
            Name = "Counter Attack";
            Id = 1;
            ActivateOn = ActivateOnEnum.OnDamageTaken;
        }

        public override void Effect()
        {
            throw new NotImplementedException();
        }
    }
}
