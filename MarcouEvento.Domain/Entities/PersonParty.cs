using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcouEvento.Domain.Entities;

public class PersonParty
{
    public enum EStatus
    {
        Cancelado,
        Confirmado,
        Pendente
    }

    public int Id { get; set; }
    public EStatus Status { get; set; }

    public int PersonId { get; set; }
    public Person? Person { get; set; }

    public int PartyId { get; set; }
    public Party? Party { get; set; }
}