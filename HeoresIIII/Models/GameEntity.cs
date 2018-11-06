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
        public int MaximumHealth { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }

        void Attack(GameEntity target)
        {
            throw new NotImplementedException();
        }
    }
}
