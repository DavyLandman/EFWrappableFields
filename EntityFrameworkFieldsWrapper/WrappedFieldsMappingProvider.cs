using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace azM.EFWRappableFields
{
	class WrappedFieldsMappingProvider
	{
		// 
		private static Dictionary<Type, Dictionary<MemberInfo, MemberInfo>> mappingCache = new Dictionary<Type, Dictionary<MemberInfo, MemberInfo>>();

		public static void InitializeFrom(Assembly assembly)
		{
			var type = typeof(IHaveFieldsWrapped);
			foreach (var wrappedType in assembly.GetTypes().Where(p => type.IsAssignableFrom(p) && !p.IsAbstract))
			{
				mappingCache[wrappedType] = GetMappingsFor(wrappedType);
			}
		}

		private static Dictionary<MemberInfo, MemberInfo> GetMappingsFor(Type wrappedType)
		{
			var objectWithWrappedProperties = Activator.CreateInstance(wrappedType) as IHaveFieldsWrapped;
			if (objectWithWrappedProperties == null)
				return new Dictionary<MemberInfo, MemberInfo>();
			else
				return objectWithWrappedProperties.GetMappings();
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
