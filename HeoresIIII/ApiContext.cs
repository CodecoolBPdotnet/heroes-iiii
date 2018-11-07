using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HeroesIIII.Models;
using HeroesIIII.Models.Skills;

namespace HeroesIIII
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Hero> Heroes { get; set; }

        public DbSet<Account> Accounts { get; set; }

        
    }
}
