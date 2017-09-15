using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.CardClasses
{
    public class Card
    {
        public Card()
        {
            Abilities = new List<Ability>();
        }
        public virtual Guid CardId { get; set; }
        public virtual string CardName { get; set; }
        public virtual int Cost { get; set; }
        public virtual ICollection<Ability> Abilities { get; set; }
        public virtual Rarity Rarity { get; set; }
        public virtual PlayerClass PlayerClass { get; set; }
        public virtual CardSet CardSet { get; set; }
        public virtual Guid RarityId { get; set; }
        public virtual string CardText { get; set; }
        public virtual Weapon Weapon { get; set; }
        public virtual Spell Spell { get; set; }
        public virtual void AddSpell(Spell s)
        {
            s.Card = this;
            Spell = s;
        }
        public virtual void AddWeapon(Weapon w)
        {
            w.Card = this;
            Weapon = w;
        }
        public virtual void AddAbility(Ability a)
        {
            a.Cards.Add(this);
            Abilities.Add(a);
        }

    }
}
