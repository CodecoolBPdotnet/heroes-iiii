using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroesIIII.Models.Generators;

namespace HeroesIIII.Models
{
    public class Game
    {
        public Account Account { get; set; }

        public Hero Hero { get; set; }

        public void Fight(Enemy enemy)
        {
            double HeroTurn = 0;
            double EnemyTurn = 0;
            while(Hero.CurrentHealth > 0 && enemy.CurrentHealth > 0)
            {
                HeroTurn += 1 + Hero.Agility * 0.25;
                if (HeroTurn > 100)
                {
                    Hero.Attack(enemy);
                }
                EnemyTurn += 1 + enemy.Agility * 0.25;
                if (EnemyTurn > 100)
                {
                    enemy.Attack(Hero);
                }
            }
            if (Hero.CurrentHealth > 0)
            {
                Hero.Experience += enemy.ExperienceDrop;
                Hero.CurrentHealth += (int) (Hero.MaximumHealth * 0.20);
                if (Hero.CurrentHealth > Hero.MaximumHealth) { Hero.CurrentHealth = Hero.MaximumHealth; }
            }
        }

        internal void Fight()
        {

            var EnemyGenerator = new EnemyGenerator();
            Fight(EnemyGenerator.GenerateRandomEnemy(Hero.Level));
        }
    }
}
