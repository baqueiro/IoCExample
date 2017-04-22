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

        public IMarket Market { get; set; }

        public MarketEquityCalculator(IMarketEquity marketEquityInstance, IMarket marketInstance)
        {
            MarketEquity = marketEquityInstance;
            Market = marketInstance;
        }

        public string FirstEquityGetItem()
        {
            return MarketEquity.EquityGetList().FirstOrDefault();
        }

        public List<string> MarketsGetList()
        {
            return Market.MarketsGetList();
        }
    }
}
