using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02000F2C RID: 3884
public class FinalBattleEntityModelBuilder
{
	// Token: 0x060060FC RID: 24828 RVA: 0x00184076 File Offset: 0x00182276
	[NullableContext(1)]
	[return: Nullable(2)]
	public static IFinalBattleCombatInfo Get(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		return FinalBattleEntityModel.BuildModel(entityData, componentDataMap);
	}

	// Token: 0x060060FD RID: 24829 RVA: 0x0018407F File Offset: 0x0018227F
	public static void Clear()
	{
		FinalBattleEntityModel.Clear();
	}
}
