using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace EFExtensions.EFWRappableFields.EF1Tests
{
	public enum OrderState
	{
		Unknown = 0,
		InProcess = 1,
		Approved = 2,
		Backordered = 3,
		Rejected = 4,
		Shipped = 5,
		Cancelled = 6
	}

	public partial class Order
	{
		public OrderState Status
		{
			get { return (OrderState)DbState; }
			set { DbState = (int)value; }
		}
		public IEnumerable<OrderDetail> Details
		{
			get 
			{
				// Lazy loading in EF1
				if (!DbDetails.IsLoaded && (EntityState != System.Data.EntityState.Detached && EntityState != System.Data.EntityState.Added))
					DbDetails.Load();
				return DbDetails; 
			}
		}
	}
}
