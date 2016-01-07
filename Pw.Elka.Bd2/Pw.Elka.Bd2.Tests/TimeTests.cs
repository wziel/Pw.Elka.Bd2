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
        public static void RunTests()
        {
            using (var ctx = new Entities())
            {
                foreach(var test in GetTests(ctx))
                {
                    Console.WriteLine($"Wykonywanie testu: {test.TestTitle}");
                    Console.WriteLine($"Wykonanie z indeksami zajęło : {test.GetExecutionWithIndexesTime()}");
                    Console.WriteLine($"Wykonanie bez indeksów zajęło: {test.GetExecutionWithNoIndexesTime()}");
                }

            }
        }

        private static HashSet<Test> GetTests(Entities ctx)
        {
            var random = new Random();

            var dateTimeStart = new DateTime(2015, 1, 1);
            var dateTimeEnd = new DateTime(2015, 12, 1);

            var randomPozycjaIdToSkip = random.Next(ctx.Pozycja.Count());
            var randomPozycjaId = ctx.Pozycja.OrderBy(p => p.id_pozycja).Skip(randomPozycjaIdToSkip).Select(p => p.id_pozycja).First();

            var randomISSNToSkip = random.Next(ctx.Seria.Count());
            var randomISSN = ctx.Seria.OrderBy(p => p.id_seria).Skip(randomISSNToSkip).Select(s => s.issn).First();

            var randomDzialToSkip = random.Next(ctx.Dzial.Count());
            var randomDzialId = ctx.Dzial.OrderBy(d => d.id_dzial).Skip(randomDzialToSkip).Select(d => d.id_dzial).First();

            return new HashSet<Test>()
            {
                new Test("Jaki autor najczęściej", 
                () => ctx.JakiAutorNajczesciej(dateTimeStart, dateTimeEnd),
                () => ctx.JakiAutorNajczesciejBezIndexow(dateTimeStart, dateTimeEnd)),
                new Test("Jakie osoby przetrzymywały najwięcej",
                () => ctx.JakieOsobyPrzetrzymywalyNajwiecej(dateTimeStart, dateTimeEnd),
                () => ctx.JakieOsobyPrzetrzymywalyNajwiecejBezIndexow(dateTimeStart, dateTimeEnd)),
                new Test("Jakie pozycje najczęściej wypożyczane",
                () => ctx.JakiePozycjeNajczesciejWypozyczane(dateTimeStart, dateTimeEnd),
                () => ctx.JakiePozycjeNajczesciejWypozyczaneBezIndexow(dateTimeStart, dateTimeEnd)),
                new Test("Jakie rezerwacje gotowe do odebrania",
                () => ctx.JakieRezerwacjeGotoweDoOdebrania(),
                () => ctx.JakieRezerwacjeGotoweDoOdebraniaBezIndexow()),
                new Test("Kiedy dostępna",
                () => ctx.KiedyDostepna(randomPozycjaId),
                () => ctx.KiedyDostepnaBezIndexow(randomPozycjaId)),
                new Test("Ile sztuk po ISSN",
                () => ctx.IleSztukPoISSN(randomISSN),
                () => ctx.IleSztukPoISSNBezIndexow(randomISSN)),
                new Test("Ile wypożyczonych",
                () => ctx.IleWypozyczonych(randomDzialId),
                () => ctx.IleWypozyczonychBezIndexow(randomDzialId)),
            };
        }

        private class Test
        {
            private Action ProcedureWithIndexes { get; set; }
            private Action ProcedureWithNoIndexes { get; set; }
            public string TestTitle { get; private set; }

            public Test(string testTitle, Action procedureWithIndexes, Action procedureWithNoIndexes)
            {
                TestTitle = testTitle;
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
    }


}
