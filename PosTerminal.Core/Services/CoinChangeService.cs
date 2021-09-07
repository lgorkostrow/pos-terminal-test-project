using System.Collections.Generic;
using System.Linq;
using PosTerminal.Core.Exceptions;

namespace PosTerminal.Core.Services
{
    public interface ICoinChangeService
    {
        IList<decimal> Calculate(decimal[] denominations, decimal change);
    }
    
    public class CoinChangeService : ICoinChangeService
    {
        public IList<decimal> Calculate(decimal[] denominations, decimal change)
        {
            if (denominations.Length == 0)
            {
                throw new NoAvailableDenominationsFoundException();
            }
            
            var result = new List<decimal>();
            if (change == 0)
            {
                return result;
            }

            denominations = denominations.Distinct().OrderByDescending(x => x).ToArray();
            var index = 0;
            var denomination = denominations[index];
            while (change != 0)
            {
                if (denomination > change)
                {
                    denomination = denominations[++index];
                    
                    continue;
                }
                
                if (denomination == change)
                {
                    result.Add(denomination);

                    break;
                }
                
                result.Add(denomination);
                change -= denomination;
            }

            return result;
        }
    }
}