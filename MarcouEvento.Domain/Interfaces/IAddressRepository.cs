using MarcouEvento.Domain.Entities;

namespace MarcouEvento.Domain.Interface;

public interface IAddressRepository
{
    Task<IEnumerable<Address>> GetAddresses();
    Task<Address> GetById(int id);
    Task<Address> Create(Address address);
    Task<Address> Update(Address address);
    Task<Address> Delete(Address address);
}
