using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021Lib
{
    public static class Utils
	{
		public static IEnumerable<int> Range(int start, int end, int step = 1)
		{
			for (int i = start; i < end; i += step) yield return i;
		}

		public static IEnumerable<int> RangeEnd(int end, int step = 1)
		{
			for (int i = 0; i < end; i += step) yield return i;
		}

		public static IList<T> Fill<T>(this IList<T> list, int numberOfElements)
		{
			foreach (var _ in RangeEnd(numberOfElements)) { list.Add(default); }
			return list; // I chose this so that methods could be chained to it. 
		}

		public static IEnumerable<int> Range(Range range)
		{
			var start = Math.Min(range.Start.Value, range.End.Value);
			var end = Math.Max(range.Start.Value, range.End.Value);
			return Range(start, end);
		}

		public static IEnumerable<int> RangeInclusive(Range range)
		{
			var start = Math.Min(range.Start.Value, range.End.Value);
			var end = Math.Max(range.Start.Value, range.End.Value);
			return Range(start, end + 1);
		}

		public static IEnumerable<T> Buffer<T>(this IEnumerable<T> source, int size, int overlap = 0)
		{
			if (size < 2) throw new ArgumentOutOfRangeException(nameof(size));
			if (overlap < 0) throw new ArgumentOutOfRangeException(nameof(overlap));
			if (source == null) throw new NullReferenceException(nameof(source));

			List<T> list = new(); 
			//list.Take
			return list;
		}
	}
}
