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
        var addressEntity = new Address(cadastrarAddressInputModel.City, cadastrarAddressInputModel.Type, cadastrarAddressInputModel.Number,
            cadastrarAddressInputModel.Neighborhood, cadastrarAddressInputModel.City, cadastrarAddressInputModel.State, cadastrarAddressInputModel.ZipCode,
            cadastrarAddressInputModel.Latitude, cadastrarAddressInputModel.Longitude, cadastrarAddressInputModel.UrlMaps, cadastrarAddressInputModel.Complement);

        addressEntity.RemoveMaskZipCode();

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
           new AddressViewModel(x.Id, x.Type, x.Street, x.Number, x.Neighborhood, x.City, x.State, x.ZipCode, x.Latitude, x.Longitude, x.Complement, x.UrlMaps)
        );

        return addressesViewModel;
    }

    public async Task<AddressViewModel> GetById(int id)
    {
        var addressEntity = await _addressRepository.GetById(id);
        var addressViewModel = new AddressViewModel(addressEntity.Id, addressEntity.Type, addressEntity.Street, addressEntity.Number,
            addressEntity.Neighborhood, addressEntity.City, addressEntity.Street, addressEntity.ZipCode, addressEntity.Latitude,
            addressEntity.Longitude, addressEntity.Complement, addressEntity.UrlMaps);

        return addressViewModel;
    }

    public async Task<EditAddressInputModel> PraparaUpdate(int id)
    {
        var addressEntity = await _addressRepository.GetById(id);
        var addressCdastrarInputModel = new EditAddressInputModel
        {
            Id = addressEntity.Id,
            Type = addressEntity.Type,
            Street = addressEntity.Street,
            Number = addressEntity.Number,
            Neighborhood = addressEntity.Neighborhood,
            City = addressEntity.City,
            State = addressEntity.State,
            ZipCode = addressEntity.ZipCode,
            Latitude = addressEntity.Latitude,
            Longitude = addressEntity.Longitude,
            Complement = addressEntity.Complement,
            UrlMaps = addressEntity.UrlMaps
        };

        return addressCdastrarInputModel;
    }

    public CadastrarAddressInputModel PreparaInsert()
    {
        return new CadastrarAddressInputModel();
    }

    public async Task Update(EditAddressInputModel editAddressInputModel)
    {
        if (editAddressInputModel == null)
            throw new NullReferenceException("Address not found");

        var addressEntity = new Address(editAddressInputModel.Id, editAddressInputModel.Street, editAddressInputModel.Number, editAddressInputModel.Neighborhood,
            editAddressInputModel.City, editAddressInputModel.State, editAddressInputModel.ZipCode, editAddressInputModel.Latitude, editAddressInputModel.Longitude,
            editAddressInputModel.Complement, editAddressInputModel.UrlMaps, editAddressInputModel.Type);
        await _addressRepository.Update(addressEntity);
    }
}
