using AutoMapper;
using MarcouEvento.Application.DTOs;
using MarcouEvento.Application.Interfaces;
using MarcouEvento.Domain.Entities;
using MarcouEvento.Domain.Interface;

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

    public async Task Add(PartyDTO partyDTO)
    {
        var partyEntity = _mapper.Map<Party>(partyDTO);
        await _partyRepository.Create(partyEntity);
    }

    public async Task AddWithAdministratorAndExpense(PartyDTO partyDTO, AddressDTO addressDTO, ExpenseDTO expenseDTO)
    {
        var addressEntity = _mapper.Map<Address>(addressDTO);
        var addressEntityGravado = await _addressRepository.Create(addressEntity);

        partyDTO.AddressId = addressEntityGravado.Id;
        partyDTO.Address = _mapper.Map<AddressDTO>(addressEntityGravado);

        var partyEntity = _mapper.Map<Party>(partyDTO);
        await _partyRepository.Create(partyEntity);
    }

    public async Task Delete(int id)
    {
        var partyEntity = await _partyRepository.GetById(id);
        if (partyEntity == null)
            throw new NullReferenceException("Party not found");

        await _partyRepository.Delete(partyEntity);
    }

    public async Task<PartyDTO> GetById(int id)
    {
        var partyEntity = await _partyRepository.GetById(id);
        if (partyEntity == null)
            throw new NullReferenceException("Party not found");

        return _mapper.Map<PartyDTO>(partyEntity);
    }

    public async Task<IEnumerable<PartyDTO>> GetParties()
    {
        var partiesEntity = await _partyRepository.GetAllParties();
        return _mapper.Map<IEnumerable<PartyDTO>>(partiesEntity);
    }

    public async Task Update(PartyDTO partyDTO)
    {
        var partyEntity = _mapper.Map<Party>(partyDTO);
        await _partyRepository.Update(partyEntity);
    }
}
