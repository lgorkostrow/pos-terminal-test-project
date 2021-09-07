using System;
using System.Linq;
using PosTerminal.Console.Models;

namespace PosTerminal.Console.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DenominationValidationAttribute : BaseValidationAttribute, IValidationAttribute
    {
        public DenominationValidationAttribute(string errorMessage) : base(errorMessage)
        {
        }

        public bool IsValid(object? value)
        {
            if (value is null)
            {
                return false;
            }
            
            var inputData = (InputData)value;

            return inputData.Denominations.All(x => inputData.DefinedDenominations.Contains(x));
        }
    }
}