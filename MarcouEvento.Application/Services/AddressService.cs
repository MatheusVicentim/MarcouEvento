using AutoMapper;
using MarcouEvento.Application.DTOs;
using MarcouEvento.Application.InputModels;
using MarcouEvento.Application.Interfaces;
using MarcouEvento.Application.ViewModels;
using MarcouEvento.Domain.Entities;
using MarcouEvento.Domain.Interface;

namespace MarcouEvento.Application.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;

    public AddressService(IAddressRepository addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task Add(CadastrarAddressInputModel cadastrarAddressInputModel)
    {
        var addressEntity = new Address(cadastrarAddressInputModel.City, cadastrarAddressInputModel.State,
            cadastrarAddressInputModel.ZipCode, cadastrarAddressInputModel.Latitude, cadastrarAddressInputModel.Longitude,
            cadastrarAddressInputModel.Complement, cadastrarAddressInputModel.UrlMaps);

        await _addressRepository.Create(addressEntity);
    }

    public async Task Delete(int id)
    {
        var addressEntity = await _addressRepository.GetById(id);
        if (addressEntity == null)
        {
            throw new NullReferenceException("Address not found");
        }

        await _addressRepository.Delete(addressEntity);
    }

    public async Task<IEnumerable<AddressViewModel>> GetAddresses()
    {
        var addressesEntity = await _addressRepository.GetAddresses();

        var addressesViewModel = addressesEntity.Select(x =>
           new AddressViewModel(x.Id, x.Type, x.Street, x.Number, x.Neighborhood, x.City, x.State, x.ZipCode, x.Latitude, x.Longitude, x.Complement)
        );

        return addressesViewModel;
    }

    public async Task<AddressDTO> GetById(int id)
    {
        var addressEntity = await _addressRepository.GetById(id);
        return _mapper.Map<AddressDTO>(addressEntity);
    }

    public CadastrarAddressInputModel PreparaInsert()
    {
        return new CadastrarAddressInputModel();
    }

    public async Task Update(AddressDTO addressDTO)
    {
        var addressEntity = _mapper.Map<Address>(addressDTO);
        await _addressRepository.Update(addressEntity);
        await _addressRepository.Update(addressEntity);
    }
}
