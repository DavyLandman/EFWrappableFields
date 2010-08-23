using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace azM.EFWRappableFields.EF1Tests
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
	}
}
