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

            string equitySimple = instance0.GetFirstEquity();

            Console.WriteLine(equitySimple);

            // Nasdaq
            MarketEquityCalculator instance1 = IoCNasdaq();

            string firstEquityNasdaq = instance1.GetFirstEquity();

            Console.WriteLine(firstEquityNasdaq);


            // IPC
            MarketEquityCalculator instance2 = IoCIPC();

            string firstEquityIPC = instance2.GetFirstEquity();

            Console.WriteLine(firstEquityIPC);

            Console.ReadKey();
        }

        private static MarketEquityCalculator IocSimple()
        {
            IMarketEquity market = new NasdaqMarket();

            MarketEquityCalculator instance = new MarketEquityCalculator(market);

            return instance;
        }

        private static MarketEquityCalculator IoCNasdaq()
        {
            var container = new IoCContainer();
            container.Register<IMarketEquity, NasdaqMarket>();
            MarketEquityCalculator instance = container.Resolve<MarketEquityCalculator>();
            return instance;
        }

        private static MarketEquityCalculator IoCIPC()
        {
            var container = new IoCContainer();
            container.Register<IMarketEquity, IPCMarket>();
            MarketEquityCalculator instance = container.Resolve<MarketEquityCalculator>();
            return instance;
        }
    }
}
