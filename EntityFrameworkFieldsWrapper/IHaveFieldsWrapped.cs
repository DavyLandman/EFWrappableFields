using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace azM.EFWRappableFields
{
	public interface IHaveFieldsWrapped
	{
		Dictionary<MemberInfo, MemberInfo> GetMappings();
	}
}
