using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.SkipInterface;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006549 RID: 25929
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RealmBetweenTaskNormalItem : RealmBetweenTaskItemBase<ActivityTaskData>
	{
		// Token: 0x06040CEE RID: 265454 RVA: 0x0109E3C4 File Offset: 0x0109C5C4
		public RealmBetweenTaskNormalItem(ActivityRealmBetweenData activityBaseData) : base(activityBaseData)
		{
		}

		// Token: 0x06040CEF RID: 265455 RVA: 0x0109E3D0 File Offset: 0x0109C5D0
		public override void Refresh(ActivityTaskData taskData, bool isSelected, int gridIndex)
		{
			this.TaskData = taskData;
			RealmBetweenTask value = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetRealmBetweenTaskConfig(this.TaskData.Id).Value;
			bool flag = taskData.Status == EActivityTaskState.FinishedAndClaimed;
			bool uiActive = value.JumpId > 0 && taskData.Status == EActivityTaskState.Active;
			bool flag2 = taskData.Status == EActivityTaskState.FinishedAndUnclaimed;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), value.Name, Array.Empty<object>());
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(Math.Min(taskData.Current, taskData.Target));
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(taskData.Target);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			this.RefreshRewardData(value.TaskReward);
			this.ButtonItem.SetUiActive(uiActive);
			this.RewardButtonItem.SetUiActive(flag2);
			base.GetItem(6).SetUIActive(value.JumpId == 0 && !flag && !flag2);
			base.GetItem(5).SetUIActive(flag);
		}

		// Token: 0x06040CF0 RID: 265456 RVA: 0x0109E4EC File Offset: 0x0109C6EC
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

		// Token: 0x06040CF1 RID: 265457 RVA: 0x0109E57C File Offset: 0x0109C77C
		protected override void OnClickedButton()
		{
			RealmBetweenTask value = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetRealmBetweenTaskConfig(this.TaskData.Id).Value;
			if (value.JumpId != 0)
			{
				SkipTaskManager.RunByConfigId(value.JumpId, null);
			}
		}

		// Token: 0x06040CF2 RID: 265458 RVA: 0x0109E5BD File Offset: 0x0109C7BD
		public void SetBtnClickCallback(Action callback)
		{
			this.ClickRewardBtnCb = callback;
		}

		// Token: 0x06040CF3 RID: 265459 RVA: 0x0109E5C6 File Offset: 0x0109C7C6
		protected override void OnClickedRewardButton()
		{
			if (this.ClickRewardBtnCb != null)
			{
				this.ClickRewardBtnCb();
				return;
			}
			ControllerBase<ActivityRealmBetweenController>.Instance.RequestMultiRealmBetweenTaskReward(new int[]
			{
				this.TaskData.Id
			});
		}

		// Token: 0x040245B5 RID: 148917
		protected new ActivityTaskData TaskData;

		// Token: 0x040245B6 RID: 148918
		[Nullable(2)]
		private Action ClickRewardBtnCb;
	}
}
