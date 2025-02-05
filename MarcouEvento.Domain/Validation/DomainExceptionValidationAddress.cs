﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcouEvento.Domain.Validation
{
    public class DomainExceptionValidationAddress: Exception
    {
        public DomainExceptionValidationAddress(string error):base(error) { }

        public static void When(bool hasError, string error)
        {
            if (hasError) 
                throw new DomainExceptionValidationAddress(error);
        }
    }
}
