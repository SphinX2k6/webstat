using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.SkipInterface;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064AD RID: 25773
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoadBookTaskNormalItem : RoadBookTaskItemBase<ActivityTaskData>
	{
		// Token: 0x060409AA RID: 264618 RVA: 0x0108F590 File Offset: 0x0108D790
		public RoadBookTaskNormalItem(ActivityRoadBookData activityBaseData) : base(activityBaseData)
		{
		}

		// Token: 0x060409AB RID: 264619 RVA: 0x0108F59C File Offset: 0x0108D79C
		public override void Refresh(ActivityTaskData taskData, bool isSelected, int gridIndex)
		{
			this.TaskData = taskData;
			RoadBookTask value = ConfigBase<ActivityRoadBookConfig>.Instance.GetRoadBookTaskConfig(this.TaskData.Id).Value;
			bool flag = taskData.Status == EActivityTaskState.FinishedAndClaimed;
			bool uiActive = value.JumpId > 0 && taskData.Status == EActivityTaskState.Active;
			bool uiActive2 = taskData.Status == EActivityTaskState.FinishedAndUnclaimed;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), value.Name, Array.Empty<object>());
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(Math.Min(taskData.Current, taskData.Target));
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(taskData.Target);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			this.RefreshRewardData(value.TaskReward);
			this.ButtonItem.SetUiActive(uiActive);
			this.RewardButtonItem.SetUiActive(uiActive2);
			base.GetItem(6).SetUIActive(value.JumpId == 0 && !flag);
			base.GetItem(5).SetUIActive(flag);
		}

		// Token: 0x060409AC RID: 264620 RVA: 0x0108F6B4 File Offset: 0x0108D8B4
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

		// Token: 0x060409AD RID: 264621 RVA: 0x0108F744 File Offset: 0x0108D944
		protected override void OnClickedButton()
		{
			RoadBookTask value = ConfigBase<ActivityRoadBookConfig>.Instance.GetRoadBookTaskConfig(this.TaskData.Id).Value;
			if (value.JumpId != 0)
			{
				SkipTaskManager.RunByConfigId(value.JumpId, null);
			}
		}

		// Token: 0x060409AE RID: 264622 RVA: 0x0108F785 File Offset: 0x0108D985
		public void SetBtnClickCallback(Action callback)
		{
			this.ClickRewardBtnCb = callback;
		}

		// Token: 0x060409AF RID: 264623 RVA: 0x0108F78E File Offset: 0x0108D98E
		protected override void OnClickedRewardButton()
		{
			Action clickRewardBtnCb = this.ClickRewardBtnCb;
			if (clickRewardBtnCb == null)
			{
				return;
			}
			clickRewardBtnCb();
		}

		// Token: 0x040242C8 RID: 148168
		protected new ActivityTaskData TaskData;

		// Token: 0x040242C9 RID: 148169
		[Nullable(2)]
		private Action ClickRewardBtnCb;
	}
}
