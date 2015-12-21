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

        static void Main(string[] args)
        {
            uint _seriasCount = 5000;
            uint _autorsCount = 15000;
            uint _pozycjasCount = 100000;
            uint _pozycjasBatchCount = 5000;
            uint _klientsCount = 10000;

            using (var ctx = new Entities())
            {
                DatabaseCleanup.Start(ctx);
                GenerateDzials(ctx);
                GenerateGatuneks(ctx);
                GenerateTyps(ctx);
                GenerateSerias(ctx, _seriasCount);
                GenerateAutors(ctx, _autorsCount);
                GenerateKlients(ctx, _klientsCount);

                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            for (uint i = 0; i < _pozycjasCount; i += _pozycjasBatchCount)
            {
                using (var ctx = new Entities())
                {
                    GeneratePozycjas(ctx, _pozycjasBatchCount);
                    try
                    {
                        ctx.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }

        static void GenerateDzials(Entities ctx)
        {
            var dzials = DataCreator.GetDzialCollection();
            ctx.Dzial.AddRange(dzials);
        }

        static void GenerateGatuneks(Entities ctx)
        {
            var gatuneks = DataCreator.GetGatunekCollection();
            ctx.Gatunek.AddRange(gatuneks);
        }

        static void GenerateTyps(Entities ctx)
        {
            var typs = DataCreator.GetTypCollection();
            ctx.Typ.AddRange(typs);
        }

        static void GenerateSerias(Entities ctx, uint count)
        {
            var serias = new List<Seria>();
            for (int i = 0; i < count; ++i)
            {
                serias.Add(DataCreator.CreateRandomSeria());
            }
            ctx.Seria.AddRange(serias);
        }

        static void GenerateAutors(Entities ctx, uint count)
        {
            var autors = new List<Autor>();
            for (int i = 0; i < count; ++i)
            {
                autors.Add(DataCreator.CreateRandomAutor());
            }
            ctx.Autor.AddRange(autors);
        }

        static void GeneratePozycjas(Entities ctx, uint count)
        {
            var dzials = ctx.Dzial.ToList();
            var serias = ctx.Seria.ToList();
            var typs = ctx.Typ.ToList();
            var pozycjas = new List<Pozycja>();
            for (int i = 0; i < count; ++i)
            {
                pozycjas.Add(DataCreator.CreateRandomPozycja(dzials, serias, typs));
            }
            ctx.Pozycja.AddRange(pozycjas);
        }

        static void GenerateKlients(Entities ctx, uint count)
        {
            var klient_poufnes = new List<Klient_Poufne>();
            var klient = new List<Klient>();
            for (int i = 0; i < count; ++i)
            {
                klient_poufnes.Add(DataCreator.CreateRandomKlientPoufne());
                klient.Add(DataCreator.CreateRandomKlient(klient_poufnes[i]));
            }
            ctx.Klient.AddRange(klient);
        }
    }
}
