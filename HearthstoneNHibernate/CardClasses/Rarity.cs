using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.CardClasses
{
    public class Rarity
    {
        public virtual Guid RarityId { get; set; }
        public virtual string RarityName { get; set; }
        public virtual Card Card { get; set; }

        public virtual void AddCard(Card c)
        {
            Card = c;
            c.Rarity = this;      
        }
    }
}
