using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002998 RID: 10648
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerRecordItemData
{
	// Token: 0x0601530A RID: 86794 RVA: 0x005DDC63 File Offset: 0x005DBE63
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerRecordItemData()
	{
	}

	// Token: 0x0400A344 RID: 41796
	[RequiredMember]
	public string Title;

	// Token: 0x0400A345 RID: 41797
	[RequiredMember]
	public int Score;

	// Token: 0x0400A346 RID: 41798
	[RequiredMember]
	public int Wave;

	// Token: 0x0400A347 RID: 41799
	[RequiredMember]
	public List<ShipTowerMediumItemData> TeamList;

	// Token: 0x0400A348 RID: 41800
	[RequiredMember]
	public int BuffId;
}
