using System;
using HeroesIIII.Models.Generators;

namespace HeroesIIII.Models
{
    public class GameEventArgs : EventArgs
    {
        public GameEntity Target;
    }
    public class Game
    {
        public event EventHandler AttackEvent;
        public event EventHandler GetHitEvent;
        public event EventHandler WinBattleEvent;
        public event EventHandler LevelUpEvent;
        public event EventHandler DeathEvent;
        public void OnAttackEvent(GameEventArgs e) => AttackEvent?.Invoke(this, e);
        public void OnGetHitEvent(GameEventArgs e) => GetHitEvent?.Invoke(this, e);
        public void OnWinBattleEvent(GameEventArgs e) => WinBattleEvent?.Invoke(this, e);
        public void OnLevelUpEvent(GameEventArgs e) => LevelUpEvent?.Invoke(this, e);
        public void OnDeathEvent(GameEventArgs e) => DeathEvent?.Invoke(this, e);

        public int Id { get; set; }

        public Account Account { get; set; }
        public Hero Hero { get; set; }

        public void Fight(Enemy enemy)
        {
            double HeroTurn = 0;
            double EnemyTurn = 0;
            while (Hero.CurrentHealth > 0 && enemy.CurrentHealth > 0)
            {
                HeroTurn += 3 + Hero.Agility * 0.25;
                if (HeroTurn > 100)
                {
                    Hero.Attack(enemy);
                    OnAttackEvent(new GameEventArgs { Target = enemy });
                    HeroTurn -= 100;
                }
                EnemyTurn += 3 + enemy.Agility * 0.25;
                if (EnemyTurn > 100)
                {
                    enemy.Attack(Hero);
                    EnemyTurn -= 100;
                }
            }
            if (Hero.CurrentHealth > 0)
            {
                Hero.Experience += enemy.ExperienceDrop;
                Hero.CurrentHealth += (int)(Hero.MaximumHealth * 0.20);
                if (Hero.CurrentHealth > Hero.MaximumHealth)
                    Hero.CurrentHealth = Hero.MaximumHealth;
            }
        }

        internal void Fight()
        {

            var EnemyGenerator = new EnemyGenerator();
            Fight(EnemyGenerator.GenerateRandomEnemy(Hero.Level));
        }
    }
}
