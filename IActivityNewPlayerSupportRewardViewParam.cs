using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.ItemReward;

// Token: 0x02001472 RID: 5234
[NullableContext(1)]
public interface IActivityNewPlayerSupportRewardViewParam
{
	// Token: 0x17000C27 RID: 3111
	// (get) Token: 0x0600926A RID: 37482
	RewardData<ICommonRewardInfo> RewardData { get; }

	// Token: 0x17000C28 RID: 3112
	// (get) Token: 0x0600926B RID: 37483
	List<int> TrialRoleList { get; }
}
