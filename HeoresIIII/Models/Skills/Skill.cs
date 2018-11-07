using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models.Skills
{
    public class Skill
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public static ActivateOnEnum ActivateOn { get; set; }

        public virtual void Effect()
        {
            throw new NotImplementedException();
        }

        public enum ActivateOnEnum
        {
            OnAttack, OnDamageTaken, OnDeath, OnVictory
        }
    }

    
}
