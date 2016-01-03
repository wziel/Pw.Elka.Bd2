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

        public static void Start()
        {
            using (var dbContext = new Entities())
            {
                Console.Write($"\rUsuwanie rewersów                     ");
                dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [dbo].[Rewers]");
                Console.Write($"\rUsuwanie rezerwacji                   ");
                dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [dbo].[Rezerwacja]");
                Console.Write($"\rUsuwanie poufnych danych klientów     ");
                dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [dbo].[Klient_Poufne]");
                Console.Write($"\rUsuwanie relacji Pozycja-Gatunek          ");
                dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [dbo].[Pozycja_gatunek]");
                Console.Write($"\rUsuwanie relacji Pozycja-Autor            ");
                dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [dbo].[Pozycja_autor]");
                Console.Write($"\rUsuwanie gatunkow                     ");
                dbContext.Gatunek.Clear(dbContext, 10000);
                Console.Write($"\rUsuwanie autorów                      ");
                dbContext.Autor.Clear(dbContext, 10000);
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
