using FluentAssertions;
using MarcouEvento.Domain.Entities;

namespace MeuEvento.Domain.Test.AddressTeste
{
    public class AddressTest1
    {
        [Fact(DisplayName = "Create Address Witch Valid State")]
        public void CreateAddress_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Address("R. Carlos Gomes", 574, "Centro", "São João das Duas Pontes", "SP", "15640047", "Casa");
            action.Should().NotThrow<MarcouEvento.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Address ZipCode Null")]
        public void CreateAddress_WitchParametersZipCodeNull_ResultObjectInvalid()
        {
            Action action = () => new Address("R. Carlos Gomes", 574, "Centro", "São João das Duas Pontes", "SP", null, "Casa");
            action.Should()
                    .Throw<MarcouEvento.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("ZipCode is required.");
        }

        [Fact(DisplayName = "Create Address ZipCode Invalid")]
        public void CreateAddress_WitchParametersZipCodeInvalid_ResultObjectInvalid()
        {
            Action action = () => new Address("R. Carlos Gomes", 574, "Centro", "São João das Duas Pontes", "SP", "156400047", "Casa");
            action.Should()
                    .Throw<MarcouEvento.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid ZipCode format. ZipCode must contain 8 digits in format XXXXX-XXX");
        }
    }
}
