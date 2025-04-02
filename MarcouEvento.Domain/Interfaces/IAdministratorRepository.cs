using MarcouEvento.Domain.Entities;

namespace MarcouEvento.Domain.Interface;

public interface IAdministratorRepository
{
    Task<IEnumerable<Administrator>> GetAllAdministrators();
    Task<Administrator> GetById(int id);
    Task<Administrator> Create(Administrator administrator);
    Task<Administrator> Update(Administrator administrator);
    Task<Administrator> Delete(Administrator administrator);
    Task<Administrator> Activate(int id);
    //Task<Administrator> ActivateParty();
    //Task<Administrator> InactiveParty();
}
