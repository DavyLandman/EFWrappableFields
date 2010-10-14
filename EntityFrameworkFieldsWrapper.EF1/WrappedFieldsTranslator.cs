using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace EFExtensions.EFWRappableFields
{
	public class WrappedFieldsTranslator 
	{
		public static Expression ForExpression(Expression query)
		{
			return new WrappedPropertiesRewriter().Modify(query);
		}
		public static Expression<T> ForExpression<T>(Expression<T> query)
		{
			return (Expression<T>)(new WrappedPropertiesRewriter().Modify(query));
		}


		class WrappedPropertiesRewriter : ExpressionVisitor
		{
			public Expression Modify(Expression expression)
			{
				return Visit(expression);
			}

			protected override Expression VisitMemberAccess(MemberExpression m)
			{
				var possiblyWrappedMember = WrappedFieldsMappingProvider.GetAvailableMapping(m.Member.DeclaringType, m.Member);
				if (possiblyWrappedMember != null)
				{
					m = Expression.MakeMemberAccess(m.Expression, possiblyWrappedMember);
				}
				return base.VisitMemberAccess(m);
			}
		}

	}
}
