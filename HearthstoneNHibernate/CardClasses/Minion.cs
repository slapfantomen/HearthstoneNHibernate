using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.CardClasses
{
    public class Minion
    {
        public virtual Guid MinionId { get; set; }
        public virtual int Attack { get; set; }
        public virtual int Health { get; set; }
        public virtual Card Card { get; set; }
        public virtual Race Race { get; set; }
    }
}
