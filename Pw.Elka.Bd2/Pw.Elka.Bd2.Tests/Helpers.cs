using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pw.Elka.Bd2.Tests
{
    public static class Helpers
    {

        private static Random _random;
        public static Random Random
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

        public static long LongRandom(long min, long max)
        {
            byte[] buf = new byte[8];
            Random.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }


        public static T GetRandomElementFrom<T>(IReadOnlyList<T> list)
        {
            var index = Random.Next(list.Count);
            return list[index];
        }

        public static List<T> GetRandomCollectionFrom<T>(IReadOnlyList<T> list, int maxCount)
        {
            var returnList = new List<T>();
            for (int i = 0; i < maxCount; ++i)
            {
                returnList.Add(GetRandomElementFrom(list));
                if (Random.Next(100) > 33)
                {
                    break;
                }
            }
            return returnList;
        }

        public static T GetRandomElementFrom<T>(IQueryable<T> dbSet) where T : class
        {
            return dbSet.OrderBy(r => Guid.NewGuid()).First();
        }

        public static List<T> GetRandomCollectionFrom<T>(IQueryable<T> dbSet, int maxCount) where T : class
        {
            var count = Random.Next(maxCount) + 1;
            return dbSet.OrderBy(r => Guid.NewGuid()).Take(count).ToList();
        }

        public static List<T> GetRandomCollectionFromWithExactCount<T>(IQueryable<T> dbSet, int exactCount) where T : class
        {
            return dbSet.OrderBy(r => Guid.NewGuid()).Take(exactCount).ToList();
        }
    }
}
