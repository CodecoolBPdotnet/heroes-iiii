using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models.Skills
{
    public abstract class Skill : GameObject
    {
        public bool Avaliable { get; set; }
        public ActivateOnEnum ActivateOn { get; set; }

        public abstract void Effect();

        public enum ActivateOnEnum
        {
            OnAttack, OnDamageTaken, OnDeath, OnVictory
        }
    }

    
}
