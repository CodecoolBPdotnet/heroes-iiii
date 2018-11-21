using HeroesIIII.Models.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HeroesIIII.Models
{
    public class Hero : GameEntity
    {
        private int _skillBaseChance = 15;

        public event EventHandler NewSkillEvent;
        public void OnNewSkillEvent() => NewSkillEvent?.Invoke(this, null);
        
        private int _experience;
        private int chance;

        public int Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                while (Experience >= NextLevelExperienceLimit)
                    LevelUp();
            }
        }
        public override int Level
        {
            get => _level;
            set
            {
                _level = value;
            }
        }
        public int SkillPoints { get; set; }
        public int NextLevelExperienceLimit { get; set; }
        
        [NotMapped]
        public List<Type> LearnedSkills { get; set; } = new List<Type>();

        // Wrapper for Learned Skills so that it's possible to save a list of them to the database (as a long string)
        [Column("LearnedSkills")]
        public string LearnedSkillString
        {
            get => string.Join("-!-", LearnedSkills.ConvertAll(skill => skill?.FullName));

            set
            {
                var list = value.Split("-!-").Select(name => Type.GetType(name)).ToList();
                LearnedSkills = list.First() == null ? new List<Type>() : list;
            }
        }

        [NotMapped]
        public List<Type> Skills { get; set; } = new List<Type> // TODO turn into an enum
        {
            typeof(CounterAttack),
            typeof(Regenerate),
            typeof(Learning),
            typeof(Scavenge),
            typeof(CriticalStrike),
            typeof(Revive)
        };
        public string Picture { get; set; }
        public void LevelUp()
        {
            ++Level;
            _experience -= NextLevelExperienceLimit;
            SkillPoints += 4;
            NextLevelExperienceLimit += 100 + 20 * Level;
            int chance = _skillBaseChance * ((Level + 1) / (LearnedSkills.Count + 1));
            if (new Random().Next(100) < chance)
                OnNewSkillEvent();
        }
    }
}
