using Pw.Elka.Bd2.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pw.Elka.Bd2.Tests
{
    public static class DatabaseCleanup
    {
        private static void Clear<T>(this System.Data.Entity.DbSet<T> dbSet, Entities dbContext, int batchCount) where T : class
        {
            while (dbSet.Count() > 0)
            {
                dbSet.RemoveRange(dbSet.Take(batchCount));
                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private static void ClearManyToManyRelations(Entities ctx)
        {
            foreach (var gatunek in ctx.Gatunek)
            {
                Console.Write($"\rUsuwanie relacji Pozycja-Gatunek          ");
                gatunek.Pozycja.Clear();
            }
            foreach (var autor in ctx.Autor)
            {
                Console.Write($"\rUsuwanie relacji Pozycja-Autor            ");
                autor.Pozycja.Clear();
            }

            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Start()
        {
            using (var dbContext = new Entities())
            {
                ClearManyToManyRelations(dbContext);
                Console.Write($"\rUsuwanie gatunkow                     ");
                dbContext.Gatunek.Clear(dbContext, 10000);
                Console.Write($"\rUsuwanie autorów                      ");
                dbContext.Autor.Clear(dbContext, 10000);
                Console.Write($"\rUsuwanie rewersów                     ");
                dbContext.Rewers.Clear(dbContext, 10000);
                Console.Write($"\rUsuwanie rezerwacji                   ");
                dbContext.Rezerwacja.Clear(dbContext, 10000);
                Console.Write($"\rUsuwanie poufnych danych klientów     ");
                dbContext.Klient_Poufne.Clear(dbContext, 10000);
                Console.Write($"\rUsuwanie klientów                     ");
                dbContext.Klient.Clear(dbContext, 10000);
                Console.Write($"\rUsuwanie pozycji                      ");
                dbContext.Pozycja.Clear(dbContext, 10000);
                Console.Write($"\rUsuwanie typów                        ");
                dbContext.Typ.Clear(dbContext, 10000);
                Console.Write($"\rUsuwanie serii                        ");
                dbContext.Seria.Clear(dbContext, 10000);
                Console.Write($"\rUsuwanie działów                      ");
                dbContext.Dzial.Clear(dbContext, 10000);
            }
        }
    }
}
