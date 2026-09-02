using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002992 RID: 10642
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ShipTowerTeamRecommendItemData
{
	// Token: 0x06015304 RID: 86788 RVA: 0x005DDC33 File Offset: 0x005DBE33
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ShipTowerTeamRecommendItemData()
	{
	}

	// Token: 0x0400A32E RID: 41774
	[RequiredMember]
	public List<ShipTowerMediumItemData> RoleIdList1;

	// Token: 0x0400A32F RID: 41775
	[RequiredMember]
	public List<ShipTowerMediumItemData> RoleIdList2;

	// Token: 0x0400A330 RID: 41776
	[RequiredMember]
	public int Buff1;

	// Token: 0x0400A331 RID: 41777
	[RequiredMember]
	public int Buff2;

	// Token: 0x0400A332 RID: 41778
	[RequiredMember]
	public int UseRate;

	// Token: 0x0400A333 RID: 41779
	[RequiredMember]
	public string Name;

	// Token: 0x0400A334 RID: 41780
	[Nullable(2)]
	public ShipTowerStageData StageData;
}
