using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.ItemReward;

// Token: 0x020029B6 RID: 10678
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerFightFinishViewParams
{
	// Token: 0x0400A42C RID: 42028
	public int TotalScore;

	// Token: 0x0400A42D RID: 42029
	[Nullable(2)]
	public string GradeResId;

	// Token: 0x0400A42E RID: 42030
	public bool IsNewRecord;

	// Token: 0x0400A42F RID: 42031
	public bool IsEndless;

	// Token: 0x0400A430 RID: 42032
	public List<IRewardExploreConfirmButton> ButtonList;

	// Token: 0x0400A431 RID: 42033
	public List<ShipTowerFightFinishItemData> AreaList;
}
