using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;
using CSharpScript.Game.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F26 RID: 20262
	public class SkipTaskCyberPunkAdamSmasher : SkipTask
	{
		// Token: 0x0603459E RID: 214430 RVA: 0x00D19EF8 File Offset: 0x00D180F8
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			CyberPunkData currentActivityData = ControllerBase<CyberPunkController>.Instance.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				base.Finish();
				return;
			}
			if (ConfigBase<CyberPunkConfig>.Instance.GetEdgeRunnerUnlockConfigById(5) == null)
			{
				base.Finish();
				return;
			}
			if (currentActivityData.IsFunctionUnlocked(5))
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(6090, 0, null).Forget<bool>();
			}
			else
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("AdamChallengeBlockTip", Array.Empty<object>());
			}
			base.Finish();
		}

		// Token: 0x0401E306 RID: 123654
		private const int BOSS_ENTRANCE_ID = 5;
	}
}
