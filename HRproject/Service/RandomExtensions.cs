using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRproject.Service
{
    static class RandomExtensions
    {
        public static T NextItem<T>(this Random rnd, params T[] items) => items[rnd.Next(items.Length)];

        public static DateTime RandomDay(this Random rnd)
        {
            var start = new DateTime(1995, 1, 1);
            var range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }

        //public static DateTime RandomDay(this Random rnd, DateTime start, int range)
        //{
        //    start = new DateTime(1995, 1, 1);
        //    range = (DateTime.Today - start).Days;
        //    return start.AddDays(rnd.Next(range));
        //}

        private static Random random = new Random();
        //public static DateTime GetRandomDay()
        //{
        //    DateTime start = new DateTime(1995, 1, 1);
        //    int range = (DateTime.Today - start).Days;
        //    return start.AddDays(random.Next(range));
        //}

        public static string RandomAddress(this Random rnd) => $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";
        //public static string GetRandomIpAddress()
        //{
        //    return $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";
        //}

        public static string GetRandomNumber(this Random rnd) => $"+7978{random.Next(100000, 999999)}";
        //public static string GetRandomPhone()
        //{
        //    return $"+7978{random.Next(100000, 999999)}";
        //}

        public static int PassportNumber(this Random rnd) => rnd.Next(100000000, 999999999);
    }
}
