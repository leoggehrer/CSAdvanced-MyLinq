using System;
using System.Collections.Generic;

namespace MyLinq.Logic
{
	public static class IEnumerableExtensions
	{
		public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			source.CheckArgument(nameof(source));

			var result = new List<T>();

			foreach (var item in source)
			{
				if (predicate != null && predicate(item))
				{
					result.Add(item);
				}
			}
			return result;
		}
		public static IEnumerable<TResult> Map<T, TResult>(this IEnumerable<T> source, Func<T, TResult> mapping)
		{
			source.CheckArgument(nameof(source));

			var result = new List<TResult>();

			foreach (var item in source)
			{
				if (mapping != null)
				{
					result.Add(mapping(item));
				}
			}
			return result;
		}
		public static T[] ToArray<T>(this IEnumerable<T> source)
		{
			source.CheckArgument(nameof(source));

			return new List<T>(source).ToArray();
		}
		public static List<T> ToList<T>(this IEnumerable<T> source)
		{
			source.CheckArgument(nameof(source));

			return new List<T>(source);
		}

		public static int Count<T>(this IEnumerable<T> source)
		{
			var result = 0;

			if (source != null)
			{
				foreach (var item in source)
				{
					result++;
				}
			}
			return result;
		}

		public static double Sum<T>(this IEnumerable<T> source, Func<T, double> selector)
		{
			source.CheckArgument(nameof(source));
			selector.CheckArgument(nameof(selector));

			var result = 0.0;

			foreach (var item in source)
			{
				result += selector(item);
			}
			return result;
		}
		public static double? Min<T>(this IEnumerable<T> source, Func<T, double> selector)
		{
			source.CheckArgument(nameof(source));
			selector.CheckArgument(nameof(selector));

			double? result = null;

			foreach (var item in source)
			{
				if (result == null)
					result = selector(item);
				else if (selector(item) < result.Value)
					result = selector(item);
			}
			return result;
		}
		public static double? Max<T>(this IEnumerable<T> source, Func<T, double> selector)
		{
			source.CheckArgument(nameof(source));
			selector.CheckArgument(nameof(selector));

			double? result = null;

			foreach (var item in source)
			{
				if (result == null)
					result = selector(item);
				else if (selector(item) > result.Value)
					result = selector(item);
			}
			return result;
		}
		public static double? Average<T>(this IEnumerable<T> source, Func<T, double> selector)
		{
			source.CheckArgument(nameof(source));
			selector.CheckArgument(nameof(selector));

			double? result = null;
			int counter = 0;

			foreach (var item in source)
			{
				counter++;
				if (result == null)
					result = selector(item);
				else 
					result += selector(item);
			}
			return counter > 0 ? result / counter : result;
		}

		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			source.CheckArgument(nameof(source));
			action.CheckArgument(nameof(action));

			foreach (var item in source)
			{
				action(item);
			}
			return source;
		}
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<int, T> action)
		{
			source.CheckArgument(nameof(source));
			action.CheckArgument(nameof(action));

			var idx = 0;

			foreach (var item in source)
			{
				action(idx, item);
				idx++;
			}
			return source;
		}

		private class SortByComparer<T, TKey> : IComparer<T> where TKey : IComparable
		{
			private Func<T, TKey> OrderBy { get; }
			public SortByComparer(Func<T, TKey> orderBy)
			{
				OrderBy = orderBy;
			}
			public int Compare(T x, T y)
			{
				return OrderBy(x).CompareTo(OrderBy(y));
			}
		}
		public static IEnumerable<T> SortBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> orderBy) where TKey : IComparable
		{
			source.CheckArgument(nameof(source));
			orderBy.CheckArgument(nameof(orderBy));

			var result = source.ToArray();

			Array.Sort(result, new SortByComparer<T, TKey>(orderBy));
			return result;
		}
		public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source)
		{
			source.CheckArgument(nameof(source));

			var result = new List<T>();

			foreach (var item in source)
			{
				if (item != null && result.Contains(item) == false)
				{
					result.Add(item);
				}
			}
			return result;
		}
	}
}
