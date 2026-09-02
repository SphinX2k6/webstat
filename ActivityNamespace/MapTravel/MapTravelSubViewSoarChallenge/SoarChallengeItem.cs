using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using UnrealEngine;

namespace ActivityNamespace.MapTravel.MapTravelSubViewSoarChallenge
{
	// Token: 0x020043CD RID: 17357
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class SoarChallengeItem : TaskItemBase<ActivityTaskData>
	{
		// Token: 0x0602E235 RID: 188981 RVA: 0x00AD95D7 File Offset: 0x00AD77D7
		public SoarChallengeItem(ActivityMapTravelData activityBaseData) : base(activityBaseData)
		{
		}

		// Token: 0x0602E236 RID: 188982 RVA: 0x00AD95E0 File Offset: 0x00AD77E0
		public override void Refresh(ActivityTaskData taskData, bool isSelected, int gridIndex)
		{
			this.TaskData = taskData;
			SoarChallenge value = ConfigBase<ActivityMapTravelConfig>.Instance.GetSoarChallengeConfig(this.TaskData.Id).Value;
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

		// Token: 0x0602E237 RID: 188983 RVA: 0x00AD96BF File Offset: 0x00AD78BF
		public void SetClickRewardCb(Action clickRewardCb)
		{
			this.OnClickRewardCb = clickRewardCb;
		}

		// Token: 0x0602E238 RID: 188984 RVA: 0x00AD96C8 File Offset: 0x00AD78C8
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

		// Token: 0x0602E239 RID: 188985 RVA: 0x00AD9758 File Offset: 0x00AD7958
		protected override void OnClickedRewardButton()
		{
			Action onClickRewardCb = this.OnClickRewardCb;
			if (onClickRewardCb == null)
			{
				return;
			}
			onClickRewardCb();
		}

		// Token: 0x0401A18D RID: 106893
		[Nullable(2)]
		private Action OnClickRewardCb;
	}
}
