using MarcouEvento.Application.DTOs;
using MarcouEvento.Application.ViewModels;
using MarcouEvento.Application.InputModels;

namespace MarcouEvento.Application.Interfaces;

public interface IAddressService
{
    Task<IEnumerable<AddressViewModel>> GetAddresses();
    Task<AddressDTO> GetById(int id);
    CadastrarAddressInputModel PreparaInsert();
    Task Add(CadastrarAddressInputModel cadastrarAddressInputModel);
    Task Update(AddressDTO addressDTO);
    Task Delete(int id);
}
