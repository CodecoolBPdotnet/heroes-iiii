using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace HeroesIIII.Models.Generators
{
    public class HeroGenerator
    {
        public Hero GenerateNewRandomHero()
        {
            Hero CreatedHero = new Hero
            {
                Name = GenerateRandomHeroName(),
                Level = 1,
                MaximumHealth = 100,
                CurrentHealth = 100,
                NextLevelExperienceLimit = 100
            };
            DistributeAttributePoints(CreatedHero, 60);

            return CreatedHero;
        }

        private string GenerateRandomHeroName()
        {
            HttpClient client = new HttpClient();

            string response = client.GetStringAsync("http://names.drycodes.com/10?nameOptions=funnyWords").Result;
            var data = JsonConvert.DeserializeObject<List<string>>(response);
            string RandomlyGeneratedName = data[0].Replace("_"," ");
            return RandomlyGeneratedName;
        }

        public static void DistributeAttributePoints(GameEntity target, double avaliablePoints)
        {
            Random rnd = new Random();
            int minimumAttribute = (int)Math.Round(avaliablePoints / 5, 0);
            target.Damage = rnd.Next(minimumAttribute, (int)(Math.Round(avaliablePoints/4,0) + 3));
            avaliablePoints -= target.Damage;
            target.Defense = rnd.Next(minimumAttribute, (int)(Math.Round(avaliablePoints / 3, 0) + 3));
            avaliablePoints -= target.Defense;
            target.Agility = rnd.Next(minimumAttribute, (int)(Math.Round(avaliablePoints / 2, 0) + 3));
            avaliablePoints -= target.Agility;
            target.Vitality = (int)avaliablePoints;
            target.MaximumHealth += 10 * target.Vitality;
            target.CurrentHealth = target.MaximumHealth;
        }
    }
}
