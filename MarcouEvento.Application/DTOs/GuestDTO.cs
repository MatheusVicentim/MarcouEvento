using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcouEvento.Application.DTOs
{
    public class GuestDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome deve ser preenchido")]
        [MaxLength(300, ErrorMessage = "Nome da rua tem tamanho máximo de 300 caracteres")]
        [DisplayName("Nome")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Idade deve ser preenchida")]
        [Range(1, 99, ErrorMessage = "Idade deve estar entre 1 a 99 anos")]
        [DisplayName("Idade")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Sexo deve ser informado")]
        public int Sexo { get; set; }

        [Required(ErrorMessage = "Celular deve ser informado")]
        [MaxLength(15, ErrorMessage = "Celular tem tamanho máximo de 15 caracteres")]
        [DisplayName("Celular")]
        public int Phone { get; set; }

        public int PersonLevel { get; set; }

        public int Status { get; set; }

        public int AddressId { get; set; }
        public AddressDTO? Address { get; set; }
    }
}
