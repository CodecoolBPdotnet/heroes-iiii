using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models
{
    public abstract class GameEntity : GameObject
    {
        public int Damage { get; set; }
        public int Defense { get; set; }
        public int Agility { get; set; }
        public int Vitality { get; set; }
        public int MaximumHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Level { get; set; }

        public virtual void Attack(GameEntity target)
        {
            target.CurrentHealth -= (int) (Damage * (target.Defense*0.5));
        }
    }
}
