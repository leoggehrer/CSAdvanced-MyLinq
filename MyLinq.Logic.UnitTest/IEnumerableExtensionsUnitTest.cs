using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLinq.Logic;

namespace MyLinq.Logic.UnitTest
{
	[TestClass]
	public class IEnumerableExtensionsUnitTest
	{
		[TestMethod]
		public void CreateArray_SumFrom1To10_Result55()
		{
			double expected = 55.0;
			var source = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var actual = source.Sum(i => i);

			Assert.AreEqual(expected, actual, "Die Summer muss 55 betragen!");
		}
	}
}
