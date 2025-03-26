using AutoMapper;
using MarcouEvento.Application.DTOs;
using MarcouEvento.Domain.Entities;

namespace MarcouEvento.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Address, AddressDTO>().ReverseMap();
        CreateMap<Administrator, AdministratorDTO>().ReverseMap();
        CreateMap<Expense, ExpenseDTO>().ReverseMap();
        CreateMap<Guest, GuestDTO>().ReverseMap();
        CreateMap<Party, PartyDTO>().ReverseMap();
    }
}
