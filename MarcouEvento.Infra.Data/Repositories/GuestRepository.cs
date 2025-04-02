using MarcouEvento.Domain.Entities;
using MarcouEvento.Domain.Interface;
using MarcouEvento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MarcouEvento.Infra.Data.Repositories;

public class GuestRepository : IGuestRepository
{
    private ApplicationDbContext _guestDbContext;

    public GuestRepository(ApplicationDbContext context)
    {
        _guestDbContext = context;
    }

    public async Task<Guest> Create(Guest guest)
    {
        _guestDbContext.Add(guest);
        await _guestDbContext.SaveChangesAsync();
        return guest;
    }

    public async Task<Guest> Delete(Guest guest)
    {
        _guestDbContext.Remove(guest);
        await _guestDbContext.SaveChangesAsync();

        return guest;
    }

    public async Task<IEnumerable<Guest>> GetAllGuests()
    {
        return await _guestDbContext.Guests.ToListAsync();
    }

    public async Task<Guest> GetById(int id)
    {
        return await _guestDbContext.Guests.FindAsync(id);
    }

    public async Task<Guest> Update(Guest guest)
    {
        _guestDbContext.Update(guest);
        await _guestDbContext.SaveChangesAsync();

        return guest;
    }
}
