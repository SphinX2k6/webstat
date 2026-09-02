using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002389 RID: 9097
public class BattlePassTaskData
{
	// Token: 0x040088D5 RID: 35029
	[Nullable(1)]
	public List<TItem> RewardItemList = new List<TItem>();

	// Token: 0x040088D6 RID: 35030
	public int TaskId;

	// Token: 0x040088D7 RID: 35031
	public EBattlePassTaskState TaskState = EBattlePassTaskState.Running;

	// Token: 0x040088D8 RID: 35032
	public EBattlePassTaskUpdateState UpdateType;

	// Token: 0x040088D9 RID: 35033
	public int CurrentProgress;

	// Token: 0x040088DA RID: 35034
	public int TargetProgress;

	// Token: 0x040088DB RID: 35035
	public int Exp;

	// Token: 0x040088DC RID: 35036
	public int? SkipId;
}
