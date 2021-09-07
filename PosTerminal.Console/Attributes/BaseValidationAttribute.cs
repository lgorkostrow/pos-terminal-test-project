using System;

namespace PosTerminal.Console.Attributes
{
    public abstract class BaseValidationAttribute : Attribute
    {
        public string ErrorMessage { get; }

        protected BaseValidationAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}