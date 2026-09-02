using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

// Token: 0x02002E13 RID: 11795
public class AnimalUtils
{
	// Token: 0x06017DBC RID: 97724 RVA: 0x006AE077 File Offset: 0x006AC277
	[NullableContext(1)]
	[return: Nullable(2)]
	public static AnimalComponent GetAnimalComponentConfig(CreatureDataComponent creatureDataComponent)
	{
		return TdUtils.GetComponent<AnimalComponent>(creatureDataComponent.GetPbEntityInitData().ComponentsData, EConfigComponent.AnimalComponent);
	}
}
