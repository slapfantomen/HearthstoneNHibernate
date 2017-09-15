using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.Domain
{
    class Player
    {
        public virtual Guid Id { get; set; }
        public virtual int Age { get; set; }
        public virtual string Name { get; set; }
    }
}
