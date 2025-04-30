using MarcouEvento.Application.DTOs;
using MarcouEvento.Application.InputModels;
using MarcouEvento.Application.ViewModels;

namespace MarcouEvento.Application.Interfaces;

public interface IPartyService
{
    Task<IEnumerable<PartyViewModel>> GetPartiesAsync();
    Task<PartyDTO> GetByIdAsync(int id);
    Task AddAsync(CadastrarPartyInputModel cadastrarPartyInputModel);
    Task UpdateAsync(PartyDTO partyDTO);
    Task DeleteAsync(int id);
}
