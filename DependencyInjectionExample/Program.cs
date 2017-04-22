using Financial;
using Financial.Implementations;
using Financial.Interfaces;
using IoCLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simple IoC
            MarketEquityCalculator instance0 = IocSimple();

            var equitySimple = instance0.FirstEquityGetItem();
            var markets0 = instance0.MarketsGetList();

            Console.WriteLine(equitySimple);
            Console.WriteLine(markets0[0]);

            // Nasdaq
            MarketEquityCalculator instance1 = IoCNasdaq();

            var firstEquityNasdaq = instance1.FirstEquityGetItem();
            var markets1 = instance1.MarketsGetList();

            Console.WriteLine(firstEquityNasdaq);
            Console.WriteLine(markets1[0]);


            // IPC
            MarketEquityCalculator instance2 = IoCIPC();

            string firstEquityIPC = instance2.FirstEquityGetItem();
            var markets2 = instance2.MarketsGetList();

            Console.WriteLine(firstEquityIPC);
            Console.WriteLine(markets2[0]);

            Console.ReadKey();
        }

        private static MarketEquityCalculator IocSimple()
        {
            IMarketEquity marketEquity = new NasdaqMarket();
            IMarket market = new Market();

            MarketEquityCalculator instance = new MarketEquityCalculator(marketEquity, market);

            return instance;
        }

        private static MarketEquityCalculator IoCNasdaq()
        {
            var container = new IoCContainer();
            container.Register<IMarketEquity, NasdaqMarket>();
            container.Register<IMarket, Market>();
            MarketEquityCalculator instance = container.Resolve<MarketEquityCalculator>();
            return instance;
        }

        private static MarketEquityCalculator IoCIPC()
        {
            var container = new IoCContainer();
            container.Register<IMarketEquity, IPCMarket>();
            container.Register<IMarket, Market>();
            MarketEquityCalculator instance = container.Resolve<MarketEquityCalculator>();
            return instance;
        }
    }
}
