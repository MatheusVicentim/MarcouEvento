using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcouEvento.Domain.Entities
{
    class PersonParty
    {
        public int PersonId { get; set; }
        public Person? Person { get; set; }

        public int PartyId { get; set; }
        public Party? Party { get; set; }
    }
}
