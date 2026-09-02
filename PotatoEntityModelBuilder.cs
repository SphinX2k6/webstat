using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02000F72 RID: 3954
[NullableContext(1)]
[Nullable(0)]
public class PotatoEntityModelBuilder
{
	// Token: 0x0600642C RID: 25644 RVA: 0x001904D8 File Offset: 0x0018E6D8
	[return: Nullable(2)]
	public static IPotatoCombatInfo Get(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		Type[] modelTypes = PotatoEntityModelBuilder.ModelTypes;
		for (int i = 0; i < modelTypes.Length; i++)
		{
			MethodInfo method = modelTypes[i].GetMethod("BuildModel", BindingFlags.Static | BindingFlags.Public);
			if (method != null)
			{
				object obj = method.Invoke(null, new object[]
				{
					entityData,
					componentDataMap
				});
				if (obj != null)
				{
					return (IPotatoCombatInfo)obj;
				}
			}
		}
		return null;
	}

	// Token: 0x0600642D RID: 25645 RVA: 0x00190533 File Offset: 0x0018E733
	public static void Clear()
	{
		PotatoActivityEntityModel.Clear();
		PotatoEntityModel.Clear();
	}

	// Token: 0x04002FD2 RID: 12242
	[StaticVariableRuleIgnore]
	private static readonly Type[] ModelTypes = new Type[]
	{
		typeof(PotatoActivityEntityModel),
		typeof(PotatoEntityModel)
	};
}
