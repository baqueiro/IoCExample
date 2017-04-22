using Financial.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Implementations
{
    public class Market : IMarket
    {
        public List<string> MarketsGetList()
        {
            return new List<string> { "Nasdaq", "IPC" };
        }
    }
}
