namespace MarcouEvento.Domain.Entities
{
    public class Party
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateFinish { get; private set; }

        public int AddressId { get; private set; }
        public Address Address { get; private set; }

        public Party(int id, string name, string description, DateTime dateStart, DateTime dateFinish, int addressId, Address address)
        {
            Id = id;
            Name = name;
            Description = description;
            DateStart = dateStart;
            DateFinish = dateFinish;
            AddressId = addressId;
            Address = address;

            Validate();
        }

        public Party(string name, string description, DateTime dateStart, DateTime dateFinish, int addressId, Address address)
        {
            Name = name;
            Description = description;
            DateStart = dateStart;
            DateFinish = dateFinish;
            AddressId = addressId;
            Address = address;

            Validate();
        }

        private void Validate()
        {
        }
    }
}
