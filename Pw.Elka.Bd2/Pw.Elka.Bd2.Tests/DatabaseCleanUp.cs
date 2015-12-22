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
                gatunek.Pozycja.Clear();
            }
            foreach (var autor in ctx.Autor)
            {
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
                dbContext.Gatunek.Clear(dbContext, 10000);
                dbContext.Autor.Clear(dbContext, 10000);
                dbContext.Rewers.Clear(dbContext, 10000);
                dbContext.Rezerwacja.Clear(dbContext, 10000);
                dbContext.Klient_Poufne.Clear(dbContext, 10000);
                dbContext.Klient.Clear(dbContext, 10000);
                dbContext.Pozycja.Clear(dbContext, 10000);
                dbContext.Typ.Clear(dbContext, 10000);
                dbContext.Seria.Clear(dbContext, 10000);
                dbContext.Dzial.Clear(dbContext, 10000);
            }
        }
    }
}
