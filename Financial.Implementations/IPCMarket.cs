using Financial.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Implementations
{
    public class IPCMarket : IMarketEquity
    {
        public List<string> EquityGetList()
        {
            return new List<string> { "AAPL.MX", "AMZN.MX" };
        }
    }
}
