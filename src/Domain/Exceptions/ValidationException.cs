using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; private set; }
        public ValidationException() : base("One or more validation failures have occurred!.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            var failuresGroups = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            foreach ( var failureGroup  in failuresGroups)
            {
                var propertyName = failureGroup.Key;
                var propertyFailures = failureGroup.ToArray();

                Errors.Add(propertyName, propertyFailures);
            }
        }


    }
}
