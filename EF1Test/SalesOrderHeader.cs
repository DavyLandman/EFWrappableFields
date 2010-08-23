using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace azM.EFWRappableFields.EF1Tests
{
	public enum OrderState
	{
		Unknown = 0,
		Initial = 1,
		WaitingForPayment = 2,
		PaymentRecieved = 3,
		Packaging = 4,
		Shipping = 5,
		Recieved = 6
	}

	public partial class SalesOrderHeader
	{
		public OrderState Status
		{
			get { return (OrderState)DbStatus; }
			set { DbStatus = (byte)value; }
		}
	}
}
