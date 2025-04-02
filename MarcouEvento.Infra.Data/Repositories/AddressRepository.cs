using MarcouEvento.Domain.Entities;
using MarcouEvento.Domain.Interface;
using MarcouEvento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MarcouEvento.Infra.Data.Repositories;

public class AddressRepository : IAddressRepository
{
    private ApplicationDbContext _addressContext;

    public AddressRepository(ApplicationDbContext context)
    {
        _addressContext = context;
    }

    public async Task<Address> Create(Address address)
    {
        _addressContext.Add(address);
        await _addressContext.SaveChangesAsync();

        return address;
    }

    public async Task<Address> Delete(Address address)
    {
        _addressContext.Remove(address);
        await _addressContext.SaveChangesAsync();

        return address;
    }

    public async Task<IEnumerable<Address>> GetAddresses()
    {
        return await _addressContext.Addresses.ToListAsync();
    }

    public async Task<Address> GetById(int id)
    {
        return await _addressContext.Addresses.FindAsync(id);
    }

    public async Task<Address> Update(Address address)
    {
        _addressContext.Update(address);
        await _addressContext.SaveChangesAsync();

        return address;
    }
}
