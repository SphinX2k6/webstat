using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002996 RID: 10646
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerMonsterListItemData
{
	// Token: 0x06015308 RID: 86792 RVA: 0x005DDC53 File Offset: 0x005DBE53
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerMonsterListItemData()
	{
	}

	// Token: 0x0400A33E RID: 41790
	[RequiredMember]
	public string Title;

	// Token: 0x0400A33F RID: 41791
	[RequiredMember]
	public List<ShipTowerMonsterInfoItemData> MonsterInfoList;
}
