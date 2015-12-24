using Pw.Elka.Bd2.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Pw.Elka.Bd2.Tests
{
    public static class DataCreator
    {
        private static List<string> _firstPersonNames = new List<string>() { "Joanna", "Michał", "Kacper", "Wojciech", "Judyta", "Ksawery", "Łukasz", "Joachim", "Barbara", "Klemens", "Bogusław", "Helena" };
        private static List<string> _lastPersonrNames = new List<string>() { "Raczyńska", "Kacperski", "Mudel", "Zieliński", "Kowalski", "Nowak", "Kamiński", "Michalak" };

        private static List<string> _firstBookWord = new List<string> { "Tańczące", "Kolorowe", "Drewniane", "Niezwyciężone", "Złośliwe", "Banalne", "Zagadkowe", "Okrągłe", "Tajemnicze", "Ogromne", "Piękne" };
        private static List<string> _secondBookaWord = new List<string> { "karły", "kobiety", "nieuanse", "powieści", "kałamarnice", "wnęki", "karabiny", "obrazy", "komputery", "zagadki", "wykłady" };
        private static List<string> _thirdBookWord = new List<string> { "ciemności", "Ameryki", "Polski", "hotelu", "Ryszarda Petru", "rynku", "szkoły", "z obozu", "na wykładzie", "podczas sylwestra", "w telewizji" };

        private static List<string> _firstEmailParts = new List<string> { "Joanna", "Michał", "Kamil", "Zygmunt", "Janusz", "Barbara", "Marian" };
        private static List<string> _secondEmailPart = new List<string> { "wp.pl", "gmail.com", "outlook.com" };

        private static List<string> _streetName = new List<string>() { "Bakaliowa", "Wojska Polskiego", "Jana Pawła II", "Aleje Jerozolimskie", "Stefana Bryły", "Odyńca" };

        public static Autor CreateRandomAutor()
        {
            return new Autor()
            {
                imiona = string.Join(" ", Helpers.GetRandomCollectionFrom(_firstPersonNames, 3).ToArray()),
                nazwiska = string.Join(" ", Helpers.GetRandomCollectionFrom(_lastPersonrNames, 3).ToArray())

            };
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

        public static Seria CreateRandomSeria()
        {
            return new Seria()
            {
                issn = Helpers.Random.Next(10000000, 99999999),
                nazwa = Helpers.GetRandomElementFrom(_firstBookWord) + " "
                + Helpers.GetRandomElementFrom(_secondBookaWord) + " "
                + Helpers.GetRandomElementFrom(_thirdBookWord)
            };
        }

        public static List<Typ> GetTypCollection()
        {
            return new List<Typ>()
            {
                new Typ() { nazwa = "Czasopismo" },
                new Typ() { nazwa = "Książka" },
                new Typ() { nazwa = "Publikacja"}
            };
        }

        private static byte[] GetRandomZdjecie(int bytesLength)
        {
            var bytes = new byte[bytesLength];
            Helpers.Random.NextBytes(bytes);
            return bytes;
        }
        public static Pozycja CreateRandomPozycja(DbSet<Dzial> dzials, DbSet<Seria> serias, DbSet<Typ> typs,
            DbSet<Autor> autors, DbSet<Gatunek> gatuneks, bool longPhoto)
        {
            return new Pozycja()
            {
                isbn = Helpers.LongRandom(1000000000000, 9999999999999),
                nazwa = Helpers.GetRandomElementFrom(_firstBookWord) + " "
                + Helpers.GetRandomElementFrom(_secondBookaWord) + " "
                + Helpers.GetRandomElementFrom(_thirdBookWord),
                rok = (short)Helpers.Random.Next(1800, 2015),
                zdjecie = GetRandomZdjecie(longPhoto ? 2000 : 1),
                dostepna_od = null,
                wypozyczona = false,
                Dzial = Helpers.GetRandomElementFrom(dzials),
                Seria = Helpers.Random.Next(100) < 30 ? null : Helpers.GetRandomElementFrom(serias),
                Typ = Helpers.GetRandomElementFrom(typs),
                Gatunek = Helpers.GetRandomCollectionFrom(gatuneks, 5),
                Autor = Helpers.GetRandomCollectionFrom(autors, 5)
            };
        }

        public static Klient CreateRandomKlient(Klient_Poufne poufne)
        {
            return new Klient()
            {
                imiona = string.Join(" ", Helpers.GetRandomCollectionFrom(_firstPersonNames, 3).ToArray()),
                nazwiska = string.Join(" ", Helpers.GetRandomCollectionFrom(_lastPersonrNames, 3).ToArray()),
                email = Helpers.GetRandomElementFrom(_firstEmailParts) + "@" + Helpers.GetRandomElementFrom(_secondEmailPart),
                telefon = Helpers.Random.Next(100000000, 999999999).ToString(),
                kara = 0,
                liczba_wypozyczonych = 0,
                Klient_Poufne = poufne
            };
        }

        public static Klient_Poufne CreateRandomKlientPoufne()
        {
            return new Klient_Poufne()
            {
                pesel = Helpers.LongRandom(10000000000, 99999999999),
                adres = Helpers.GetRandomElementFrom(_streetName) + " " + (Helpers.Random.Next(200) + 1) + "/" + (Helpers.Random.Next(200) + 1)
            };
        }
    }
}
