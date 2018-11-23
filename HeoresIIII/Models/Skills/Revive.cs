using System;

namespace HeroesIIII.Models.Skills
{
    public class Revive : Skill
    {
        private int _chance = 60;
        private int _remainingLives = 1;
        public Revive(Game game) : base(game)
        {
            Name = "Revive";
            Description = $"Has a {_chance}% of reviving the Hero {_remainingLives} time(s).";
            game.DeathEvent += Effect;
        }

        public override void Effect(object sender, EventArgs e)
        {
            var log = ((GameEventArgs)e).Result.FightLog;
            var hero = ((Game)sender).Hero;
            if (new Random().Next(100) > _chance || _remainingLives < 1) return;
            
            hero.CurrentHealth = hero.MaximumHealth * _chance / 100;
            var message = ("Hero", $"{hero.Name} revived with {hero.CurrentHealth} health points, ");
            if (_remainingLives-- == 1)
            {
                message.Item2 += $"but it's their last life now!)";
            }
            else
            {
                message.Item2 += $"and they still have {_remainingLives} lives left.)";
            }
            log.Add(message);
        }
    }
}
