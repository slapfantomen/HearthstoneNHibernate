using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.CardClasses
{
    public class CardSet
    {
        //public CardSet()
        //{
        //    Cards = new List<Card>();
        //}
        public virtual Guid CardSetId { get; set; }
        public virtual string CardSetName { get; set; }
        //public virtual ICollection<Card> Cards { get; set; }

        //public virtual void AddCard(Card c)
        //{
        //    c.CardSet = this;
        //    Cards.Add(c);
        //}
        //public virtual void AddCards(List<Card> cards)
        //{
        //    cards.ForEach(c => AddCard(c));
        //}
    }
}
