using MarcouEvento.Application.DTOs;
using MarcouEvento.Application.ViewModels;
using MarcouEvento.Application.InputModels;

namespace MarcouEvento.Application.Interfaces;

public interface IAddressService
{
    Task<IEnumerable<AddressViewModel>> GetAddresses();
    Task<AddressViewModel> GetById(int id);
    CadastrarAddressInputModel PreparaInsert();
    Task Add(CadastrarAddressInputModel cadastrarAddressInputModel);
    Task<EditAddressInputModel> PraparaUpdate(int id);
    Task Update(EditAddressInputModel addressDTO);
    Task Delete(int id);
}
