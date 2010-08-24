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

		[Fact(Skip = "EF1 Cannot handle the selects on a enum, casting it in the Expression causes EF to fail due to the enum not being a scalar type.")]
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
