using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models
{
    public class FightResult
    {
        public Enemy DefeatedEnemy { get; set; }
        public List<(string, string)> FightLog { get; set; } = new List<(string, string)>();
        public string FightEndMessage { get; set; }
    }
}
