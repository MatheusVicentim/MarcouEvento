using MarcouEvento.Application.Interfaces;
using MarcouEvento.Application.Mappings;
using MarcouEvento.Application.Services;
using MarcouEvento.Domain.Interface;
using MarcouEvento.Infra.Data.Context;
using MarcouEvento.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarcouEvento.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
            , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IAdministratorRepository, AdministratorRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IGuestRepository, GuestRepository>();
        services.AddScoped<IPartyRepository, PartyRepository>();

        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IAdministratorService, AdministratoService>();
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IPartyService, PartyService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
