using HeroesIIII.Models;
using NSubstitute;
using NUnit.Framework;
using System;

namespace HeroesIIII.Test
{
    [TestFixture]
    public class HeroTest
    {
        private Game _game;
        private Hero _hero;

        [SetUp]
        public void SetUp()
        {
            _hero = new Hero();
            _game = new Game { Hero = _hero };
        }

        [Test]
        public void Hero_GainsExperience_FromEnemy()
        {
            var expectedExp = _hero.Experience + 20;
            var enemy = new Enemy
            {
                ExperienceDrop = 20
            };
            _hero.NextLevelExperienceLimit = 2000;

            _game.GetEnemyExp(enemy);

            Assert.AreEqual(expectedExp, _hero.Experience);
        }

        [Test]
        public void HeroLevelsUp_AfterGainingExperience()
        {
            var expectedLevel = _hero.Level + 1;

            _hero.NextLevelExperienceLimit = 1;
            _hero.Experience += 1;
            var afterLevel = _hero.Level;

            Assert.AreEqual(expectedLevel, afterLevel);
        }

        [Test]
        public void HeroHealth_Decreases_WhenHit()
        {
            var expectedHealth = _hero.CurrentHealth - 10;
            var enemy = new Enemy();

            enemy.Attack(_hero, 10);

            Assert.AreEqual(expectedHealth, _hero.CurrentHealth);
        }

        [Test]
        public void HeroHealth_DoesNotIncrease_WhenDamageNegative()
        {
            var expectedHealth = _hero.CurrentHealth;
            var enemy = new Enemy();

            enemy.Attack(_hero, -12);

            Assert.AreEqual(expectedHealth, _hero.CurrentHealth);
        }


    }
}
