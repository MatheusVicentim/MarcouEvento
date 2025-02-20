using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcouEvento.Domain.Entities
{
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

        public int Id { get; private set; }
        public string? FullName { get; private set; }
        public int Age { get; private set; }
        public ESexo Sexo { get; private set; }
        public int Phone { get; private set; }
        public EPersonLevel PersonLevel { get; private set; }

        public int AddressId { get; private set; }
        public Address? Address { get; private set; }
    }
}
