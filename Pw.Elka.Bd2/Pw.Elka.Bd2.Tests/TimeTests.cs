using Pw.Elka.Bd2.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pw.Elka.Bd2.Tests
{
    public static class TimeTests
    {

        private static HashSet<TestGenerator> _testGenerators = new HashSet<TestGenerator>()
        {
            new JakiAutorNajczesciejTestGenerator(),
            new JakieOsobyPrzetrzymywalyNajwiecejTestGenerator(),
            new JakiePozycjeNajczesciejWypozyczaneTestGenerator(),
            new JakieRezerwacjeGotoweDoOdebraniaTestGenerator(),
            new KiedyDostepnaTestGenerator(),
            new IleSztukPoISSNTestGenerator(),
            new IleWypozyczonychTestGenerator(),
        };

        public static void RunTests()
        {
            using (var ctx = new Entities())
            {
                var testIterationsCount = 100;
                foreach (var testGenerator in _testGenerators)
                {
                    var timeSpanIndexAggregate = new TimeSpan();
                    var timeSpanNoIndexAggregate = new TimeSpan();
                    Console.WriteLine();
                    Console.WriteLine();
                    for (int i = 1; i <= 100; ++i)
                    {
                        Console.Write($"\rWykonywanie testu: {testGenerator.TestTitle}, test {i}/{testIterationsCount}.");
                        var test = testGenerator.GenerateRandomTest(ctx);
                        timeSpanIndexAggregate += test.GetExecutionWithIndexesTime();
                        timeSpanNoIndexAggregate += test.GetExecutionWithNoIndexesTime();
                    }
                    Console.Write($"\nWykonanie testów z indeksami zajęło średnio : {timeSpanIndexAggregate.TotalSeconds / testIterationsCount} sekund.");
                    Console.Write($"\nWykonanie testów bez indeksów zajęło średnio: {timeSpanNoIndexAggregate.TotalSeconds / testIterationsCount} sekund.");
                }

            }
        }

        private class Test
        {
            private Action ProcedureWithIndexes { get; set; }
            private Action ProcedureWithNoIndexes { get; set; }

            public Test(Action procedureWithIndexes, Action procedureWithNoIndexes)
            {
                ProcedureWithIndexes = procedureWithIndexes;
                ProcedureWithNoIndexes = procedureWithNoIndexes;
            }

            public TimeSpan GetExecutionWithIndexesTime()
            {
                return GetExecutionTime(ProcedureWithIndexes);
            }

            public TimeSpan GetExecutionWithNoIndexesTime()
            {
                return GetExecutionTime(ProcedureWithNoIndexes);
            }

            private static TimeSpan GetExecutionTime(Action action)
            {
                var startTime = DateTime.Now;
                action();
                var endTime = DateTime.Now;
                return endTime - startTime;
            }
        }

        private abstract class TestGenerator
        {
            public abstract Test GenerateRandomTest(Entities ctx);
            public virtual string TestTitle { get; }
        }

        private class JakiAutorNajczesciejTestGenerator : TestGenerator
        {
            public override string TestTitle { get; } = "Jaki autor najczęściej";

            public override Test GenerateRandomTest(Entities ctx)
            {
                var dtRange = Helpers.DateTimeRange.GetRandomDateTimeRange();
                return new Test(
                () => ctx.JakiAutorNajczesciej(dtRange.StartDate, dtRange.EndDate),
                () => ctx.JakiAutorNajczesciejBezIndexow(dtRange.StartDate, dtRange.EndDate));
            }
        }

        private class JakieOsobyPrzetrzymywalyNajwiecejTestGenerator : TestGenerator
        {
            public override string TestTitle { get; } = "Jakie osoby przetrzymywały najwięcej";
            public override Test GenerateRandomTest(Entities ctx)
            {
                var dtRange = Helpers.DateTimeRange.GetRandomDateTimeRange();
                return new Test(
                () => ctx.JakieOsobyPrzetrzymywalyNajwiecej(dtRange.StartDate, dtRange.EndDate),
                () => ctx.JakieOsobyPrzetrzymywalyNajwiecejBezIndexow(dtRange.StartDate, dtRange.EndDate));
            }
        }

        private class JakiePozycjeNajczesciejWypozyczaneTestGenerator : TestGenerator
        {
            public override string TestTitle { get; } = "Jakie pozycje najczęściej wypożyczane";
            public override Test GenerateRandomTest(Entities ctx)
            {
                var dtRange = Helpers.DateTimeRange.GetRandomDateTimeRange();
                return new Test(
                () => ctx.JakiePozycjeNajczesciejWypozyczane(dtRange.StartDate, dtRange.EndDate),
                () => ctx.JakiePozycjeNajczesciejWypozyczaneBezIndexow(dtRange.StartDate, dtRange.EndDate));
            }
        }

        private class JakieRezerwacjeGotoweDoOdebraniaTestGenerator : TestGenerator
        {
            public override string TestTitle { get; } = "Jakie rezerwacje gotowe do odebrania";
            public override Test GenerateRandomTest(Entities ctx)
            {
                return new Test(
                () => ctx.JakieRezerwacjeGotoweDoOdebrania(),
                () => ctx.JakieRezerwacjeGotoweDoOdebraniaBezIndexow());
            }
        }

        private class KiedyDostepnaTestGenerator : TestGenerator
        {
            public override string TestTitle { get; } = "Kiedy dostępna";
            public override Test GenerateRandomTest(Entities ctx)
            {
                var randomPozycjaId = Helpers.GetRandomElementFrom(ctx.Pozycja).id_pozycja;
                return new Test(
                () => ctx.KiedyDostepna(randomPozycjaId),
                () => ctx.KiedyDostepnaBezIndexow(randomPozycjaId));
            }
        }

        private class IleSztukPoISSNTestGenerator : TestGenerator
        {
            public override string TestTitle { get; } = "Ile sztuk po ISSN";
            public override Test GenerateRandomTest(Entities ctx)
            {
                var randomISSN = Helpers.GetRandomElementFrom(ctx.Seria).issn;
                return new Test(
                () => ctx.IleSztukPoISSN(randomISSN),
                () => ctx.IleSztukPoISSNBezIndexow(randomISSN));
            }
        }

        private class IleWypozyczonychTestGenerator : TestGenerator
        {
            public override string TestTitle { get; } = "Ile wypożyczonych";
            public override Test GenerateRandomTest(Entities ctx)
            {
                var randomDzialId = Helpers.GetRandomElementFrom(ctx.Dzial).id_dzial;
                return new Test(
                () => ctx.IleWypozyczonych(randomDzialId),
                () => ctx.IleWypozyczonychBezIndexow(randomDzialId));
            }
        }
    }


}
