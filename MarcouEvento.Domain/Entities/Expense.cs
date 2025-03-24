using MarcouEvento.Domain.Validation;

namespace MarcouEvento.Domain.Entities;

public class Expense
{
    public enum EType
    {
        Individual,
        Group
    }

    public int Id { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public EType Type { get; private set; }
    public decimal Value { get; private set; }

    public int PartyId { get; private set; }
    public Party Party { get; private set; }

    public Expense() { }

    public Expense(string? name, string? description, EType type, decimal value, int partyId)
    {
        Name = name;
        Description = description;
        Type = type;
        Value = value;
        PartyId = partyId;

        DomainExceptionValidation.When(String.IsNullOrEmpty(Name), "Name is required!");
    }

    public Expense(int id, string? name, string? description, EType type, decimal value)
    {
        Id = id;
        Name = name;
        Description = description;
        Type = type;
        Value = value;

        DomainExceptionValidation.When(Id == 0, "Id is required!");

        Validation();
    }

    public void Validation()
    {
        DomainExceptionValidation.When(String.IsNullOrEmpty(Name), "Name is required!");
        DomainExceptionValidation.When(Value == 0, "Value is required!");
        DomainExceptionValidation.When(PartyId == 0, "Party is required!");

    }
}
