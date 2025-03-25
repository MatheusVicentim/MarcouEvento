using MarcouEvento.Application.DTOs;

namespace MarcouEvento.Application.Interfaces;

public interface IPartyService
{
    Task<IEnumerable<PartyDTO>> GetParties();
    Task<PartyDTO> GetById(int id);
    Task Add(PartyDTO partyDTO);
    Task Update(PartyDTO partyDTO);
    Task Delete(int id);

    Task AddWithAdministratorAndExpense(PartyDTO partyDTO,AddressDTO addressDTO, ExpenseDTO expenseDTO);
}
