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

    public int AdministratorId { get; set; }
    public Administrator? Administrator { get; set; }
    public int GuestId { get; set; }
    public Guest? Guest { get; set; }

    public int PartyId { get; set; }
    public Party? Party { get; set; }
}