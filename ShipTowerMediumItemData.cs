using System;
using System.Runtime.CompilerServices;

// Token: 0x02002999 RID: 10649
[RequiredMember]
public class ShipTowerMediumItemData
{
	// Token: 0x0601530B RID: 86795 RVA: 0x005DDC6B File Offset: 0x005DBE6B
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerMediumItemData()
	{
	}

	// Token: 0x0400A349 RID: 41801
	[RequiredMember]
	public int Id;

	// Token: 0x0400A34A RID: 41802
	[RequiredMember]
	public int Count;

	// Token: 0x0400A34B RID: 41803
	public bool? IsBuff;

	// Token: 0x0400A34C RID: 41804
	public int SkillBranchId;
}
