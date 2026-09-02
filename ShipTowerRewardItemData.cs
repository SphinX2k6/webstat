using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200298F RID: 10639
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerRewardItemData
{
	// Token: 0x06015301 RID: 86785 RVA: 0x005DDC1B File Offset: 0x005DBE1B
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerRewardItemData()
	{
	}

	// Token: 0x0400A322 RID: 41762
	[RequiredMember]
	public int Id;

	// Token: 0x0400A323 RID: 41763
	[RequiredMember]
	public string TitleKey;

	// Token: 0x0400A324 RID: 41764
	[RequiredMember]
	public List<TItem> RewardList;

	// Token: 0x0400A325 RID: 41765
	[RequiredMember]
	public bool IsReceive;

	// Token: 0x0400A326 RID: 41766
	[RequiredMember]
	public bool IsProgress;

	// Token: 0x0400A327 RID: 41767
	[RequiredMember]
	public bool IsCompleted;

	// Token: 0x0400A328 RID: 41768
	[RequiredMember]
	public int TotalScore;
}
