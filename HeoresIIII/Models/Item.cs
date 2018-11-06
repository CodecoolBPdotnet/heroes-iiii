using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesIIII.Models
{
    public class Item : GameObject
    {
        public string AttributeToModify { get; set; }

        public int ModificationAmount { get; set; }

        void PickUp()
        {
            throw new NotImplementedException();
        }
    }
}
