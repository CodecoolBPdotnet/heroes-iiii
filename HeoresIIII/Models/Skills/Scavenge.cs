using System;

namespace HeroesIIII.Models.Skills
{
    public class Scavenge : Skill
    {
        private int _chance = 25;
        public Scavenge(Game game) : base(game)
        {
            Name = "Scavenge";
            Description = $"Adds another {_chance}% chance of getting an item from the enemy after battle.";
            game.WinBattleEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var log = ((GameEventArgs)e).Result.FightLog;
            var target = ((GameEventArgs)e).Enemy;
            var enemy = target as Enemy;
            if (new Random().Next(100) < _chance) { 
                Game.GetEnemyDrops(enemy);
                log.Add(("Hero", "Error: Scavenge skill not implemented yet"));
            }
        }
    }
}
