using MarcouEvento.Domain.Entities;
using MarcouEvento.Domain.Interface;
using MarcouEvento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MarcouEvento.Infra.Data.Repositories;

public class AdministratorRepository : IAdministratorRepository
{
    private ApplicationDbContext _administratorContext;

    public AdministratorRepository(ApplicationDbContext context)
    {
        _administratorContext = context;
    }
    public async Task<Administrator> Activate(int id)
    {
        // Busca o administrador pelo ID
        var administrator = await _administratorContext.Administrators
            .FindAsync(id);

        if (administrator == null)
        {
            throw new KeyNotFoundException($"Administrador com ID {id} não encontrado.");
        }

        // Ativa o administrador
        administrator.Status = Administrator.EStatus.Ativo;

        // Atualiza apenas a propriedade modificada
        _administratorContext.Entry(administrator).Property(x => x.Status).IsModified = true;

        // Salva as alterações no banco de dados
        await _administratorContext.SaveChangesAsync();

        return administrator;
    }

    public async Task<Administrator> Create(Administrator administrator)
    {
        _administratorContext.Add(administrator);
        await _administratorContext.SaveChangesAsync();

        return administrator;
    }

    public async Task<Administrator> Delete(Administrator administrator)
    {
        _administratorContext.Remove(administrator);
        await _administratorContext.SaveChangesAsync();

        return administrator;
    }

    public async Task<IEnumerable<Administrator>> GetAllAdministrators()
    {
        return  await _administratorContext.Administrators.ToListAsync();
    }

    public async Task<Administrator> GetById(int id)
    {
        return await _administratorContext.Administrators.FindAsync(id);
    }

    public async Task<Administrator> Update(Administrator administrator)
    {
        _administratorContext.Update(administrator);
        await _administratorContext.SaveChangesAsync();

        return administrator;
    }
}
