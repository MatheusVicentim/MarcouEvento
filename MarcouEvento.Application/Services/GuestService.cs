using AutoMapper;
using MarcouEvento.Application.DTOs;
using MarcouEvento.Application.Interfaces;
using MarcouEvento.Domain.Entities;
using MarcouEvento.Domain.Interface;

namespace MarcouEvento.Application.Services;

public class GuestService : IGuestService
{
    private readonly IGuestRepository _guestRepository;
    private readonly IMapper _mapper;
    public GuestService(IGuestRepository guestRepository, IMapper mapper)
    {
        _guestRepository = guestRepository;
        _mapper = mapper;
    }

    public async Task Add(GuestDTO guestDTO)
    {
        var guestEntity = _mapper.Map<Guest>(guestDTO);
        await _guestRepository.Create(guestEntity);
    }

    public async Task Delete(int id)
    {
        var guestEntity = await _guestRepository.GetById(id);
        if (guestEntity == null)
        {
            throw new NullReferenceException("Guest not found");
        }
        await _guestRepository.Delete(guestEntity);
    }

    public async Task<GuestDTO> GetById(int id)
    {
        var guestEntity = await _guestRepository.GetById(id);
        if (guestEntity == null)
            throw new NullReferenceException("Guest not found");

        return _mapper.Map<GuestDTO>(guestEntity);
    }

    public async Task<IEnumerable<GuestDTO>> GetGuests()
    {
        var guestsEntity = await _guestRepository.GetAllGuests();
        return _mapper.Map<IEnumerable<GuestDTO>>(guestsEntity);
    }

    public async Task Update(GuestDTO guestDTO)
    {
        var guestEntity = _mapper.Map<Guest>(guestDTO);
        await _guestRepository.Update(guestEntity);
    }
}
