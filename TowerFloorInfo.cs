using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02002BDB RID: 11227
[NullableContext(1)]
[Nullable(0)]
public class TowerFloorInfo
{
	// Token: 0x06016693 RID: 91795 RVA: 0x00639328 File Offset: 0x00637528
	public TowerFloorInfo(int towerId, int star, List<TowerRolePb> formation, List<int> starIndex, bool isQuickPass)
	{
		this.TowerId = towerId;
		this.Star = star;
		this.Formation = formation;
		this.StarIndex = starIndex;
		this.IsQuickPass = isQuickPass;
		TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(this.TowerId);
		this.Difficulties = towerInfo.Value.Difficulty;
		this.Area = towerInfo.Value.AreaNum;
		this.FloorNumber = towerInfo.Value.Floor;
		this.Cost = towerInfo.Value.Cost;
	}

	// Token: 0x0400AD6B RID: 44395
	public readonly int Difficulties = -1;

	// Token: 0x0400AD6C RID: 44396
	public readonly int Area = -1;

	// Token: 0x0400AD6D RID: 44397
	public readonly int FloorNumber = -1;

	// Token: 0x0400AD6E RID: 44398
	public readonly int Cost = -1;

	// Token: 0x0400AD6F RID: 44399
	public readonly int TowerId;

	// Token: 0x0400AD70 RID: 44400
	public int Star;

	// Token: 0x0400AD71 RID: 44401
	public List<TowerRolePb> Formation;

	// Token: 0x0400AD72 RID: 44402
	public List<int> StarIndex;

	// Token: 0x0400AD73 RID: 44403
	public bool IsQuickPass;
}
