﻿namespace MarcouEvento.Domain.Entities;

public abstract class Person
{
    public enum ESexo
    {
        Masculino,
        Feminino,
        Outro
    }
    public enum EPersonLevel
    {
        Admin,
        Guest
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
    public EPersonLevel PersonLevel { get; private set; }
    public EStatus Status { get; set; }

    public int AddressId { get; private set; }
    public Address? Address { get; private set; }
}
