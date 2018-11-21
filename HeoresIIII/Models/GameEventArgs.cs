using System;

namespace HeroesIIII.Models
{
    public class GameEventArgs : EventArgs
    {
        public Hero Hero;
        public GameEntity Enemy;
    }
}
