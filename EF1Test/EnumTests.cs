using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EFExtensions.EFWRappableFields.EF1Tests
{
	public class EnumTests
	{
		private static WrappedFieldsObjectQuery<Order> GetOrderSet()
		{
			var container = new EFTestDatabaseEntities();
			var collection = new WrappedFieldsObjectQuery<Order>(container.Orders);
			return collection;
		}

		[Fact]
		public void TestThatEnumsCanBeSelected()
		{
			var collection = GetOrderSet();
			Assert.DoesNotThrow(() => collection.Select(soh => soh.Status).First());
		}

		[Fact]
		public void TestThatEnumsCanBeFilteredOn()
		{
			var collection = GetOrderSet();
			Assert.DoesNotThrow(() => collection.Where(soh => soh.Status == OrderState.Approved).First());
		}
	}
}
