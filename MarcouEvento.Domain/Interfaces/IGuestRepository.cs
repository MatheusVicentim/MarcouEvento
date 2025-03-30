using MarcouEvento.Domain.Entities;

namespace MarcouEvento.Domain.Interface;

public interface IGuestRepository
{
    Task<IEnumerable<Guest>> Get();
    Task<Guest> GetById(int id);
    Task<Guest> Create(Guest guest);
    Task<Guest> Update(Guest guest);
    Task<Guest> Delete(Guest guest);
}
