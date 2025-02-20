using MarcouEvento.Domain.Validation;

namespace MarcouEvento.Domain.Entities
{
    public class Party
    {
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

        public List<Expense> Expenses { get; set; }

        public Party(int id, string name, string description, DateTime dateStart, DateTime dateFinish, int addressId)
        {
            Id = id;
            Name = name;
            Description = description;
            DateStart = dateStart;
            DateFinish = dateFinish;
            AddressId = addressId;

            Validateinsert();
        }

        public Party(int id, List<Expense> expenses)
        {
            Id = id;
            Expenses = expenses;

            ValidateExpenses();
        }

        private void Validateinsert()
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(Name), "Name is required.");

            DomainExceptionValidation.When(DateStart == DateTime.MinValue, "DateStart is required.");

            DomainExceptionValidation.When(DateFinish == DateTime.MinValue, "DateFinish is required.");

            DomainExceptionValidation.When(AddressId == 0, "Addrress is required.");
        }

        private void ValidateExpenses()
        {
            DomainExceptionValidation.When(Expenses.Count == 0, "Expenses is required.");
        }
    }
}
