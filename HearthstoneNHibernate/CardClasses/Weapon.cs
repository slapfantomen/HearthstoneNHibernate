using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.CardClasses
{
    public class Weapon
    {
        public virtual Guid WeaponId { get; set; }
        public virtual int Attack { get; set; }
        public virtual int Durability { get; set; }
        public virtual Card Card { get; set; }
    }
}
