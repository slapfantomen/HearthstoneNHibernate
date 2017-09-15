using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.CardClasses
{
    public class Race
    {
        public virtual Guid RaceId { get; set; }
        public virtual string RaceName { get; set; }
        public virtual ICollection<Minion> Minions { get; set; }
    }
}
