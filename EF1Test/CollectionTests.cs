using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EFExtensions.EFWRappableFields.EF1Tests
{
	public class CollectionTests
	{

		private static IQueryable<Order> GetOrderSet()
		{
			var container = new EFTestDatabaseEntities();
			var collection = new WrappedFieldsObjectQuery<Order>(container.Orders);
			return collection;
		}


		[Fact]
		public void TestCollectionsAreSelectable()
		{
			var collection = GetOrderSet();
			Assert.DoesNotThrow(() => collection.Select(soh => soh.Details).First());
		}

		[Fact]
		public void TestCollectionsCanBeUsedInFiltering()
		{
			var collection = GetOrderSet();
			Assert.DoesNotThrow(() => collection.Where(soh => soh.Details.Any()).First());
		}

		[Fact]
		public void TestCollectionsCanBeUsedInFilteringWithContains()
		{
			var collection = GetOrderSet();
			var detail = collection.First().Details.First();
			Assert.DoesNotThrow(() => collection.Where(soh => soh.Details.Contains(detail)).First());
		}
	}
}
