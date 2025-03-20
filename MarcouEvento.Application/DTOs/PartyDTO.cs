using MarcouEvento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcouEvento.Application.DTOs;

public class PartyDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome deve ser preenchido")]
    [MaxLength(100, ErrorMessage = "Nome tem tamanho máximo de 100 caracteres")]
    [DisplayName("Nome")]
    private string? Name { get; set; }

    [MaxLength(1000, ErrorMessage ="Descrição tem tamanho máximo de 1000 caracteres")]
    [DisplayName("Descrição")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Data de início deve ser preenchida")]
    [DisplayName("Data de início")]
    public DateTime DateStart { get; set; }

    [Required(ErrorMessage = "Data de término deve ser preenchida")]
    [DisplayName("Data de término")]
    public DateTime DateFinish { get; set; }

    public int AddressId { get; set; }
    public AddressDTO? Address { get; set; }

    public IEnumerable<ExpenseDTO>? Expenses { get; set; }
}
