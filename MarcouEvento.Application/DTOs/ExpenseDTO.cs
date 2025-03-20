using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcouEvento.Application.DTOs;

public class ExpenseDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Nome deve ser preenchido")]
    [MaxLength(100, ErrorMessage = "Nome do evento tem tamanho máximo de 100 caracteres")]
    [Display(Name = "Nome")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Descrição deve ser preenchido")]
    [MaxLength(1000, ErrorMessage = "Descrição do evento tem tamanho máximo de 1000 caracteres")]
    [Display(Name = "Descrição")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Tipo deve ser preenchido")]
    [Display(Name = "Tipo")]
    public int Type { get; set; }

    [Required(ErrorMessage = "Valor deve ser preenchido")]
    [Range(0, 999.99, ErrorMessage = "Valor deve estar entre 0 a 999,99")]
    public decimal Value { get; set; }

    public int PartyID { get; set; }
    public PartyDTO Party { get; set; }
}
