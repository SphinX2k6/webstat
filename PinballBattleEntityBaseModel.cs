using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02000F5E RID: 3934
public abstract class PinballBattleEntityBaseModel
{
	// Token: 0x06006336 RID: 25398 RVA: 0x0018EE95 File Offset: 0x0018D095
	[NullableContext(1)]
	[return: Nullable(2)]
	public static IPinballBattleCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		return null;
	}

	// Token: 0x06006337 RID: 25399 RVA: 0x0018EE98 File Offset: 0x0018D098
	public static void Clear()
	{
	}
}
