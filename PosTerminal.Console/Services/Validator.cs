using System;
using System.Collections.Generic;
using PosTerminal.Console.Attributes;
using PosTerminal.Console.Exceptions;

namespace PosTerminal.Console.Services
{
    public interface IValidator
    {
        public void Validate<T>(T model);
    }
    
    public class Validator : IValidator
    {
        public void Validate<T>(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var errorList = new List<string>();
            var modelType = model.GetType();

            foreach (var attribute in modelType.GetCustomAttributes(true))
            {
                if (attribute is not IValidationAttribute validationAttribute) continue;
                
                if (!validationAttribute.IsValid(model))
                {
                    errorList.Add(validationAttribute.ErrorMessage);
                }
            }
            
            foreach (var propertyInfo in modelType.GetProperties())
            {                
                foreach (var attribute in propertyInfo.GetCustomAttributes(true))
                {
                    if (attribute is IValidationAttribute validationAttribute)
                    {
                        if (!validationAttribute.IsValid(propertyInfo.GetValue(model)))
                        {
                            errorList.Add(validationAttribute.ErrorMessage);
                        }
                    }
                }
            }

            if (errorList.Count > 0)
            {
                throw new ValidationException(errorList.ToArray());
            }
        }
    }
}