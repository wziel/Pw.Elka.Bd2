using Pw.Elka.Bd2.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pw.Elka.Bd2.Tests
{
    class Program
    {

        static bool isProduction;

        static void Main(string[] args)
        {
            if(args.Contains("cleanup"))
            {
                DatabaseCleanup.Start();
            }
            if(args.Contains("generate"))
            {
                uint _seriasCount;
                uint _autorsCount;
                uint _pozycjasCount;
                uint _klientsCount;
                if (args.Contains("production"))
                {
                    isProduction = true;
                    _seriasCount = 5000;
                    _autorsCount = 15000;
                    _pozycjasCount = 100000;
                    _klientsCount = 10000;
                }
                else
                {
                    _seriasCount = 50;
                    _autorsCount = 150;
                    _pozycjasCount = 1000;
                    _klientsCount = 100;
                }

                DataGenerator.Generate(_seriasCount, _autorsCount, _pozycjasCount, _klientsCount, isProduction);
                Simulator.Simulate();
            }
            if(args.Contains("tests"))
            {
                TimeTests.RunTests();
            }

            Console.WriteLine("Naciśnij dowolny klawisz aby zakończyć...");
            Console.Read();
        }
    }
}
