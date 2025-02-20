using MarcouEvento.Domain.Entities;

namespace MarcouEvento.Domain.Interface;

public interface IAdministrator
{
    Task<IEnumerable<Administrator>> Get();
    Task<Administrator> GetById(int id);
    Task<Administrator> Create(Administrator administrator);
    Task<Administrator> Update(Administrator administrator);
    Task<Administrator> Delete(Administrator administrator);
    Task<Administrator> ActivateParty();
    //Task<Administrator> ActivateParty();
    //Task<Administrator> InactiveParty();
}
