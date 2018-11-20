using System;

namespace HeroesIIII.Models.Skills
{
    public class Learning : Skill
    {
        public Learning(Game game) : base(game)
        {
            Name = "Learning";
            Id = 3;
            game.WinBattleEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var target = ((GameEventArgs)e).Enemy;
            var enemy = target as Enemy;
            Game.GetEnemyExp(enemy);
        }
    }
}
