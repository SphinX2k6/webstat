using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.SkipInterface;
using UnrealEngine;

namespace ActivityNamespace.MapTravel.MapTravelSubViewTravelTask
{
	// Token: 0x020043CA RID: 17354
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class TaskNormalItem : TaskItemBase<ActivityTaskData>
	{
		// Token: 0x0602E217 RID: 188951 RVA: 0x00AD8DA0 File Offset: 0x00AD6FA0
		public TaskNormalItem(ActivityMapTravelData activityBaseData) : base(activityBaseData)
		{
		}

		// Token: 0x0602E218 RID: 188952 RVA: 0x00AD8DAC File Offset: 0x00AD6FAC
		public override void Refresh(ActivityTaskData taskData, bool isSelected, int gridIndex)
		{
			this.TaskData = taskData;
			TravelTask value = ConfigBase<ActivityMapTravelConfig>.Instance.GetTravelTaskConfig(this.TaskData.Id).Value;
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

		// Token: 0x0602E219 RID: 188953 RVA: 0x00AD8EC4 File Offset: 0x00AD70C4
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

		// Token: 0x0602E21A RID: 188954 RVA: 0x00AD8F54 File Offset: 0x00AD7154
		protected override void OnClickedButton()
		{
			TravelTask? travelTaskConfig = ConfigBase<ActivityMapTravelConfig>.Instance.GetTravelTaskConfig(this.TaskData.Id);
			if (travelTaskConfig.Value.JumpId > 0)
			{
				SkipTaskManager.RunByConfigId(travelTaskConfig.Value.JumpId, null);
			}
		}

		// Token: 0x0602E21B RID: 188955 RVA: 0x00AD8F9E File Offset: 0x00AD719E
		public void SetBtnClickCallback(Action callback)
		{
			this.ClickRewardBtnCb = callback;
		}

		// Token: 0x0602E21C RID: 188956 RVA: 0x00AD8FA7 File Offset: 0x00AD71A7
		protected override void OnClickedRewardButton()
		{
			Action clickRewardBtnCb = this.ClickRewardBtnCb;
			if (clickRewardBtnCb == null)
			{
				return;
			}
			clickRewardBtnCb();
		}

		// Token: 0x0401A186 RID: 106886
		[Nullable(2)]
		private Action ClickRewardBtnCb;
	}
}
