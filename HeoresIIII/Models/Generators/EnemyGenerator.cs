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
            HeroGenerator.DistributeAttributePoints(CreatedEnemy, 6 * (HeroLevel));
            return CreatedEnemy;
        }

        private string GenerateRandomEnemyName()
        {
            string RandomlyGeneratedName = "Bandit";
            return RandomlyGeneratedName;
        }
    }
}
