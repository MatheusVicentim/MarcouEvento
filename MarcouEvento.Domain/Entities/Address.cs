using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcouEvento.Domain.Entities
{
    public class Address
    {
        public string Id { get; set; }
        public string Street { get; set; }

        public int Number { get; set; }

        public string Complement { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public Address(string id, string street, int number, string neighborhood, string city, string state, string zipCode, string complement = "")
        {
            Id = id;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            Complement = complement;

            Validate();
        }

        public Address(string street, int number, string neighborhood, string city, string state, string zipCode, string complement = "")
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            Complement = complement;

            Validate();
        }

        private void Validate()
        {
            //Isso serve para validar Datas Anotation
            //var validationContext = new ValidationContext(this);
            //var validationResults = new System.Collections.Generic.List<ValidationResult>();

            //bool isValid = Validator.TryValidateObject(this, validationContext, validationResults, true);

            //if (!isValid)
            //{
            //    throw new ValidationException(string.Join("; ", validationResults.ConvertAll(v => v.ErrorMessage)));
            //}
        }
    }

}
