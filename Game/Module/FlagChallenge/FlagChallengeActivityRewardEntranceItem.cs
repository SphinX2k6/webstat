using System;
using System.Collections.Generic;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D44 RID: 23876
	public class FlagChallengeActivityRewardEntranceItem : UiPanelBase
	{
		// Token: 0x0603C330 RID: 246576 RVA: 0x00F449F8 File Offset: 0x00F42BF8
		public FlagChallengeActivityRewardEntranceItem(int activityId)
		{
			this.ActivityId = activityId;
		}

		// Token: 0x0603C331 RID: 246577 RVA: 0x00F44A08 File Offset: 0x00F42C08
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnRewardBtnClick))
			};
		}

		// Token: 0x0603C332 RID: 246578 RVA: 0x00F44A9C File Offset: 0x00F42C9C
		protected override void OnStart()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RedDotFlagChallengeActivityReward, base.GetItem(2), null, this.ActivityId);
			this.RefreshProgress();
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnFlagChallengeTaskUpdate, new Action<int>(this.OnTaskUpdate));
		}

		// Token: 0x0603C333 RID: 246579 RVA: 0x00F44AE8 File Offset: 0x00F42CE8
		protected override void OnBeforeDestroy()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RedDotFlagChallengeActivityReward, base.GetItem(2), this.ActivityId);
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeTaskUpdate, new Action<int>(this.OnTaskUpdate));
		}

		// Token: 0x0603C334 RID: 246580 RVA: 0x00F44B24 File Offset: 0x00F42D24
		private void RefreshProgress()
		{
			FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(this.ActivityId);
			base.GetText(3).SetText(flagChallengeData.GetTaskProgressText(), true);
		}

		// Token: 0x0603C335 RID: 246581 RVA: 0x00F44B55 File Offset: 0x00F42D55
		private void OnRewardBtnClick()
		{
			ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeTaskView(this.ActivityId);
		}

		// Token: 0x0603C336 RID: 246582 RVA: 0x00F44B67 File Offset: 0x00F42D67
		private void OnTaskUpdate(int activityId)
		{
			if (activityId != this.ActivityId)
			{
				return;
			}
			this.RefreshProgress();
		}

		// Token: 0x04021CC5 RID: 138437
		private int ActivityId;
	}
}
