using System;

namespace MyLinq.Logic
{
	public static class ObjectExtensions
	{
		public static void CheckArgument(this object source, string argName)
		{
			if (source == null)
				throw new ArgumentNullException(argName);
		}
	}
}
