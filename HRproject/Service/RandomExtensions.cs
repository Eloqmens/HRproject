using HR.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRproject.Service
{
    static class RandomExtensions
    {
        public static T NextItem<T>(this Random rnd, params T[] items) => items[rnd.Next(items.Length)];

        public static T NextId<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            
            var rnd = new Random();
            var list = enumerable as IList<T> ?? enumerable.ToList();
            return list.Count == 0 ? default(T) : list[rnd.Next(0, list.Count)];
        }

        public static DateTime RandomDay(this Random rnd)
        {
            var start = new DateTime(1995, 1, 1);
            var range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }

        public static string RandomAddress(this Random rnd) => $"{rnd.Next(1, 255)}.{rnd.Next(0, 255)}.{rnd.Next(0, 255)}.{rnd.Next(0, 255)}";

        public static string GetRandomNumber(this Random rnd) => $"+7978{rnd.Next(100000, 999999)}";

        public static int PassportNumber(this Random rnd) => rnd.Next(100000000, 999999999);
    }
}
