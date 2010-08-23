using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

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

	public partial class SalesOrderHeader :IHaveFieldsWrapped
	{
		public OrderState Status
		{
			get { return (OrderState)DbStatus; }
			set { DbStatus = (byte)value; }
		}

		public Dictionary<MemberInfo, MemberInfo> GetMappings()
		{
			return new Dictionary<MemberInfo, MemberInfo> { { ExtractMemberInfo.From<SalesOrderHeader>(s => s.Status), ExtractMemberInfo.From<SalesOrderHeader>(s => s.DbStatus) } };
		}
	}
}
