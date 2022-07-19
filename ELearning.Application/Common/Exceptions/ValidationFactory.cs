using FluentValidation;
using System;
using System.Collections.Generic;

namespace ELearning.Application.Common.Exceptions
{
    public class ValidationFactory
    {
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        static ValidationFactory()
        {
            AssemblyScanner findValidatorsInAssembly = AssemblyScanner.FindValidatorsInAssembly(typeof(ApplicationModule).Assembly);
            foreach (AssemblyScanner.AssemblyScanResult item in findValidatorsInAssembly)
            {
                validators.Add(item.InterfaceType.GenericTypeArguments[0], (IValidator < item.InterfaceType.GenericTypeArguments[0] >) item.ValidatorType as IValidator);
            }

        }

        public IValidator GetValidator(Type request)
        {
            IValidator validator;
            if (validators.TryGetValue(request, out validator))
            {
                return validator;
            }
            return validator;
        }
    }
}
