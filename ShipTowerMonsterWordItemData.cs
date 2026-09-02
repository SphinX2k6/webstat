using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002993 RID: 10643
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerMonsterWordItemData
{
	// Token: 0x06015305 RID: 86789 RVA: 0x005DDC3B File Offset: 0x005DBE3B
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerMonsterWordItemData()
	{
	}

	// Token: 0x0400A335 RID: 41781
	[RequiredMember]
	public string Title;

	// Token: 0x0400A336 RID: 41782
	[RequiredMember]
	public List<ShipTowerMonsterWordInfoItemData> InfoList;
}
