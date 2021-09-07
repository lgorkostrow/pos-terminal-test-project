using System;

namespace PosTerminal.Core.Exceptions
{
    public class NoAvailableDenominationsFoundException : Exception
    {
        public NoAvailableDenominationsFoundException() : base("No available denominations found")
        {
        }
    }
}