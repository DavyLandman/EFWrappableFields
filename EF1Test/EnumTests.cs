using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace azM.EFWRappableFields.EF1Tests
{
	public class EnumTests
	{
		[Fact]
		public void TestThatEnumsCanBeSelected()
		{
			var container = new AdventureWorksLTEntities();
			var collection = new WrappedFieldsObjectQuery<SalesOrderHeader>(container.SalesOrderHeaders);
			Assert.DoesNotThrow(() => collection.Select(soh => soh.Status).ToList());
		}
	}
}
