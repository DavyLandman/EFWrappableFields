using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFExtensions.EFWRappableFields.EFTests
{
	public partial class Product
	{
		public IEnumerable<Category> Categories
		{
			get
			{
				if (!DbCategories.IsLoaded)
					DbCategories.Load();
				return DbCategories;

			}
		}

	}
}
