namespace MarcouEvento.Domain.Entities;

public class Administrator 
{
    public enum ESexo
    {
        Masculino,
        Feminino,
        Outro
    }
    public enum EStatus
    {
        Cancelado,
        Ativo,
        Pendente
    }

    public int Id { get; private set; }
    public string? FullName { get; private set; }
    public int Age { get; private set; }
    public ESexo Sexo { get; private set; }
    public int Phone { get; private set; }
    public EStatus Status { get; set; }

    public int AddressId { get; private set; }
    public Address? Address { get; private set; }
}
