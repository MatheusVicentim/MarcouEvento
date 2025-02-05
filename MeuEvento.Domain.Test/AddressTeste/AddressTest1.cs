using FluentAssertions;
using MarcouEvento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuEvento.Domain.Test.AddressTeste
{
    public class AddressTest1
    {
        [Fact(DisplayName ="Create Address Witch Valid State")]
        public void CreateAdrress_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Address("R. Carlos Gomes", 574, "Centro","São João das Duas Pontes", "SP", "15640047", "Casa");
            action.Should().NotThrow<MarcouEvento.Domain.Validation.DomainExceptionValidationAddress>();
        }
    }
}
