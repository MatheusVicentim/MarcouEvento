﻿using MarcouEvento.Domain.Validation;
using System.ComponentModel;
using System.Reflection;

namespace MarcouEvento.Domain.Entities
{
    public class Address
    {
        public Address(int id, string street, int number, string neighborhood, string city, string state, string zipCode, string latitude, string longitude, string complement, string urlMaps)
        {
            Id = id;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            Latitude = latitude;
            Longitude = longitude;
            Complement = complement;

            Validate();
            UrlMaps = urlMaps;
        }

        public Address(string street, int number, string neighborhood, string city, string state, string zipCode, string complement, string urlMaps)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            Complement = complement;

            Validate();
            UrlMaps = urlMaps;
        }

        public Address( string city, string state, string zipCode, string latitude, string longitude, string complement, string urlMaps)
        {
            City = city;
            State = state;
            ZipCode = zipCode;
            Latitude = latitude;
            Longitude = longitude;
            Complement = complement;

            Validate();
            UrlMaps = urlMaps;
        }

        public enum EType
        {
            [Description("Residencial")]
            Residential = 1,

            [Description("Comercial")]
            Commercial = 2,

            [Description("Industrial")]
            Industrial = 3,

            [Description("Rural")]
            Rural = 4
        }

        public int Id { get; private set; }
        public string Street { get; private set; }
        public EType Type { get; private set; }
        public int Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
        public string? UrlMaps { get; private set; }
        public string Complement { get; private set; }

        private bool IsValidZipCode()
        {
            var zipCode = new string(ZipCode.Where(char.IsDigit).ToArray());

            if (zipCode.Length != 8)
                return false;

            // Verifica se todos os caracteres são números
            if (!zipCode.All(char.IsDigit))
                return false;

            // Verifica se não é uma sequência de números iguais
            if (zipCode.Distinct().Count() == 1)
                return false;

            return true;
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

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(City), "City is required.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(State), "State is required.");
            DomainExceptionValidation.When(State.Length != 2, "Ivalid State! State have two chacters");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(ZipCode), "ZipCode is required.");
            DomainExceptionValidation.When(!IsValidZipCode(), "Invalid ZipCode format. ZipCode must contain 8 digits in format XXXXX-XXX");
        }
                     

        public static string GetEnumDescription<TEnum>(TEnum value) where TEnum : Enum
        {
            FieldInfo? field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                DescriptionAttribute? attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            return value.ToString();
        }
    }
}