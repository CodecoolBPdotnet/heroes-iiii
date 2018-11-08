using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models.Generators
{
    public class EnemyGenerator
    {
        public Enemy GenerateRandomEnemy(int HeroLevel)
        {
            var CreatedEnemy = new Enemy()
            {
                Name = GenerateRandomEnemyName(),
                Level = HeroLevel,
                ExperienceDrop = 20 + (5 * HeroLevel),
                MaximumHealth = 10 * (5 + HeroLevel),
                CurrentHealth = 10 * (5 + HeroLevel)
            };
            HeroGenerator.DistributeAttributePoints(CreatedEnemy, 5*(2 + HeroLevel));
            return CreatedEnemy;
        }

        private string GenerateRandomEnemyName()
        {
            string RandomlyGeneratedName = "Bandit";
            return RandomlyGeneratedName;
        }
    }
}
