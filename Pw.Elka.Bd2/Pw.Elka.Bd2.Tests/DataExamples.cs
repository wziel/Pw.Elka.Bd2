using Pw.Elka.Bd2.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pw.Elka.Bd2.Tests
{
    public static class DataExamples
    {

        private static List<string> _firstPersonNames = new List<string>() { "Joanna", "Michał", "Kacper", "Wojciech", "Judyta", "Ksawery", "Łukasz" };
        private static List<string> _lastPersonrNames = new List<string>() { "Raczyńska", "Kacperski", "Mudel", "Zieliński", "Kowalski", "Nowak" };

        private static List<string> _firstBookWord = new List<string> { "Tańczące", "Kolorowe", "Drewniane", "Niezwyciężone", "Złośliwe", "Banalne" };
        private static List<string> _secondBookaWord = new List<string> { "karły", "kobiety", "nieuanse", "powieści", "kałamarnice", "wnęki", "karabiny" };
        private static List<string> _thirdBookWord = new List<string> { "ciemności", "Ameryki", "Polski", "hotelu", "Ryszarda Petru", "rynku", "szkoły" };

        private static List<string> _firstEmailParts = new List<string> { "Joanna", "Michał", "Kamil", "Zygmunt", "Janusz" };
        private static List<string> _secondEmailPart = new List<string> { "wp.pl", "gmail.com", "outlook.com" };

        private static List<string> _streetName = new List<string>() { "Bakaliowa", "Wojska Polskiego", "Jana Pawła II", "Aleje Jerozolimskie", "Stefana Bryły", "Odyńca" };

        private static Random _random;
        private static Random Random
        {
            get
            {
                if (_random == null)
                {
                    _random = new Random();
                }
                return _random;
            }
        }

        private static T GetRandomElementFrom<T>(IReadOnlyList<T> list)
        {
            var index = Random.Next(list.Count);
            return list[index];
        }

        private static List<T> GetRandomCollectionFromWithMaxCount<T>(IReadOnlyList<T> list, int maxCount)
        {
            var count = Random.Next(maxCount - 1) + 1;
            var returnList = new List<T>();
            for (int i = 0; i < count; ++i)
            {
                returnList.Add(GetRandomElementFrom(list));
            }
            return returnList;
        }

        private static List<T> GetRandomCollectionFromWithExactCount<T>(IReadOnlyList<T> list, int exactCount)
        {
            var returnList = new List<T>();
            for (int i = 0; i < exactCount; ++i)
            {
                returnList.Add(GetRandomElementFrom(list));
            }
            return returnList;
        }

        private static long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

        private static Autor CreateRandomAutor()
        {
            return new Autor()
            {
                imiona = string.Join(" ", GetRandomCollectionFromWithMaxCount(_firstPersonNames, 3).ToArray()),
                nazwiska = string.Join(" ", GetRandomCollectionFromWithMaxCount(_secondBookaWord, 3).ToArray())

            };
        }
        public static List<Autor> GetAutorCollection(int count)
        {
            var list = new List<Autor>();
            while (count-- > 0)
            {
                list.Add(CreateRandomAutor());
            }
            return list;
        }

        public static List<Gatunek> GetGatunekCollection()
        {
            return new List<Gatunek>()
            {
                new Gatunek() { nazwa = "Kryminał" },
                new Gatunek() { nazwa = "Komedia" },
                new Gatunek() { nazwa = "Thriller" },
                new Gatunek() { nazwa = "Horror" },
                new Gatunek() { nazwa = "Poradnik" },
                new Gatunek() { nazwa = "Instrukcja obsługi" },
                new Gatunek() { nazwa = "Fantastyka" },
                new Gatunek() { nazwa = "Science-Fiction" },
            };
        }

        public static List<Dzial> GetDzialCollection()
        {
            return new List<Dzial>()
            {
                new Dzial() { nazwa = "Beletrystyka" },
                new Dzial() { nazwa = "Historyczne" },
                new Dzial() { nazwa = "Dla dzieci" },
                new Dzial() { nazwa = "Dla dorosłych" },
                new Dzial() { nazwa = "Poradniki" },
                new Dzial() { nazwa = "Opowiadania" },
                new Dzial() { nazwa = "Biografie" }
            };
        }

        private static Seria CreateRandomSeria()
        {
            return new Seria()
            {
                issn = Random.Next(10000000, 99999999),
                nazwa = GetRandomElementFrom(_firstBookWord) + " "
                + GetRandomElementFrom(_secondBookaWord) + " "
                + GetRandomElementFrom(_thirdBookWord)
            };
        }
        public static List<Seria> GetSeriaCollection(int count)
        {
            var list = new List<Seria>();
            while (count-- > 0)
            {
                list.Add(CreateRandomSeria());
            }
            return list;
        }

        public static List<Typ> GetTypCollection(int count)
        {
            return new List<Typ>()
            {
                new Typ() { nazwa = "Czasopismo" },
                new Typ() { nazwa = "Książka" },
                new Typ() { nazwa = "Publikacja"}
            };
        }

        private static byte[] GetRandomZdjecie()
        {
            var bytes = new byte[50000];
            Random.NextBytes(bytes);
            return bytes;
        }
        private static Pozycja CreateRandomPozycja(IReadOnlyList<Dzial> dzials, IReadOnlyList<Seria> serias, IReadOnlyList<Typ> typs)
        {
            return new Pozycja()
            {
                isbn = LongRandom(1000000000000, 9999999999999, Random),
                nazwa = GetRandomElementFrom(_firstBookWord) + " "
                + GetRandomElementFrom(_secondBookaWord) + " "
                + GetRandomElementFrom(_thirdBookWord),
                rok = (short)Random.Next(1800, 2015),
                zdjecie = GetRandomZdjecie(),
                dostepna_od = null,
                wypozyczona = false,
                Dzial = GetRandomElementFrom(dzials),
                Seria = Random.Next(100) < 80 ? null : GetRandomElementFrom(serias),
                Typ = GetRandomElementFrom(typs)
            };
        }

        public static List<Pozycja> GetPozycjaCollection(IReadOnlyList<Dzial> dzials, IReadOnlyList<Seria> serias, IReadOnlyList<Typ> typs, int count)
        {
            var list = new List<Pozycja>();
            while (count-- > 0)
            {
                list.Add(CreateRandomPozycja(dzials, serias, typs));
            }
            return list;
        }

        private static Klient CreateRandomKlient()
        {
            return new Klient()
            {
                imiona = string.Join(" ", GetRandomCollectionFromWithMaxCount(_firstPersonNames, 3).ToArray()),
                nazwiska = string.Join(" ", GetRandomCollectionFromWithMaxCount(_secondBookaWord, 3).ToArray()),
                email = GetRandomElementFrom(_firstEmailParts) + "@" + GetRandomElementFrom(_secondEmailPart),
                telefon = Random.Next(100000000, 999999999).ToString(),
                kara = null,
                Klient_Poufne = null
            };
        }
        public static List<Klient> GetKlientCollection(int count)
        {
            var list = new List<Klient>();
            while (count-- > 0)
            {
                list.Add(CreateRandomKlient());
            }
            return list;
        }

        private static Klient_Poufne CreateRandomKlientPoufne()
        {
            return new Klient_Poufne()
            {
                pesel = LongRandom(10000000000, 99999999999, Random),
                adres = GetRandomElementFrom(_streetName) + (Random.Next(200) + 1) + "/" + (Random.Next(200) + 1)
            };
        }
        public static List<Klient_Poufne> GetKlientPoufneCollection(int count)
        {
            var list = new List<Klient_Poufne>();
            while (count-- > 0)
            {
                list.Add(CreateRandomKlientPoufne());
            }
            return list;
        }

        private static int GetKlientNumberOfRewersesDuring(DateTime startDate, DateTime endDate, Klient klient)
        {
            return klient.Rewers.Where(r => (r.data_od >= startDate && r.data_od <= endDate) ||
                (r.data_do >= startDate && r.data_do <= endDate) ||
                (r.data_od <= startDate && r.data_do >= endDate)).Count();
        }
        private static DateTime RandomDay(DateTime start)
        {
            int range = (DateTime.Today - start).Days;
            return start.AddDays(Random.Next(range));
        }
        public static List<Rewers> GetRewersCollection(IReadOnlyList<Klient> klients, IReadOnlyList<Pozycja> pozycjas)
        {
            var list = new List<Rewers>();
            foreach (var pozycja in pozycjas)
            {
                var startDate = DateTime.Today.AddYears(-2);
                while (startDate < DateTime.Today)
                {
                    var rewers = new Rewers();
                    rewers.Pozycja = pozycja;
                    rewers.data_od = RandomDay(startDate);
                    rewers.data_do = rewers.data_od.AddDays(30);
                    if (rewers.data_od.AddDays(40) > DateTime.Today && Random.Next(100) < 90)
                    {
                        break;
                    }
                    rewers.Klient = GetRandomElementFrom(klients);
                    if (GetKlientNumberOfRewersesDuring(rewers.data_od, rewers.data_do, rewers.Klient) >= 3)
                    {
                        break;
                    }
                    var data_zwrotu = rewers.data_do.AddDays(Random.Next(10) - 5);
                    if (data_zwrotu >= DateTime.Today)
                    {
                        rewers.data_zwrotu = null;
                        pozycja.wypozyczona = true;
                        pozycja.dostepna_od = rewers.data_do;
                    }
                    else
                    {
                        rewers.data_zwrotu = data_zwrotu;
                        pozycja.wypozyczona = false;
                    }

                    data_zwrotu = rewers.data_zwrotu ?? DateTime.Today;
                    if (data_zwrotu > rewers.data_do)
                    {
                        var karaValue = Convert.ToDecimal(0.20 * (data_zwrotu - rewers.data_do).Days);
                        if (rewers.Klient.kara == null)
                        {
                            rewers.Klient.kara = karaValue;
                        }
                        else
                        {
                            rewers.Klient.kara += karaValue;
                        }
                    }

                    list.Add(rewers);
                    startDate = rewers.data_zwrotu.Value.AddDays(1);
                }
            }
            return list;
        }

        public static List<Rezerwacja> GetRezerwacjaCollection(IReadOnlyList<Klient> klients, IReadOnlyList<Pozycja> pozycjas)
        {
            var wypozyczone = pozycjas.Where(p => p.dostepna_od.HasValue).ToList();
            wypozyczone = GetRandomCollectionFromWithExactCount(
                wypozyczone,
                wypozyczone.Count / 2);
            foreach (var pozycja in wypozyczone)
            {
                var chosenKlients = GetRandomCollectionFromWithMaxCount(klients, 3);
                foreach (var klient in chosenKlients)
                {
                    var data_rezerwacji = RandomDay(pozycja.dostepna_od.Value.AddDays(-25));
                    if (GetKlientNumberOfRewersesDuring(data_rezerwacji, DateTime.Today.AddDays(1), klient) >= 3)
                    {
                        break;
                    }
                    var rezerwacja = new Rezerwacja()
                    {
                        data_rezerwacji = data_rezerwacji,
                        gotowe_od = pozycja.wypozyczona ? null : pozycja.dostepna_od;
                    }
                }
            }
        }
    }
}
