using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models
{
    public class Game
    {
        public Account Account { get; set; }

        public Hero Hero { get; set; }

        public Enemy Enemy { get; set; }

        public void Fight()
        {
            double HeroTurn = 0;
            double EnemyTurn = 0;
            while(Hero.CurrentHealth > 0 && Enemy.CurrentHealth > 0)
            {
                HeroTurn += 1 + Hero.Agility * 0.25;
                if (HeroTurn > 100)
                {
                    Hero.Attack(Enemy);
                }
                EnemyTurn += 1 + Enemy.Agility * 0.25;
                if (EnemyTurn > 100)
                {
                    Enemy.Attack(Hero);
                }
            }
            if (Hero.CurrentHealth > 0)
            {
                Hero.Experience += Enemy.ExperienceDrop;
                Hero.CurrentHealth += (int) (Hero.MaximumHealth * 0.20);
                if (Hero.CurrentHealth > Hero.MaximumHealth) { Hero.CurrentHealth = Hero.MaximumHealth; }
            }
        }
    }
}
