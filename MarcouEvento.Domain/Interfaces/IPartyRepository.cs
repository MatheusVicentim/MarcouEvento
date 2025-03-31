using MarcouEvento.Domain.Entities;

namespace MarcouEvento.Domain.Interface;

public interface IPartyRepository
{
    Task<IEnumerable<Party>> GetAllParties();
    Task<Party> GetById(int id);
    Task<Party> Create(Party party);
    Task<Party> Update(Party party);
    Task<Party> Delete(Party party);
}
