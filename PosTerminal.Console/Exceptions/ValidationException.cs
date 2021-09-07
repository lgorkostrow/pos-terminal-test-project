using System;

namespace PosTerminal.Console.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string[] errors) : base(ErrorsToString(errors))
        {
        }

        private static string ErrorsToString(string[] errors)
        {
            return string.Join("\n", errors);
        }
    }
}