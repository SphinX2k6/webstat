using System;
using System.Runtime.CompilerServices;

// Token: 0x0200299A RID: 10650
[RequiredMember]
public class ShipTowerReviewItemData
{
	// Token: 0x0601530C RID: 86796 RVA: 0x005DDC73 File Offset: 0x005DBE73
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerReviewItemData()
	{
	}

	// Token: 0x0400A34D RID: 41805
	[Nullable(1)]
	[RequiredMember]
	public string Title;

	// Token: 0x0400A34E RID: 41806
	[RequiredMember]
	public int Score;

	// Token: 0x0400A34F RID: 41807
	[Nullable(2)]
	public string Grade;

	// Token: 0x0400A350 RID: 41808
	[RequiredMember]
	public int StageId;

	// Token: 0x0400A351 RID: 41809
	[RequiredMember]
	public bool IsQuickPass;
}
