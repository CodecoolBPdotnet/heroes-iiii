using System;

namespace HeroesIIII.Models.Skills
{
    public class Scavenge : Skill
    {
        private int _percentChance = 25;
        private Random _random = new Random();

        public Scavenge(Hero hero, Game game) : base(game)
        {
            Name = "Scavenge";
            Id = 6;
            game.WinBattleEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var target = ((GameEventArgs)e).Target;
            var enemy = target as Enemy;

            if (_random.Next(100) > _percentChance)
                Game.GetEnemyDrops(enemy);
        }
    }
}
