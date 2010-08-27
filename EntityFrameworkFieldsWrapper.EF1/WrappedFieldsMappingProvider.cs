using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;

namespace EFExtensions.EFWRappableFields
{
	class WrappedFieldsMappingProvider
	{
		// because it's a static cache, it has to be protected for multiple write access.
		private static Dictionary<Type, Dictionary<MemberInfo, MemberInfo>> mappingCache = new Dictionary<Type, Dictionary<MemberInfo, MemberInfo>>();
		private static ReaderWriterLockSlim protectMappingCache = new ReaderWriterLockSlim();
		private static BindingFlags defaultFieldFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
		private const String wrappingPrefix = "Db";
		

		public static void InitializeFrom(Assembly assembly)
		{
			protectMappingCache.EnterWriteLock();
			try
			{
				foreach (var wrappedType in assembly.GetTypes().Where(p => !p.IsAbstract && p.GetProperties(defaultFieldFlags).Any(f => f.Name.StartsWith(wrappingPrefix))))
				{
					mappingCache[wrappedType] = GetMappingsFor(wrappedType);
				}
			}
			finally
			{
				protectMappingCache.ExitWriteLock();
			}
		}

		private static Dictionary<MemberInfo, MemberInfo> GetMappingsFor(Type wrappedType)
		{
			var result = new Dictionary<MemberInfo, MemberInfo>();
			foreach (var wrappedField in wrappedType.GetProperties(defaultFieldFlags).Where(p => p.Name.StartsWith(wrappingPrefix)))
			{
				var wrappingField = wrappedType.GetProperties(defaultFieldFlags).FirstOrDefault(p => p.Name == wrappedField.Name.Substring(wrappingPrefix.Length));
				if (wrappingField != null)
				{
					result.Add(wrappingField, wrappedField);
				}
			}
			return result;
		}


		public static MemberInfo GetAvailableMapping(Type forType, MemberInfo wrappedProperty)
		{
			Dictionary<MemberInfo, MemberInfo> mappingForType = null;
			protectMappingCache.EnterReadLock(); // not using upgradable read lock because there can only be one thread using that.
			try
			{
				if (!mappingCache.ContainsKey(forType))
				{
					protectMappingCache.ExitReadLock(); // exit read lock and request a write lock
					protectMappingCache.EnterWriteLock();
					try
					{
						if (!mappingCache.ContainsKey(forType)) // check if during the lock switch anything changed.
						{
							if (!forType.IsClass || forType.IsAbstract || !forType.IsSubclassOf(typeof(System.Data.Objects.DataClasses.EntityObject)))
								return null;
							mappingCache.Add(forType, GetMappingsFor(forType));
						}
					}
					finally
					{
						protectMappingCache.ExitWriteLock();
						protectMappingCache.EnterReadLock(); // get back to read lock. so that the next finally works.
					}
				}
				mappingForType = mappingCache[forType];
			}
			finally
			{
				protectMappingCache.ExitReadLock();
			}
			if (mappingForType == null)
				return null;
			if (mappingForType.ContainsKey(wrappedProperty))
				return mappingForType[wrappedProperty];
			else
				return null;

		}

	}
}
