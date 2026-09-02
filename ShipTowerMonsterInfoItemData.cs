using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002997 RID: 10647
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerMonsterInfoItemData
{
	// Token: 0x06015309 RID: 86793 RVA: 0x005DDC5B File Offset: 0x005DBE5B
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerMonsterInfoItemData()
	{
	}

	// Token: 0x0400A340 RID: 41792
	[RequiredMember]
	public string Title;

	// Token: 0x0400A341 RID: 41793
	[RequiredMember]
	public int Level;

	// Token: 0x0400A342 RID: 41794
	[RequiredMember]
	public string MonsterIcon;

	// Token: 0x0400A343 RID: 41795
	[RequiredMember]
	public List<int> ElementList;
}
