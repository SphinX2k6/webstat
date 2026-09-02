using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200298E RID: 10638
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerAreaItemData
{
	// Token: 0x06015300 RID: 86784 RVA: 0x005DDC13 File Offset: 0x005DBE13
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerAreaItemData()
	{
	}

	// Token: 0x0400A317 RID: 41751
	[RequiredMember]
	public int Id;

	// Token: 0x0400A318 RID: 41752
	public int? Index;

	// Token: 0x0400A319 RID: 41753
	[RequiredMember]
	public string Name;

	// Token: 0x0400A31A RID: 41754
	[RequiredMember]
	public string Desc;

	// Token: 0x0400A31B RID: 41755
	[Nullable(2)]
	public string TimeContent;

	// Token: 0x0400A31C RID: 41756
	public bool? IsFinish;

	// Token: 0x0400A31D RID: 41757
	public bool? IsRedPoint;

	// Token: 0x0400A31E RID: 41758
	public bool? IsEndless;

	// Token: 0x0400A31F RID: 41759
	public int? MaxScore;

	// Token: 0x0400A320 RID: 41760
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<ShipTowerRewardItemData> RewardList;

	// Token: 0x0400A321 RID: 41761
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<ShipTowerRecordItemData> RecordList;
}
