using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Objects;
using System.Collections;

namespace EFExtensions.EFWRappableFields
{
	public class WrappedFieldsObjectQuery<T> : IOrderedQueryable<T>
	{
		private Expression expression = null;
		private ObjectQueryWrapperProvider<T> provider = null;

		public WrappedFieldsObjectQuery(IQueryable source)
		{
			expression = Expression.Constant(this);
			provider = new ObjectQueryWrapperProvider<T>(source);
		}

		public WrappedFieldsObjectQuery(IQueryable source, Expression e)
		{
			if (e == null) throw new ArgumentNullException("e");
			expression = e;
			provider = new ObjectQueryWrapperProvider<T>(source);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)provider.ExecuteEnumerable(this.expression)).GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return provider.ExecuteEnumerable(this.expression).GetEnumerator();
		}

		public WrappedFieldsObjectQuery<T> Include(String path)
		{
			ObjectQuery<T> possibleObjectQuery = provider.source as ObjectQuery<T>;
			if (possibleObjectQuery != null)
			{
				return new WrappedFieldsObjectQuery<T>(possibleObjectQuery.Include(path));
			}
			else
			{
				throw new InvalidOperationException("The Include should only happen at the beginning of a LINQ expression");
			}
		}

		public Type ElementType
		{
			get { return typeof(T); }
		}

		public Expression Expression
		{
			get { return expression; }
		}

		public IQueryProvider Provider
		{
			get { return provider; }
		}
	}


	class ObjectQueryWrapperProvider<T> : ExpressionVisitor, IQueryProvider
	{
		internal IQueryable source;

		public ObjectQueryWrapperProvider(IQueryable source)
		{
			if (source == null) throw new ArgumentNullException("source");
			this.source = source;
		}

		public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
		{
			if (expression == null) throw new ArgumentNullException("expression");

			return new WrappedFieldsObjectQuery<TElement>(source, expression) as IQueryable<TElement>;
		}

		public IQueryable CreateQuery(Expression expression)
		{
			if (expression == null) throw new ArgumentNullException("expression");
			Type elementType = expression.Type.GetGenericArguments().First();
			IQueryable result = (IQueryable)Activator.CreateInstance(typeof(WrappedFieldsObjectQuery<>).MakeGenericType(elementType),
				new object[] { source, expression });
			return result;
		}

		public TResult Execute<TResult>(Expression expression)
		{
			if (expression == null) throw new ArgumentNullException("expression");
			object result = (this as IQueryProvider).Execute(expression);
			return (TResult)result;
		}

		public object Execute(Expression expression)
		{
			if (expression == null) throw new ArgumentNullException("expression");

			Expression translated = WrappedFieldsTranslator.ForExpression(expression);
			translated = this.Visit(translated);
			return source.Provider.Execute(translated);
		}
		
		internal IEnumerable ExecuteEnumerable(Expression expression)
		{
			if (expression == null) throw new ArgumentNullException("expression");

			Expression translated = WrappedFieldsTranslator.ForExpression(expression);
			translated = this.Visit(translated);
			return source.Provider.CreateQuery(translated);
		}

		#region Visitors
		protected override Expression VisitConstant(ConstantExpression c)
		{
			// remove our wrapper from the Expression Tree.
			if (c.Type.IsGenericType && (c.Type.GetGenericTypeDefinition() == typeof(WrappedFieldsObjectQuery<>)))
			{
				return source.Expression;
			}
			else
			{
				return base.VisitConstant(c);
			}
		}
		#endregion
	}
}
