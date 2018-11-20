using HeroesIIII.Models.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace HeroesIIII.Models
{
    public class Hero : GameEntity
    {
        private int _experience;
        public int Experience
        {
            get { return _experience; }
            set
            {
                _experience = value;
                LevelUp();
            }
        }
        public int SkillPoints { get; set; }
        public int NextLevelExperienceLimit { get; set; }
        [NotMapped] // temporary workaround
        public List<Skill> LearnedSkills { get; set; } = new List<Skill>();
        public string Picture { get; set; }

        public void LevelUp()
        {
            if (Experience > NextLevelExperienceLimit)
            {
                _experience -= NextLevelExperienceLimit;
                SkillPoints += 4;
                Level++;
                NextLevelExperienceLimit += 100 + 20 * Level;
            };
        }

        public void Learn(Skill skill)
        {
            LearnedSkills.Add(skill);
        }
    }
}
