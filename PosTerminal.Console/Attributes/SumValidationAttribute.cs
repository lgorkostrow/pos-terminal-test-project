using System;
using PosTerminal.Console.Models;

namespace PosTerminal.Console.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SumValidationAttribute : BaseValidationAttribute, IValidationAttribute
    {
        public SumValidationAttribute(string errorMessage) : base(errorMessage)
        {
        }

        public bool IsValid(object? value)
        {
            if (value is null)
            {
                return false;
            }
            
            var inputData = (InputData)value;

            return inputData.Price <= inputData.DenominationsSum;
        }
    }
}