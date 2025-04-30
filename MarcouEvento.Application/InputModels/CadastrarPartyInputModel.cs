using MarcouEvento.Application.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MarcouEvento.Application.InputModels;

public class CadastrarPartyInputModel
{

    public CadastrarPartyInputModel()
    {
        DateStart = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
        DateFinish = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
    }
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome deve ser preenchido")]
    [MaxLength(100, ErrorMessage = "Nome tem tamanho máximo de 100 caracteres")]
    [DisplayName("Nome")]
    public string? Name { get; set; }

    [MaxLength(1000, ErrorMessage = "Descrição tem tamanho máximo de 1000 caracteres")]
    [DisplayName("Descrição")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Data de início deve ser preenchida")]
    [DisplayName("Data de início")]
    public DateTime DateStart { get ; set; }

    [Required(ErrorMessage = "Data de término deve ser preenchida")]
    [DisplayName("Data de término")]
    public DateTime DateFinish { get; set; }

    public int AddressId { get; set; }
    public CadastrarAddressInputModel? Address { get; set; }
}
