using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.CardClasses
{
    public class PlayerClass
    {
        public virtual Guid PlayerClassId { get; set; }
        public virtual string ClassName { get; set; }
        public virtual Card Card { get; set;  }

        public virtual void AddCard(Card c)
        {
            Card = c;
            c.PlayerClass = this;
        }
    }
}
