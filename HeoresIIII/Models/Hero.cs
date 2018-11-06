using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models
{
    public class Hero
    {
        private int _experience;

        public int Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }
        public int SkillPoinnts { get; set; }
        public int NextLevelExperienceLimit { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Skill> Skills { get; set; }
        public string Picture { get; set; }

        void LevelUp()
        {
            throw new NotImplementedException();
        }
    }
}
