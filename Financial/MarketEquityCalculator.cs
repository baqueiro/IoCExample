using Financial.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial
{
    public class MarketEquityCalculator
    {
        public IMarketEquity MarketEquity { get; set; }
        
        public MarketEquityCalculator(IMarketEquity instance)
        {
            MarketEquity = instance;
        }

        public string GetFirstEquity()
        {
            return MarketEquity.EquityGetList().FirstOrDefault();
        }
    }
}
