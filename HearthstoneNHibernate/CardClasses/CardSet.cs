using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.CardClasses
{
    public class CardSet
    {
        public virtual Guid CardSetId { get; set; }
        public virtual string CardSetName { get; set; }
        public virtual Card Card { get; set; }

        public virtual void AddCard(Card c)
        {
            Card = c;
            c.CardSet = this;
        }
    }
}
