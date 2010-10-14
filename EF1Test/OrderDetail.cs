using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFExtensions.EFWRappableFields.EFTests
{
	public partial class OrderDetail
	{
		public Product Product
		{
			get
			{
				if (!DbProductReference.IsLoaded)
				{
					DbProductReference.Load();
				}
				return DbProduct;
			}

		}
	}
}
