using System;
using System.Collections.Generic;

namespace ELearning.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationResult> validations)
           : base("One or more validation failures have occurred.")
        {
            Failures = validations;
        }

        public ValidationException()
        {
            Failures = new List<ValidationResult>();
        }

        public IEnumerable<ValidationResult> Failures { get; }
    }
}
