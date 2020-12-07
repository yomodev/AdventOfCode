using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020CS
{
    public static class Ex
    {
        public static IEnumerable<IEnumerable<T>> DifferentCombinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? EnumerableEx.Return(Enumerable.Empty<T>())
                : elements.SelectMany((e, i) => elements.Skip(i + 1)
                .DifferentCombinations(k - 1).Select(c => EnumerableEx.Return(e).Concat(c)));
        }


        //public static TResult Aggregate<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector);

        public static long Multiply<TSource, TParam>(this IEnumerable<TSource> source, Func<TSource, TParam, long> func, TParam param)
        {
            return source.Aggregate(1L, (acc, item) => acc * func(item, param));
        }

        public static long Multiply<TSource>(this IEnumerable<TSource> source, Func<TSource, long> func)
        {
            return source.Aggregate(1L, (acc, item) => acc * func(item));
        }

        public static long Multiply2<TSource, TParam>(this IEnumerable<TSource> source, Func<TSource, TParam, long> func, TParam param)
        {
            return source.Aggregate((mul: 1L, param), (prev, item) => (mul: prev.mul * func(item, prev.param), param), res => res.mul);
        }

    }
}
