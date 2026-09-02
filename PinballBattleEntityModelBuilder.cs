using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02000F65 RID: 3941
public class PinballBattleEntityModelBuilder
{
	// Token: 0x06006398 RID: 25496 RVA: 0x0018F58C File Offset: 0x0018D78C
	[NullableContext(1)]
	[return: Nullable(2)]
	public static IPinballBattleCombatInfo Get(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		IPinballBattleCombatInfo pinballBattleCombatInfo = PinballBattleActivityEntityModel.BuildModel(entityData, componentDataMap);
		if (pinballBattleCombatInfo != null)
		{
			return pinballBattleCombatInfo;
		}
		pinballBattleCombatInfo = PinballBattleEntityModel.BuildModel(entityData, componentDataMap);
		if (pinballBattleCombatInfo != null)
		{
			return pinballBattleCombatInfo;
		}
		return null;
	}

	// Token: 0x06006399 RID: 25497 RVA: 0x0018F5B4 File Offset: 0x0018D7B4
	public static void Clear()
	{
		PinballBattleActivityEntityModel.Clear();
		PinballBattleEntityModel.Clear();
	}
}
