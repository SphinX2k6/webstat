using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200299B RID: 10651
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerFightFinishItemData
{
	// Token: 0x0601530D RID: 86797 RVA: 0x005DDC7B File Offset: 0x005DBE7B
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerFightFinishItemData()
	{
	}

	// Token: 0x0400A352 RID: 41810
	[RequiredMember]
	public string TotalTitle;

	// Token: 0x0400A353 RID: 41811
	[RequiredMember]
	public string TitleA;

	// Token: 0x0400A354 RID: 41812
	[RequiredMember]
	public string TitleB;

	// Token: 0x0400A355 RID: 41813
	[RequiredMember]
	public int ScoreA;

	// Token: 0x0400A356 RID: 41814
	[RequiredMember]
	public int ScoreB;

	// Token: 0x0400A357 RID: 41815
	[RequiredMember]
	public List<ShipTowerMediumItemData> RoleList;

	// Token: 0x0400A358 RID: 41816
	[RequiredMember]
	public int BuffId;
}
