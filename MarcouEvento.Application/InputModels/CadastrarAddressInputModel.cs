using MarcouEvento.Application.DTOs;
using MarcouEvento.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static MarcouEvento.Domain.Entities.Address;

namespace MarcouEvento.Application.InputModels;

public class CadastrarAddressInputModel
{
    public CadastrarAddressInputModel()
    {
        TypeOptions = GetTypeOptions();
    }

    public Address.EType Type { get; set; }
    public IEnumerable<AddressTypeOption> TypeOptions { get; set; }

    [RequiredIf($"{nameof(Latitude)},{nameof(Longitude)}"
        , ErrorMessage = "Rua deve ser preenchido quando Latitude/Longitude não for fornecida")]
    [MaxLength(1000, ErrorMessage = "Nome da rua tem tamanho máximo de 1000 caracteres")]
    [DisplayName("Rua")]
    public string? Streat { get; set; }

    [Required(ErrorMessage = "Número deve ser preenchido")]
    [DisplayName("Número")]
    public int Number { get; set; }

    [RequiredIf($"{nameof(Latitude)},{nameof(Longitude)}"
        , ErrorMessage = "Bairro deve ser preenchido quando Latitude/Longitude não for fornecida")]
    [MaxLength(1000, ErrorMessage = "Nome do bairro tem tamanho máximo de 1000 caracteres")]
    [DisplayName("Bairro")]
    public string? Neighborhood { get; set; }

    [Required(ErrorMessage = "Cidade deve ser preenchido")]
    [MaxLength(1000, ErrorMessage = "Nome da cidade tem tamanho máximo de 1000 caracteres")]
    [DisplayName("Cidade")]
    public string? City { get; set; }

    [Required(ErrorMessage = "UF deve ser preenchido")]
    [MaxLength(2, ErrorMessage = "UF tem tamanho máximo de 2 caracteres")]
    [DisplayName("UF")]
    public string? State { get; set; }

    [Required(ErrorMessage = "CEP deve ser preenchido")]
    [MaxLength(8, ErrorMessage = "CEP tem tamanho máximo de 8 caracteres")]
    [DisplayName("CEP")]
    public string? ZipCode { get; set; }

    public string? Latitude { get; set; }
    public string? Longitude { get; set; }

    [DisplayName("Url Maps")]
    public string? UrlMaps { get; set; }

    [DisplayName("Complemento")]
    public string? Complement { get; set; }


    // Método que retorna todas as opções de enum com status de seleção
    private List<AddressTypeOption> GetTypeOptions()
    {
        var options = Enum.GetValues(typeof(EType))
            .Cast<EType>()
            .Select(t => new AddressTypeOption
            {
                Value = (int)t,
                Name = t.ToString(),
                Description = GetEnumDescription(t),
                IsSelected = (this.Type == t)  // Verifica se é o tipo atual selecionado
            })
            .ToList();

        return options;
    }
}
