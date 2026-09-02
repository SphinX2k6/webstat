using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006560 RID: 25952
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MissionToggleItem : GridProxyAbstract<ActivityTaskData>
	{
		// Token: 0x06040D64 RID: 265572 RVA: 0x010A075C File Offset: 0x0109E95C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
		}

		// Token: 0x06040D65 RID: 265573 RVA: 0x010A0824 File Offset: 0x0109EA24
		protected override UniTask OnBeforeStartAsync()
		{
			MissionToggleItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MissionToggleItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040D66 RID: 265574 RVA: 0x010A0868 File Offset: 0x0109EA68
		protected override void OnStart()
		{
			this.RewardScrollView = new GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData>(base.GetScrollViewWithScrollbar(2), () => new ActivitySmallItemGrid(), null, false, null);
			this.GotoButton.SetLocalTextNew("RealmBetweenJump_Text", Array.Empty<object>());
			this.RewardButton.SetLocalTextNew("RealmBetweenGetReward_Text", Array.Empty<object>());
		}

		// Token: 0x06040D67 RID: 265575 RVA: 0x010A08D4 File Offset: 0x0109EAD4
		public override void Refresh(ActivityTaskData taskData, bool isSelected, int gridIndex)
		{
			this.TaskData = taskData;
			RealmBetweenChallenge value = ConfigBase<ActivityRealmBetweenConfig>.Instance.GetMotorChallengeConfig(this.TaskData.Id).Value;
			bool uiactive = taskData.Status == EActivityTaskState.FinishedAndClaimed;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), value.ScoreText, Array.Empty<object>());
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(taskData.Current);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(taskData.Target);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			this.RefreshRewardData(value.Reward);
			this.RewardButton.SetUiActive(taskData.Status == EActivityTaskState.FinishedAndUnclaimed);
			base.GetItem(4).SetUIActive(taskData.Status == EActivityTaskState.Active);
			base.GetItem(7).SetUIActive(uiactive);
		}

		// Token: 0x06040D68 RID: 265576 RVA: 0x010A09B3 File Offset: 0x0109EBB3
		public void SetClickRewardCb(Action clickRewardCb)
		{
			this.OnClickRewardCb = clickRewardCb;
		}

		// Token: 0x06040D69 RID: 265577 RVA: 0x010A09BC File Offset: 0x0109EBBC
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

		// Token: 0x06040D6A RID: 265578 RVA: 0x010A0A4C File Offset: 0x0109EC4C
		private void OnClickedRewardButton()
		{
			Action onClickRewardCb = this.OnClickRewardCb;
			if (onClickRewardCb == null)
			{
				return;
			}
			onClickRewardCb();
		}

		// Token: 0x0402461E RID: 149022
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<ActivitySmallItemGrid, IItemGridData> RewardScrollView;

		// Token: 0x0402461F RID: 149023
		private ActivityButtonItem GotoButton;

		// Token: 0x04024620 RID: 149024
		private ActivityButtonItem RewardButton;

		// Token: 0x04024621 RID: 149025
		private ActivityTaskData TaskData;

		// Token: 0x04024622 RID: 149026
		[Nullable(2)]
		private Action OnClickRewardCb;
	}
}
