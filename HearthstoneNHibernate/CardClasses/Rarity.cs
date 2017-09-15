using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.CardClasses
{
    public class Rarity
    {
        //public Rarity()
        //{
        //    Cards = new List<Card>();
        //}
        public virtual Guid RarityId { get; set; }
        public virtual string RarityName { get; set; }
        //public virtual ICollection<Card> Cards { get; set; }

        //public virtual void AddCard(Card c)
        //{
        //    c.Rarity = this;
        //    Cards.Add(c);
        //}
        //public virtual void AddCards(List<Card> cards)
        //{
        //    cards.ForEach(c => AddCard(c));
        //}
    }
}
