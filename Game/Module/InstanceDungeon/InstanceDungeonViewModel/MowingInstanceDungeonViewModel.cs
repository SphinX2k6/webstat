using System;
using CSharpScript.Game.Module.Activity.ActivityContent.Mowing;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel
{
	// Token: 0x02005BDA RID: 23514
	public class MowingInstanceDungeonViewModel : InstanceDungeonViewModelBase
	{
		// Token: 0x0603B899 RID: 243865 RVA: 0x00F1794C File Offset: 0x00F15B4C
		protected override bool OnCheckNeedOnTimer(int instanceId)
		{
			ActivityMowingData mowingActivityData = ControllerBase<ActivityMowingController>.Instance.GetMowingActivityData();
			return mowingActivityData != null && !mowingActivityData.GetActivityLevelUnlockState(instanceId);
		}

		// Token: 0x0603B89A RID: 243866 RVA: 0x00F17973 File Offset: 0x00F15B73
		protected override void OnTimerRefreshFunction(float delta)
		{
			this.View.RefreshMowingInstance();
		}
	}
}
