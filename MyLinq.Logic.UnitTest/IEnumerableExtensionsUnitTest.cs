using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLinq.Logic.UnitTest
{
	[TestClass]
	public class IEnumerableExtensionsUnitTest
	{
		[TestMethod]
		public void ValidateEvenFilter_ListOfNumbersFromMinus10To10_ExpectedEvenNumbers()
		{
			var source = new[] { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var expected = new [] { -10, -8, -6, -4, -2, 0, 2, 4, 6, 8, 10 };
			var actual = source.Filter(x => x % 2 == 0);

			CollectionAssert.AreEqual(expected, actual.ToArray(), "Filter ist falsch!");
		}

		[TestMethod]
		public void CheckSum_From1To10_Result55()
		{
			double expected = 55.0;
			var source = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var actual = source.Sum(i => i);

			Assert.AreEqual(expected, actual, "Die Summer muss 55 betragen!");
		}

		[TestMethod]
		public void CheckSum_FromMinus10To10_Result0()
		{
			double expected = 0.0;
			var source = new int[] { -1, -2, -3, -4, -5, -6, -7, -8, -9, -10, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var actual = source.Sum(i => i);

			Assert.AreEqual(expected, actual, "Die Summer muss 0 betragen!");
		}
	}
}
