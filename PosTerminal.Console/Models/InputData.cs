using System.Linq;
using PosTerminal.Console.Attributes;

namespace PosTerminal.Console.Models
{
    [SumValidation("The Sum of Denominations must be greater than or equals to the price")]
    [DenominationValidation("Incorrect denomination list")]
    public class InputData
    {
        public decimal[] DefinedDenominations { get; }
        
        [PriceValidation("The price must be greater than 0")]
        public decimal Price { get; }
        
        public decimal[] Denominations { get; }

        public decimal DenominationsSum => Denominations.Sum();
        public decimal Change => DenominationsSum - Price;
        
        public InputData(decimal[] definedDenominations, decimal price, decimal[] denominations)
        {
            DefinedDenominations = definedDenominations;
            Price = price;
            Denominations = denominations;
        }
    }
}