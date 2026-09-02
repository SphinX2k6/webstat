using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001B8E RID: 7054
[NullableContext(1)]
[Nullable(0)]
public class MapAreaRewardParam : IMapAreaRewardParam
{
	// Token: 0x17001095 RID: 4245
	// (get) Token: 0x0600CD06 RID: 52486 RVA: 0x003693E4 File Offset: 0x003675E4
	// (set) Token: 0x0600CD07 RID: 52487 RVA: 0x003693EC File Offset: 0x003675EC
	public int InitValue { get; set; }

	// Token: 0x17001096 RID: 4246
	// (get) Token: 0x0600CD08 RID: 52488 RVA: 0x003693F5 File Offset: 0x003675F5
	// (set) Token: 0x0600CD09 RID: 52489 RVA: 0x003693FD File Offset: 0x003675FD
	public int MaxValue { get; set; }

	// Token: 0x17001097 RID: 4247
	// (get) Token: 0x0600CD0A RID: 52490 RVA: 0x00369406 File Offset: 0x00367606
	// (set) Token: 0x0600CD0B RID: 52491 RVA: 0x0036940E File Offset: 0x0036760E
	public List<DailyActivityDefine.IActivityGoalData> RewardDataList { get; set; }

	// Token: 0x17001098 RID: 4248
	// (get) Token: 0x0600CD0C RID: 52492 RVA: 0x00369417 File Offset: 0x00367617
	// (set) Token: 0x0600CD0D RID: 52493 RVA: 0x0036941F File Offset: 0x0036761F
	public Action GetRewardCallback { get; set; }
}
