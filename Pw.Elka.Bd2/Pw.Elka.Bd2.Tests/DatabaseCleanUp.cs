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
        public static void Start(Entities dbContext)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.Gatunek.RemoveRange(dbContext.Gatunek);
                    dbContext.Autor.RemoveRange(dbContext.Autor);
                    dbContext.Rewers.RemoveRange(dbContext.Rewers);
                    dbContext.Rezerwacja.RemoveRange(dbContext.Rezerwacja);
                    dbContext.Klient.RemoveRange(dbContext.Klient);
                    dbContext.Klient_Poufne.RemoveRange(dbContext.Klient_Poufne);
                    dbContext.Pozycja.RemoveRange(dbContext.Pozycja);
                    dbContext.Typ.RemoveRange(dbContext.Typ);
                    dbContext.Seria.RemoveRange(dbContext.Seria);
                    dbContext.Dzial.RemoveRange(dbContext.Dzial);

                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
