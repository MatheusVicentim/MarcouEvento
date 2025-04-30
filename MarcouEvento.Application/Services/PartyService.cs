using AutoMapper;
using MarcouEvento.Application.DTOs;
using MarcouEvento.Application.InputModels;
using MarcouEvento.Application.Interfaces;
using MarcouEvento.Application.ViewModels;
using MarcouEvento.Domain.Entities;
using MarcouEvento.Domain.Interface;
using System.Net.WebSockets;

namespace MarcouEvento.Application.Services;

public class PartyService : IPartyService
{
    private readonly IPartyRepository _partyRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;

    public PartyService(IPartyRepository partyRepository, IAddressRepository addressRepository, IMapper mapper)
    {
        _partyRepository = partyRepository;
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(CadastrarPartyInputModel cadastrarPartyInputModel)
    {
        var addressCadastroInputModel = _mapper.Map<CadastrarAddressInputModel>(cadastrarPartyInputModel.Address);
        var addressEntity = new Address(addressCadastroInputModel.Street, addressCadastroInputModel.Type, addressCadastroInputModel.Number,
            addressCadastroInputModel.Neighborhood, addressCadastroInputModel.City, addressCadastroInputModel.State, addressCadastroInputModel.ZipCode,
            addressCadastroInputModel.Latitude, addressCadastroInputModel.Longitude, addressCadastroInputModel.UrlMaps, addressCadastroInputModel.Complement);
        
        addressEntity = await _addressRepository.Create(addressEntity);
        
        var partyEntity = new Party(cadastrarPartyInputModel.Name, cadastrarPartyInputModel.Description, cadastrarPartyInputModel.DateStart, 
            cadastrarPartyInputModel.DateFinish, Party.EStatus.Active, addressEntity.Id);
        
        partyEntity = await _partyRepository.Create(partyEntity);
    }

    //public async Task AddWithAddressAsync(CadastrarAddressInputModel cadastrarAddressInputModel, CadastrarAddressInputModel cadastrarAddressInputModel1)
    //{
    //    var addressEntity = new Address()
    //    var addressEntityGravado = await _addressRepository.Create(addressEntity);

    //    partyDTO.AddressId = addressEntityGravado.Id;
    //    partyDTO.Address = _mapper.Map<AddressDTO>(addressEntityGravado);

    //    var partyEntity = _mapper.Map<Party>(partyDTO);
    //    await _partyRepository.Create(partyEntity);
    //}

    public async Task DeleteAsync(int id)
    {
        var partyEntity = await _partyRepository.GetById(id);
        if (partyEntity == null)
            throw new NullReferenceException("Party not found");

        await _partyRepository.Delete(partyEntity);
    }

    public async Task<PartyDTO> GetByIdAsync(int id)
    {
        var partyEntity = await _partyRepository.GetById(id);
        if (partyEntity == null)
            throw new NullReferenceException("Party not found");

        return _mapper.Map<PartyDTO>(partyEntity);
    }

    public async Task<IEnumerable<PartyViewModel>> GetPartiesAsync()
    {
        try
        {
            var partiesEntity = await _partyRepository.GetAllParties();
            var partiesViewModel = partiesEntity.Select(x => new PartyViewModel(x.Id, x.Name, x.Description, x.DateStart.Date, x.DateFinish, x.AddressId));
            return partiesViewModel;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving parties", ex);
        }
    }

    public async Task UpdateAsync(PartyDTO partyDTO)
    {
        var partyEntity = _mapper.Map<Party>(partyDTO);
        await _partyRepository.Update(partyEntity);
    }
}
