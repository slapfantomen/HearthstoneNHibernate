using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.CardClasses
{
    public class Ability
    {
        public Ability()
        {
            Cards = new List<Card>();
        }
        public virtual Guid AbilityId { get; set; }
        public virtual string AbilityName { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
