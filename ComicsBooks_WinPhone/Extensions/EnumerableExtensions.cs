using System;
using System.Collections.Generic;
using System.Linq;

namespace ComicsBooks_WinPhone.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this T obj)
        {
            yield return obj;
        }

        public static IList<T> Materialize<T>(this IEnumerable<T> enumerable)
        {
            return enumerable as IList<T> ?? enumerable.ToList();
        }

        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        public static void ForEach<TElement>(this IEnumerable<TElement> enumerable, Action<TElement> action)
        {
            foreach (var element in enumerable)
            {
                action(element);
            }
        }
    }
}