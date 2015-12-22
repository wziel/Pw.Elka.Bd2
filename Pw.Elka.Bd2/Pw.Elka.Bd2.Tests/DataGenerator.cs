using Pw.Elka.Bd2.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pw.Elka.Bd2.Tests
{
    public static class DataGenerator
    {
        private static bool _isProduction;
        public static void Generate(uint seriasCount, uint autorsCount, uint pozycjasCount, uint klientsCount, bool isProduction)
        {
            _isProduction = isProduction;

            using (var ctx = new Entities())
            {
                GenerateDzials(ctx);
                GenerateGatuneks(ctx);
                GenerateTyps(ctx);
                GenerateSerias(ctx, seriasCount);
                GenerateAutors(ctx, autorsCount);
                GenerateKlients(ctx, klientsCount);

                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            uint pozycjasBatchCount = 1000;
            for (uint i = 0; i < pozycjasCount; i += pozycjasBatchCount)
            {
                using (var ctx = new Entities())
                {
                    GeneratePozycjas(ctx, pozycjasBatchCount);
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
            var pozycjas = new List<Pozycja>();
            for (int i = 0; i < count; ++i)
            {
                pozycjas.Add(DataCreator.CreateRandomPozycja(ctx.Dzial, ctx.Seria, ctx.Typ, ctx.Autor, ctx.Gatunek, _isProduction));
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
