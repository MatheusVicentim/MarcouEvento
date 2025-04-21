using MarcouEvento.Domain.Entities;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace MarcouEvento.Application.ViewModels;

public class AddressViewModel
{
    public AddressViewModel(int id, Address.EType type, string? streat, int number, string? neighborhood, string? city, string? state, string? zipCode, string? latitude, string? longitude, string? complement, string? urlMaps)
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
        UrlMaps = urlMaps;
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

    private string? _ZipCode;
    [DisplayName("CEP")]
    public string? ZipCode
    {
        get => _ZipCode;
        set => _ZipCode = Regex.Replace(value, "^(\\d{5})(\\d{1,3}).*", "$1-$2");
    }

    public string? Latitude { get; set; }
    public string? Longitude { get; set; }

    [DisplayName("Url Maps")]
    public string? UrlMaps { get; set; }

    [DisplayName("Complemento")]
    public string? Complement { get; private set; }
}