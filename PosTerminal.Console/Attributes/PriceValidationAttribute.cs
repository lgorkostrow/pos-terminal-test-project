using System;

namespace PosTerminal.Console.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PriceValidationAttribute : BaseValidationAttribute, IValidationAttribute
    {
        public PriceValidationAttribute(string errorMessage) : base(errorMessage)
        {
        }

        public bool IsValid(object? value)
        {
            if (value is null)
            {
                return false;
            }
            
            return (decimal)value > 0;
        }
    }
}