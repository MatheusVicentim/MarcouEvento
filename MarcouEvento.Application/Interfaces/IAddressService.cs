using MarcouEvento.Application.DTOs;

namespace MarcouEvento.Application.Interfaces;

public interface IAddressService
{
    Task<IEnumerable<AddressDTO>> GetAddresses();
    Task<AddressDTO> GetById(int id);
    Task Add(AddressDTO addressDTO);
    Task Update(AddressDTO addressDTO);
    Task Delete(int id);
}
