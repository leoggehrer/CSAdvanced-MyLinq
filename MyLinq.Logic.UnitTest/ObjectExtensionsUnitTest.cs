using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyLinq.Logic.UnitTest
{
	[TestClass]
	public class ObjectExtensionsUnitTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CheckArgument_NullReference_ExpectedArgumentNullException()
		{
			string name = null;

			name.CheckArgument(nameof(name));
		}

		[TestMethod]
		public void CheckArgument_StringReference_ExpectedNoneArgumentNullException()
		{
			string name = "Max";

			name.CheckArgument(nameof(name));
		}

		[TestMethod]
		public void CheckArgument_NullArgumentWithTestName_ExpectedArgumentNullExceptionWithTestName()
		{
			object testName = null;
			string expected = $"Value cannot be null. (Parameter '{nameof(testName)}')";

			try
			{
				testName.CheckArgument(nameof(testName));
			}
			catch (ArgumentNullException anex)
			{
				Assert.AreEqual(expected, anex.Message);
			}
		}

		[TestMethod]
		public void CheckArgument_NullArgumentWithLastName_ExpectedArgumentNullExceptionWithLastName()
		{
			object lastName = null;
			string expected = $"Value cannot be null. (Parameter '{nameof(lastName)}')";

			try
			{
				lastName.CheckArgument(nameof(lastName));
			}
			catch (ArgumentNullException anex)
			{
				Assert.AreEqual(expected, anex.Message);
			}
		}
	}
}
