using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.CardClasses
{
    public class Spell
    {
        public virtual Guid SpellId { get; set; }
        public virtual int Damage { get; set; }
        public virtual int Heal { get; set; }
        public virtual bool ToAll { get; set; }
        public virtual Card Card { get; set; }
    }
}
