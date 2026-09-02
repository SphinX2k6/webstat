using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02000F6B RID: 3947
public abstract class PotatoEntityBaseModel
{
	// Token: 0x060063AE RID: 25518 RVA: 0x0018FC55 File Offset: 0x0018DE55
	[NullableContext(1)]
	[return: Nullable(2)]
	public static IPotatoCombatInfo BuildModel(EntityPb entityData, Dictionary<string, EntityComponentPb> componentDataMap)
	{
		return null;
	}

	// Token: 0x060063AF RID: 25519 RVA: 0x0018FC58 File Offset: 0x0018DE58
	public static void Clear()
	{
	}
}
