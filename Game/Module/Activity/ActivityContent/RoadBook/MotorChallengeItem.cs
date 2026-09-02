using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064AF RID: 25775
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorChallengeItem : RoadBookTaskItemBase<ActivityTaskData>
	{
		// Token: 0x060409B3 RID: 264627 RVA: 0x0108F84D File Offset: 0x0108DA4D
		public MotorChallengeItem(ActivityRoadBookData activityBaseData) : base(activityBaseData)
		{
		}

		// Token: 0x060409B4 RID: 264628 RVA: 0x0108F858 File Offset: 0x0108DA58
		public override void Refresh(ActivityTaskData taskData, bool isSelected, int gridIndex)
		{
			this.TaskData = taskData;
			MotorcycleChallenge value = ConfigBase<ActivityRoadBookConfig>.Instance.GetMotorChallengeConfig(this.TaskData.Id).Value;
			bool uiactive = taskData.Status == EActivityTaskState.FinishedAndClaimed;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), value.ScoreText, Array.Empty<object>());
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(taskData.Current);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(taskData.Target);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			this.RefreshRewardData(value.Reward);
			this.RewardButtonItem.SetUiActive(taskData.Status == EActivityTaskState.FinishedAndUnclaimed);
			base.GetItem(6).SetUIActive(taskData.Status == EActivityTaskState.Active);
			base.GetItem(5).SetUIActive(uiactive);
		}

		// Token: 0x060409B5 RID: 264629 RVA: 0x0108F937 File Offset: 0x0108DB37
		public void SetClickRewardCb(Action clickRewardCb)
		{
			this.OnClickRewardCb = clickRewardCb;
		}

		// Token: 0x060409B6 RID: 264630 RVA: 0x0108F940 File Offset: 0x0108DB40
		private void RefreshRewardData(int rewardId)
		{
			List<IItemGridData> list = new List<IItemGridData>();
			foreach (TItem item in ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(rewardId))
			{
				ItemGridData item2 = new ItemGridData
				{
					Item = item,
					HasClaimed = (this.TaskData.Status == EActivityTaskState.FinishedAndClaimed)
				};
				list.Add(item2);
			}
			this.RewardScrollView.RefreshByData(list, null, false);
		}

		// Token: 0x060409B7 RID: 264631 RVA: 0x0108F9D0 File Offset: 0x0108DBD0
		protected override void OnClickedRewardButton()
		{
			Action onClickRewardCb = this.OnClickRewardCb;
			if (onClickRewardCb == null)
			{
				return;
			}
			onClickRewardCb();
		}

		// Token: 0x040242CB RID: 148171
		protected new ActivityTaskData TaskData;

		// Token: 0x040242CC RID: 148172
		[Nullable(2)]
		private Action OnClickRewardCb;
	}
}
