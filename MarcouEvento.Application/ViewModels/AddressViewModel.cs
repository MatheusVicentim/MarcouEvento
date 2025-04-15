using MarcouEvento.Domain.Entities;
using System.ComponentModel;

namespace MarcouEvento.Application.ViewModels;

public class AddressViewModel
{
    public AddressViewModel(int id, Address.EType type, string? streat, int number, string? neighborhood, string? city, string? state, string? zipCode, string? latitude, string? longitude, string? complement)
    {
        Id = id;
        Type = type;
        Streat = streat;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        ZipCode = zipCode;
        Latitude = latitude;
        Longitude = longitude;
        Complement = complement;
    }

    public int Id { get; set; }

    public Address.EType Type { get; set; }

    [DisplayName("Rua")]
    public string? Streat { get; set; }

    [DisplayName("Número")]
    public int Number { get; set; }

    [DisplayName("Bairro")]
    public string? Neighborhood { get; set; }

    [DisplayName("Cidade")]
    public string? City { get; set; }

    [DisplayName("UF")]
    public string? State { get; set; }

    [DisplayName("CEP")]
    public string? ZipCode { get; set; }

    public string? Latitude { get; set; }
    public string? Longitude { get; set; }

    [DisplayName("Complemento")]
    public string? Complement { get; private set; }
}