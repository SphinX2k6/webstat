using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02000F85 RID: 3973
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueEntityModelBuilder
{
	// Token: 0x060064FB RID: 25851 RVA: 0x0019392C File Offset: 0x00191B2C
	[return: Nullable(2)]
	public static ISurvivorsRogueCombatInfo Get(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		Type[] modelTypes = SurvivorsRogueEntityModelBuilder.ModelTypes;
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
					return (ISurvivorsRogueCombatInfo)obj;
				}
			}
		}
		return null;
	}

	// Token: 0x060064FC RID: 25852 RVA: 0x00193987 File Offset: 0x00191B87
	public static void Clear()
	{
		SurvivorsRogueActivityEntityModel.Clear();
		SurvivorsRogueEntityModel.Clear();
	}

	// Token: 0x0400301E RID: 12318
	[StaticVariableRuleIgnore]
	private static readonly Type[] ModelTypes = new Type[]
	{
		typeof(SurvivorsRogueActivityEntityModel),
		typeof(SurvivorsRogueEntityModel)
	};
}
