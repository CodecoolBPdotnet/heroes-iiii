using System;

namespace HeroesIIII.Models.Skills
{
    public class Learning : Skill
    {
        public Learning(Game game) : base(game)
        {
            Name = "Learning";
            Description = $"Recieve 2 times the experience points for defeating an enemy.";
            game.WinBattleEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var hero = ((Game)sender).Hero;
            var enemy = ((GameEventArgs)e).Enemy as Enemy;
            ((GameEventArgs)e).Result.FightLog.Add(("Hero", $"{hero.Name} learned even more from fighting {enemy.Name}!"));
            Game.GetEnemyExp(enemy);
        }
    }
}
