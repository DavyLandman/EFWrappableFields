using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EFExtensions.EFWRappableFields.EFTests
{
	public class NestedWrappedFieldsTests
	{
		private static WrappedFieldsObjectQuery<OrderDetail> GetOrderSet()
		{
			var container = new EFTestDatabaseEntities();
			var collection = new WrappedFieldsObjectQuery<OrderDetail>(container.OrderDetails);
			return collection;
		}

		[Fact]
		public void TestCanUseNestedExpressions()
		{
			Assert.DoesNotThrow(() => GetOrderSet().Where(o => o.Product.Categories.Any()).First());
		}
	}
}
