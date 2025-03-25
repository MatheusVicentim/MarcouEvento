using MarcouEvento.Application.DTOs;

namespace MarcouEvento.Application.Interfaces;

public interface IAdministratorService
{
    Task<IEnumerable<AdministratorDTO>> GetAdministrators();
    Task<AdministratorDTO> GetById(int id);
    Task Add(AdministratorDTO administratorDTO);
    Task Update(AdministratorDTO administratorDTO);
    Task Delete(int id);
}
