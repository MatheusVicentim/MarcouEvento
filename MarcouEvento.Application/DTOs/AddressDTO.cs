using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcouEvento.Application.DTOs;

public class AddressDTO
{
    public int Id { get; set; }

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

    [DisplayName("Complemento")]
    public string? Complement { get; private set; }
}


public class RequiredIfAttribute : ValidationAttribute
{
    private readonly string _dependentProperties;

    public RequiredIfAttribute(string dependentProperty)
    {
        _dependentProperties = dependentProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        foreach (string _dependentProperty in _dependentProperties.Split(","))
        {
            var dependentValue = validationContext.ObjectType.GetProperty(_dependentProperty).GetValue(validationContext.ObjectInstance, null);
            if (string.IsNullOrWhiteSpace(dependentValue?.ToString()) && string.IsNullOrWhiteSpace(value?.ToString()))
            {
                return new ValidationResult(ErrorMessage ?? $"Campo obrigatório quando {_dependentProperty} não está preenchido");
            }
        }
        //var dependentValue = validationContext.ObjectType.GetProperty(_dependentProperties).GetValue(validationContext.ObjectInstance, null);

        //if (string.IsNullOrWhiteSpace(dependentValue?.ToString()) && string.IsNullOrWhiteSpace(value?.ToString()))
        //{
        //    return new ValidationResult(ErrorMessage ?? $"Campo obrigatório quando {_dependentProperties} não está preenchido");
        //}

        return ValidationResult.Success;
    }
}