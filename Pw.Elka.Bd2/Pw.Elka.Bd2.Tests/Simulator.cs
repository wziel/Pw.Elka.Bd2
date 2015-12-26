using Pw.Elka.Bd2.Tests.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pw.Elka.Bd2.Tests
{
    public static class Simulator
    {
        private static int _minBooksPerDay;
        private static int _maxBooksPerDay;
        private static DateTime _currDate;
        private static decimal _karaValue = (decimal)0.20;

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

        public static void Simulate()
        {
            using (var ctx = new Entities())
            {
                var avrgBookPerDay = ctx.Klient.Count() / 30;
                _minBooksPerDay = (int)(avrgBookPerDay * 0.75);
                _maxBooksPerDay = (int)(avrgBookPerDay * 1.25);

                for (_currDate = DateTime.Today.AddDays(-720); _currDate < DateTime.Today; _currDate = _currDate.AddDays(1))
                {
                    Console.Write("\rSimulation, current date:{0}%               ", _currDate.ToString());
                    UpdateKaraColumn(ctx);
                    RemoveUnusedReservations(ctx);
                    SaveChanges(ctx);
                    ReceiveReservations(ctx);
                    SaveChanges(ctx);
                    HandleReturns(ctx);
                    SaveChanges(ctx);
                    HandleNewOrders(ctx);
                    SaveChanges(ctx);

                }
            }
        }

        private static void SaveChanges(Entities ctx)
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void ReceiveReservations(Entities ctx)
        {
            var reservationsWaitingCount = ctx.Rezerwacja.Where(r => r.gotowe_od.HasValue
                && r.Klient.liczba_wypozyczonych.HasValue && r.Klient.liczba_wypozyczonych < 3).Count();
            var toReceiveCount = reservationsWaitingCount == 1 ? 1 : reservationsWaitingCount / 2;
            var toReceive = Helpers.GetRandomCollectionFromWithExactCount(ctx.Rezerwacja.Where(r => r.gotowe_od.HasValue).Include(r => r.Klient), toReceiveCount);
            toReceive.ForEach(r =>
            {
                if(!r.Klient.liczba_wypozyczonych.HasValue)
                {
                    r.Klient.liczba_wypozyczonych = 0;
                }
                if (r.Klient.liczba_wypozyczonych < 3)
                {
                    CreateRewers(ctx, r.Klient, r.Pozycja);
                    ctx.Rezerwacja.Remove(r);
                }
            });
        }

        private static void RemoveUnusedReservations(Entities ctx)
        {
            var endReservationDate = _currDate.AddDays(-3);
            var toRemove = ctx.Rezerwacja.Where(r => r.gotowe_od.HasValue && r.gotowe_od.Value < endReservationDate).ToList();
            ctx.Rezerwacja.RemoveRange(toRemove);
        }

        private static void HandleNewOrders(Entities ctx)
        {
            var booksCount = Random.Next(_minBooksPerDay, _maxBooksPerDay);
            var klients = Helpers.GetRandomCollectionFromWithExactCount(ctx.Klient, booksCount);
            var klientIterator = 0;
            while (booksCount > 0)
            {
                var orderedCount = HandleNewOrders(ctx, klients[klientIterator]);
                if (orderedCount == 0)
                {
                    booksCount--;
                }
                else
                {
                    booksCount -= orderedCount;
                }
                klientIterator++;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="klient"></param>
        /// <returns>number of ordered books or 1 if none ordered</returns>
        private static int HandleNewOrders(Entities ctx, Klient klient)
        {
            var ordersCount = Math.Min((sbyte)Helpers.Random.Next(1, 4), (sbyte)(3 - klient.liczba_wypozyczonych));
            var pozycjas = Helpers.GetRandomCollectionFromWithExactCount(ctx.Pozycja, ordersCount);
            foreach (var pozycja in pozycjas)
            {
                HandleNewOrders(ctx, klient, pozycja);
            }
            return ordersCount;
        }

        private static void HandleNewOrders(Entities ctx, Klient klient, Pozycja pozycja)
        {
            if (pozycja.wypozyczona)
            {
                CreateReservation(ctx, klient, pozycja);
            }
            else
            {
                CreateRewers(ctx, klient, pozycja);
            }
        }

        private static void CreateReservation(Entities ctx, Klient klient, Pozycja pozycja)
        {
            ctx.Rezerwacja.Add(new Rezerwacja()
            {
                data_rezerwacji = _currDate,
                gotowe_od = null,
                Pozycja = pozycja,
                Klient = klient
            });
        }

        private static void CreateRewers(Entities ctx, Klient klient, Pozycja pozycja)
        {
            pozycja.wypozyczona = true;
            pozycja.dostepna_od = _currDate.AddDays(31);

            klient.liczba_wypozyczonych = (byte)(klient.liczba_wypozyczonych.HasValue ? klient.liczba_wypozyczonych + 1 : 1);

            ctx.Rewers.Add(new Rewers()
            {
                data_od = _currDate,
                data_do = pozycja.dostepna_od.Value.AddDays(-1),
                data_zwrotu = null,
                Pozycja = pozycja,
                Klient = klient
            });
        }

        private static void UpdateKaraColumn(Entities ctx)
        {
            ctx.Rewers.Where(r => r.data_do < _currDate).Select(r => r.Klient).ToList().ForEach(k =>
            {
                if (k == null) k.kara = _karaValue;
                else k.kara += _karaValue;
            });
        }

        private static void HandleReturns(Entities ctx)
        {
            var comingReservationDate = _currDate.AddDays(10);
            ctx.Rewers.Where(r => r.data_zwrotu == null && r.data_do < comingReservationDate).Include(r => r.Klient).Include(r => r.Pozycja).ToList().ForEach(r =>
            {
                if (Helpers.Random.Next(100) < 10)
                {
                    r.data_zwrotu = _currDate;
                    var rezerwacja = ctx.Rezerwacja.Where(rez => rez.Pozycja.id_pozycja == r.Pozycja.id_pozycja)
                        .OrderBy(rez => rez.data_rezerwacji).FirstOrDefault();

                    r.Klient.liczba_wypozyczonych--;
                    r.Pozycja.dostepna_od = null;

                    if (rezerwacja != null)
                    {
                        rezerwacja.gotowe_od = _currDate;
                    }
                    else
                    {
                        r.Pozycja.wypozyczona = false;
                    }
                }
            });
        }
    }
}
