using MarcouEvento.Application.DTOs;

namespace MarcouEvento.Application.Interfaces;

public interface IGuestService
{
    Task<IEnumerable<GuestDTO>> GetGuests();
    Task<GuestDTO> GetById(int id);
    Task Add(GuestDTO guestDTO);
    Task Update(GuestDTO guestDTO);
    Task Delete(int id);
}