using static MarcouEvento.Domain.Entities.Address;

namespace MarcouEvento.Application.InputModels;

public class AddressTypeOption
{
    public string? Description { get; set; }
    public bool IsSelected { get; set; }
    public string? Name { get; set; }
    public int Value { get; set; }
}