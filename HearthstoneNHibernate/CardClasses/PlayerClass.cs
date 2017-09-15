using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.CardClasses
{
    public class PlayerClass
    {
        //public PlayerClass()
        //{
        //    Cards = new List<Card>();
        //}
        public virtual Guid PlayerClassIdX { get; set; }
        public virtual string ClassName { get; set; }
        //public virtual ICollection<Card> Cards { get; set; }

        //public virtual void AddCard(Card c)
        //{
        //    c.PlayerClass = this;
        //    Cards.Add(c);
        //}
        //public virtual void AddCards(List<Card> cards)
        //{
        //    cards.ForEach(c => AddCard(c));
        //}
    }
}
