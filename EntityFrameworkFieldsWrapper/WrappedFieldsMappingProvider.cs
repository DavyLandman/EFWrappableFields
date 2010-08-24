using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace EFExtensions.EFWRappableFields
{
	class WrappedFieldsMappingProvider
	{
		// 
		private static Dictionary<Type, Dictionary<MemberInfo, MemberInfo>> mappingCache = new Dictionary<Type, Dictionary<MemberInfo, MemberInfo>>();
		private static BindingFlags defaultFieldFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
		private const String wrappingPrefix = "Db";

		public static void InitializeFrom(Assembly assembly)
		{
			foreach (var wrappedType in assembly.GetTypes().Where(p => !p.IsAbstract && p.GetProperties(defaultFieldFlags).Any(f => f.Name.StartsWith(wrappingPrefix))))
			{
				mappingCache[wrappedType] = GetMappingsFor(wrappedType);
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
			if (!mappingCache.ContainsKey(forType))
			{
				if (!forType.IsClass || forType.IsAbstract || !forType.IsSubclassOf(typeof(System.Data.Objects.DataClasses.EntityObject)))
					return null;
				mappingCache.Add(forType, GetMappingsFor(forType));
			}
			var result = mappingCache[forType];
			if (result.ContainsKey(wrappedProperty))
			{
				return result[wrappedProperty];
			}
			else
			{
				return null;
			}
		}

	}
}
