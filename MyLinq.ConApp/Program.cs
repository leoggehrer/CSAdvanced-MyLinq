using System;
using MyLinq.Logic;

namespace MyLinq.ConApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("My super Linq!");

			var cities = new string[] { "London", "Vienna", "Paris", "Linz", "Brussels", "Wilhering" };
			var query = cities.Filter(c => c.Contains("i"))
							  .Filter(c => c.Length > 5)
							  .SortBy(i => i);

			foreach (var item in query)
			{
				Console.WriteLine(item);
			}
			var count = query.Count();
			var sum = cities.Sum(c => c.Length);
			var intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			var intSum = intArray.Filter(i => i % 2 == 0)
								 .Sum(i => i);
			var countN = cities.Sum(c => c.ToLower().Contains('n') ? 1 : 0);
			var lowerSum = cities.Sum(c =>
			{
				var result = 0;

				foreach (var item in c)
				{
					if (Char.IsLower(item))
					{
						result++;
					}
				}
				return result;
			});

			cities.ForEach(i => Console.WriteLine(i));
		}
	}
}
