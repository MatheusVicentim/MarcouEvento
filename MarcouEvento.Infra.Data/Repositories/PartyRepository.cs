using MarcouEvento.Domain.Entities;
using MarcouEvento.Domain.Interface;
using MarcouEvento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MarcouEvento.Infra.Data.Repositories;

public class PartyRepository : IPartyRepository
{
    private ApplicationDbContext _partyDbContext;
    public PartyRepository(ApplicationDbContext context)
    {
        _partyDbContext = context;
    }
    public async Task<Party> Create(Party party)
    {
        _partyDbContext.Add(party);
        await _partyDbContext.SaveChangesAsync();

        return party;
    }

    public async Task<Party> Delete(Party party)
    {
        _partyDbContext.Remove(party);
        await _partyDbContext.SaveChangesAsync();

        return party;
    }

    public async Task<IEnumerable<Party>> GetAllParties()
    {
        return await _partyDbContext.Parties.ToListAsync();
    }

    public async Task<Party> GetById(int id)
    {
        return await _partyDbContext.Parties.FindAsync(id);
    }

    public async Task<Party> Update(Party party)
    {
        _partyDbContext.Update(party);
        await _partyDbContext.SaveChangesAsync();

        return party;
    }
}
