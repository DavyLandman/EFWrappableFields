using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Reflection;
using System.Threading;

namespace EFExtensions.EFWRappableFields.EFTests
{
	public class TestConcurrency
	{
		private static MethodInfo methodToCall;
		static TestConcurrency()
		{

			var wrappingStorage = typeof(WrappedFieldsObjectQuery<>).Assembly.GetTypes().First(t => t.Name.EndsWith("WrappedFieldsMappingProvider"));
			methodToCall = wrappingStorage.GetMethod("GetAvailableMapping", BindingFlags.Static | BindingFlags.Public);
		}

		public static MemberInfo GetAvailableMapping(Type forType, MemberInfo wrappedProperty)
		{
			return (MemberInfo)(methodToCall.Invoke(null, new[] { forType, wrappedProperty }));
		}

		private const int amountOfThreads = 5;
		private Semaphore startWorking = new Semaphore(0, amountOfThreads);
		private Semaphore finishedWorking = new Semaphore(0, amountOfThreads);
		private Exception exceptionRaised;
		[Fact]
		public void TypesCheckingCausesConcurrencyException()
		{
			for (int i = 0; i < amountOfThreads; i++)
				new Thread(TryForceConcurrencyProblems).Start(this);
			startWorking.Release(amountOfThreads);
			for (int i = 0; i < amountOfThreads; i++)
				finishedWorking.WaitOne();
			Assert.Null(exceptionRaised);
		}

		public static void TryForceConcurrencyProblems(Object self)
		{

			((TestConcurrency)self).startWorking.WaitOne();
			try
			{
				GetAvailableMapping(typeof(Order), typeof(Order).GetProperty("Identifier", BindingFlags.Public | BindingFlags.Instance));
				GetAvailableMapping(typeof(Product), typeof(Product).GetProperty("Identifier", BindingFlags.Public | BindingFlags.Instance));
				GetAvailableMapping(typeof(Category), typeof(Category).GetProperty("Identifier", BindingFlags.Public | BindingFlags.Instance));
				GetAvailableMapping(typeof(OrderDetail), typeof(OrderDetail).GetProperty("Identifier", BindingFlags.Public | BindingFlags.Instance));
			}
			catch (Exception ex)
			{
				((TestConcurrency)self).exceptionRaised = ex;
			}
			((TestConcurrency)self).finishedWorking.Release();
		}
	}
}
