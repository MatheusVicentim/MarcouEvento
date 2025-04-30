using MarcouEvento.Application.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.VisualBasic;

namespace MarcouEvento.Application.ViewModels;

public class PartyViewModel
{
    public PartyViewModel(int id, string? name, string? description, DateTime dateStart, DateTime dateFinish, int addressId)
    {
        Id = id;
        Name = name;
        Description = description;
        _DateStart = dateStart;
        _DateFinish = dateFinish;
        AddressId = addressId;
    }

    public int Id { get; set; }

    [DisplayName("Nome")]
    public string? Name { get; set; }

    [DisplayName("Descrição")]
    public string? Description { get; set; }

    private DateTime _DateStart { get; set; }
    [DisplayName("Data de início")]
    public string DateStart => _DateStart.ToString("dd/MM/yyyy");
    private DateTime _DateFinish { get; set; }
    [DisplayName("Data de término")]
    public string DateFinish => _DateFinish.ToString("dd/MM/yyyy");

    public int AddressId { get; set; }
    //public AddressDTO? Address { get; set; }
}
