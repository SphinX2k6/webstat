using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006264 RID: 25188
	[NullableContext(1)]
	public interface ITotalTopUpPreviewViewParam
	{
		// Token: 0x17009C32 RID: 39986
		// (get) Token: 0x0603F77B RID: 259963
		// (set) Token: 0x0603F77C RID: 259964
		TotalTopUpReward RewardConfig { get; set; }

		// Token: 0x17009C33 RID: 39987
		// (get) Token: 0x0603F77D RID: 259965
		// (set) Token: 0x0603F77E RID: 259966
		TotalTopUpRewardData RewardData { get; set; }
	}
}
