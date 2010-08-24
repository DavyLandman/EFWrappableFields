using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EFExtensions.EFWRappableFields.EFTests
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
			Assert.DoesNotThrow(() => collection.Where(soh => soh.Details.Any(d => d.Identifier == detail.Identifier)).First());
		}

		[Fact]
		public void TestCollectionContainsFilterWorks()
		{
			var collection = GetOrderSet();
			var detail = collection.First().Details.First();
			Assert.Contains(detail, collection.Where(soh => soh.Details.Any(d => d.Identifier == detail.Identifier)).First().Details);
		}
	}
}
