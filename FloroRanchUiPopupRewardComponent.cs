using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001BEA RID: 7146
[FloroRanchEntityComponent(EFloroRanchEntityComponent.FloroRanchUiPopupRewardComponent)]
public class FloroRanchUiPopupRewardComponent : FloroRanchEntityComponentBase
{
	// Token: 0x0600CFEE RID: 53230 RVA: 0x003731B0 File Offset: 0x003713B0
	public UniTask ShowPopupReward(EFloroRanchPopupRewardType rewardType, int count)
	{
		FloroRanchUiPopupRewardComponent.<ShowPopupReward>d__0 <ShowPopupReward>d__;
		<ShowPopupReward>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowPopupReward>d__.<>4__this = this;
		<ShowPopupReward>d__.rewardType = rewardType;
		<ShowPopupReward>d__.count = count;
		<ShowPopupReward>d__.<>1__state = -1;
		<ShowPopupReward>d__.<>t__builder.Start<FloroRanchUiPopupRewardComponent.<ShowPopupReward>d__0>(ref <ShowPopupReward>d__);
		return <ShowPopupReward>d__.<>t__builder.Task;
	}
}
