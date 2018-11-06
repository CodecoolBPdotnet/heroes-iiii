using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models.Skills
{
    public class CounterAttack :Skill
    {
        public CounterAttack()
        {
            Name = "Counter Attack";
            ActivateOn = ActivateOnEnum.OnDamageTaken;
        }

        public override void Effect()
        {
            throw new NotImplementedException();
        }
    }
}
