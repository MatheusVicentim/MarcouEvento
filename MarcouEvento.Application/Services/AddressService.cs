using AutoMapper;
using MarcouEvento.Application.DTOs;
using MarcouEvento.Application.Interfaces;
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

    public async Task Add(AddressDTO addressDTO)
    {
        var addressEntity = _mapper.Map<Address>(addressDTO);
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

    public async Task<IEnumerable<AddressDTO>> GetAddresses()
    {
        var addressesEntity = await _addressRepository.GetAddresses();

        return _mapper.Map<IEnumerable<AddressDTO>>(addressesEntity);
    }

    public async Task<AddressDTO> GetById(int id)
    {
        var addressEntity = await _addressRepository.GetById(id);
        return _mapper.Map<AddressDTO>(addressEntity);
    }

    public async Task Update(AddressDTO addressDTO)
    {
        var addressEntity = _mapper.Map<Address>(addressDTO);
        await _addressRepository.Update(addressEntity);
        await _addressRepository.Update(addressEntity);
    }
}
