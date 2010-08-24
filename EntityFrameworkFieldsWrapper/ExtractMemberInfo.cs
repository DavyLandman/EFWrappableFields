using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace EFExtensions.EFWRappableFields
{
	public static class ExtractMemberInfo
	{
		public static MemberInfo From<T>(Expression<Func<T, Object>> exp)
		{
			return GetMemberInfo.From(exp);
		}
		class GetMemberInfo : ExpressionVisitor
		{
			private MemberInfo result = null;

			public static MemberInfo From(Expression from)
			{
				var result = new GetMemberInfo();
				result.Visit(from);
				return result.result;
			}
			protected override Expression VisitMemberAccess(MemberExpression m)
			{
				result = m.Member;
				return m;
			}
		}
	}

}
