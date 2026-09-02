using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02000F7E RID: 3966
public abstract class SurvivorsRogueEntityBaseModel
{
	// Token: 0x06006489 RID: 25737 RVA: 0x00193143 File Offset: 0x00191343
	[NullableContext(1)]
	[return: Nullable(2)]
	public static ISurvivorsRogueCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		return null;
	}

	// Token: 0x0600648A RID: 25738 RVA: 0x00193146 File Offset: 0x00191346
	public static void Clear()
	{
	}
}
