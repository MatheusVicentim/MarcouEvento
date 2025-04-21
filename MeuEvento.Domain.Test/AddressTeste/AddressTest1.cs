using FluentAssertions;
using MarcouEvento.Domain.Entities;

namespace MeuEvento.Domain.Test.AddressTeste
{
    public class AddressTest1
    {
        [Fact(DisplayName = "Create Address Witch Valid State")]
        public void CreateAddress_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Address("R. Carlos Gomes", 574, "Centro", "São João das Duas Pontes", "SP", "15640047", "Casa", "", Address.EType.Residential);
            action.Should().NotThrow<MarcouEvento.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Address ZipCode Null")]
        public void CreateAddress_WitchParametersZipCodeNull_ResultObjectInvalid()
        {
            Action action = () => new Address("R. Carlos Gomes", 574, "Centro", "São João das Duas Pontes", "SP", null, "Casa", "", Address.EType.Residential);
            action.Should()
                    .Throw<MarcouEvento.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("ZipCode is required.");
        }

        [Fact(DisplayName = "Create Address ZipCode Invalid")]
        public void CreateAddress_WitchParametersZipCodeInvalid_ResultObjectInvalid()
        {
            Action action = () => new Address("R. Carlos Gomes", 574, "Centro", "São João das Duas Pontes", "SP", "156400047", "Casa", "", Address.EType.Residential);
            action.Should()
                    .Throw<MarcouEvento.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid ZipCode format. ZipCode must contain 8 digits in format XXXXX-XXX");
        }

        [Theory(DisplayName = "Create Address Latitude e Longitude")]
        [InlineData("R. Carlos Gomes", 574, "Centro", "São João das Duas Pontes", "SP", "15640047", "-23.123456", "-47.123456", "Casa", "", Address.EType.Residential)]
        public void CreateAddress_WitchParametersLatitudeAndLongitude_ResultObjectValid(string street, int number, string neighborhood, string city, string state, string zipCode, string latitude, string longitude, string complement, string urlMaps,  Address.EType type)
        {
            Action action = () => new Address(1, street, number, neighborhood, city, state, zipCode, latitude, longitude, complement, urlMaps, type);
            action.Should().NotThrow<MarcouEvento.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
