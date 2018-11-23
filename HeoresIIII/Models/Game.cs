using HeroesIIII.Models.Generators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesIIII.Models
{
    public class Game
    {
        public event EventHandler AttackEvent; // replace all the EventHandlers with custom delegates
        public event EventHandler GetHitEvent;
        public event EventHandler WinBattleEvent;
        public event EventHandler DeathEvent;
        public void OnAttackEvent(GameEventArgs e) => AttackEvent?.Invoke(this, e);
        public void OnGetHitEvent(GameEventArgs e) => GetHitEvent?.Invoke(this, e);
        public void OnWinBattleEvent(GameEventArgs e) => WinBattleEvent?.Invoke(this, e);
        public void OnDeathEvent(GameEventArgs e) => DeathEvent?.Invoke(this, e);

        public int Id { get; set; }
        public Account Account { get; set; }

        private Hero _hero;
        public Hero Hero
        {
            get => _hero;
            set
            {
                _hero = value;
                _hero.NewSkillEvent += NewSkill;
            }
        }

        private void NewSkill(object sender, EventArgs e)
        {
            List<Type> availableSkills = Hero.Skills.Except(Hero.LearnedSkills).ToList();
            if (availableSkills.Count < 1) return;

            var randSkill = availableSkills[new Random().Next(availableSkills.Count - 1)];
            randSkill
                .GetConstructor(new Type[] { GetType() })
                .Invoke(new object[] { this });
            Hero.Skills.Remove(randSkill);
        }

        public FightResult Fight()
        {
            var EnemyGenerator = new EnemyGenerator();
            var result = Fight(EnemyGenerator.GenerateRandomEnemy(Hero.Level));
            return result;
        }
        public FightResult Fight(Enemy enemy)
        {
            FightResult fightresult = new FightResult();
            fightresult.DefeatedEnemy = enemy;
            var eventArgs = new GameEventArgs { Enemy = enemy, Result = fightresult };
            double HeroTurn = 0;
            double EnemyTurn = 0;
            while (Hero.CurrentHealth > 0 && enemy.CurrentHealth > 0)
            {
                HeroTurn += 3 + Hero.Agility * 0.25;
                if (HeroTurn > 100)
                {
                    fightresult.FightLog.Add(("Hero", $"{Hero.FirstName} dealt {Hero.Attack(enemy)} damage to the {enemy.Name}"));
                    OnAttackEvent(eventArgs);
                    HeroTurn -= 100;
                }
                EnemyTurn += 3 + enemy.Agility * 0.25;
                if (EnemyTurn > 100)
                {
                    fightresult.FightLog.Add(("Enemy", $"{enemy.Name} dealt {enemy.Attack(Hero)} damage to the Hero "));
                    OnGetHitEvent(eventArgs);
                    EnemyTurn -= 100;
                }
            }
            if (Hero.CurrentHealth > 0)
            {
                Hero.Experience += enemy.ExperienceDrop;
                fightresult.FightEndMessage = $"You defeated {enemy.Name} and you gained {enemy.ExperienceDrop}";
                OnWinBattleEvent(eventArgs);
            }
            else
            {
                // TODO battle lost, hero death
                fightresult.FightEndMessage = $"You were killed by {enemy.Name}";
                OnDeathEvent(eventArgs);
            }
            return fightresult;
        }

        public void WinBattle(Enemy enemy)
        {
            GetEnemyExp(enemy);
            // TODO add a random chance to get items
            GetEnemyDrops(enemy);

        }

        public void GetEnemyExp(Enemy enemy)
        {
            Hero.Experience += enemy.ExperienceDrop;
        }
        public void GetEnemyDrops(Enemy enemy)
        {
            // TODO uncomment once items are implemented
            // Hero.Items += enemy.Items;
        }
    }
}
