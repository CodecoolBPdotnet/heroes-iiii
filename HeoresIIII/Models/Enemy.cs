﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models
{
    public class Enemy : GameEntity
    {
        public int ExperienceDrop { get; set; }
        public override int Level { get => _level; set => _level = value; }
    }
}
