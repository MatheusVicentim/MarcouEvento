﻿using MarcouEvento.Domain.Validation;

namespace MarcouEvento.Domain.Entities
{
    public class Party
    {
        public Party(int id, string name, string description, DateTime dateStart, DateTime dateFinish, EStatus status, int addressId)
        {
            Id = id;
            Name = name;
            Description = description;
            DateStart = dateStart;
            DateFinish = dateFinish;
            Status = status;
            AddressId = addressId;

            ValidateInsert();
        }

        public Party(int id, IEnumerable<Expense> expenses)
        {
            Id = id;
            Expenses = expenses;

            ValidateExpenses();
        }
        public Party(string name, string description, DateTime dateStart, DateTime dateFinish, EStatus status, int addressId)
        {
            Name = name;
            Description = description;
            DateStart = dateStart;
            DateFinish = dateFinish;
            Status = status;
            AddressId = addressId;
        }

        public enum EStatus
        {
            Inactive,
            Active
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateFinish { get; private set; }
        public EStatus Status { get; set; }

        public int AddressId { get; private set; }
        public Address Address { get; private set; }

        public IEnumerable<Expense> Expenses { get; set; }

        private void ValidateInsert()
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(Name), "Name is required.");

            DomainExceptionValidation.When(DateStart == DateTime.MinValue, "DateStart is required.");

            DomainExceptionValidation.When(DateFinish == DateTime.MinValue, "DateFinish is required.");

            DomainExceptionValidation.When(AddressId == 0, "Addrress is required.");
        }

        private void ValidateExpenses()
        {
            DomainExceptionValidation.When(Expenses is null, "Expenses is required.");
        }
    }
}
