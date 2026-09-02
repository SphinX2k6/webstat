using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001440 RID: 5184
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MowingTowerModel : ModelBase<MowingTowerModel>
{
	// Token: 0x0600904C RID: 36940 RVA: 0x0025EE7A File Offset: 0x0025D07A
	public bool IsOpenMowingTowerFormation()
	{
		return this.CurrentOptionArea != -1;
	}

	// Token: 0x040042F3 RID: 17139
	[Nullable(2)]
	public MowingTowerLevelDetailInfo CurrentSelectLevelDetailData;

	// Token: 0x040042F4 RID: 17140
	[Nullable(2)]
	public MowingTowerTeamInfo CurrentTeamInfo;

	// Token: 0x040042F5 RID: 17141
	public bool PlayBackAnimation;

	// Token: 0x040042F6 RID: 17142
	public int CurrentSelectActivityId;

	// Token: 0x040042F7 RID: 17143
	public int CurrentOptionArea = -1;

	// Token: 0x040042F8 RID: 17144
	public List<int> OtherHalfAreaRoleList = new List<int>();

	// Token: 0x040042F9 RID: 17145
	public int[] AddLevel = new int[]
	{
		-1,
		-1
	};
}
