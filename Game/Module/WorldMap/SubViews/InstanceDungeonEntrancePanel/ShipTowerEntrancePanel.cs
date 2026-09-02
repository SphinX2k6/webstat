using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.InstanceDungeonEntrancePanel
{
	// Token: 0x02004BAC RID: 19372
	[NullableContext(1)]
	[Nullable(0)]
	public class ShipTowerEntrancePanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x06032934 RID: 207156 RVA: 0x00CAA254 File Offset: 0x00CA8454
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x06032935 RID: 207157 RVA: 0x00CAA25C File Offset: 0x00CA845C
		protected override UniTask OnBeforeStartAsync()
		{
			ShipTowerEntrancePanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerEntrancePanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032936 RID: 207158 RVA: 0x00CAA29F File Offset: 0x00CA849F
		protected override void OnStart()
		{
			base.OnStart();
		}

		// Token: 0x06032937 RID: 207159 RVA: 0x00CAA2A8 File Offset: 0x00CA84A8
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIItem item = base.GetItem(25);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(32);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			RewardItemBar rewardsView = this.RewardsView;
			if (rewardsView == null)
			{
				return;
			}
			rewardsView.SetActive(false);
		}

		// Token: 0x06032938 RID: 207160 RVA: 0x00CAA2F4 File Offset: 0x00CA84F4
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				TeleportMarkItem teleportMarkItem = param[0] as TeleportMarkItem;
				if (teleportMarkItem != null)
				{
					this.LayoutContext.MarkItem = teleportMarkItem;
					this.RefreshReward();
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateDesc(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
					bool flag = base.UpdateQuickGoto();
					WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
					if (layoutContext != null)
					{
						layoutContext.SetConfirmBtnActive(!flag);
					}
					bool activityOpenState = ModelBase<ShipTowerModel>.Instance.IsOpen();
					this.SetActivityOpenState(activityOpenState);
				}
			}
		}

		// Token: 0x06032939 RID: 207161 RVA: 0x00CAA38B File Offset: 0x00CA858B
		private void OnSecondRefresh()
		{
			this.RefreshTime();
		}

		// Token: 0x0603293A RID: 207162 RVA: 0x00CAA394 File Offset: 0x00CA8594
		private void RefreshTime()
		{
			CommonDefine.ICountDown seasonCountDownData = ModelBase<ShipTowerModel>.Instance.GetSeasonCountDownData();
			InstanceDungeonCostTip instanceDungeonCostTip = this.InstanceCostTipView.AddItemByKey("time");
			string leftText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("GhostShipTimeProgress_Text", null) ?? "", new string[]
			{
				""
			});
			instanceDungeonCostTip.SetLeftText(leftText);
			instanceDungeonCostTip.SetRightText(seasonCountDownData.CountDownText ?? "");
			instanceDungeonCostTip.SetHelpButtonVisible(false);
			if (ModelBase<ShipTowerModel>.Instance.TimeIsOver())
			{
				this.CheckUpdateProto().Forget();
			}
		}

		// Token: 0x0603293B RID: 207163 RVA: 0x00CAA420 File Offset: 0x00CA8620
		private void SetActivityOpenState(bool isOpen)
		{
			UUIItem item = base.GetItem(14);
			if (item != null)
			{
				item.SetUIActive(isOpen);
			}
			this.ClearTimer();
			if (!isOpen)
			{
				return;
			}
			this.RefreshTime();
			this.UpdateRewardProgress();
			this.TimerId = TimerSystem.Instance.Forever(delegate(float delta)
			{
				this.OnSecondRefresh();
			}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		}

		// Token: 0x0603293C RID: 207164 RVA: 0x00CAA488 File Offset: 0x00CA8688
		private UniTask CheckUpdateProto()
		{
			ShipTowerEntrancePanel.<CheckUpdateProto>d__15 <CheckUpdateProto>d__;
			<CheckUpdateProto>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckUpdateProto>d__.<>4__this = this;
			<CheckUpdateProto>d__.<>1__state = -1;
			<CheckUpdateProto>d__.<>t__builder.Start<ShipTowerEntrancePanel.<CheckUpdateProto>d__15>(ref <CheckUpdateProto>d__);
			return <CheckUpdateProto>d__.<>t__builder.Task;
		}

		// Token: 0x0603293D RID: 207165 RVA: 0x00CAA4CC File Offset: 0x00CA86CC
		private void UpdateRewardProgress()
		{
			InstanceDungeonCostTip instanceDungeonCostTip = this.InstanceCostTipView.AddItemByKey("score");
			string rewardProgressText = ModelBase<ShipTowerModel>.Instance.GetRewardProgressText(false);
			string currentStageSeasonName = ModelBase<ShipTowerModel>.Instance.GetCurrentStageSeasonName();
			instanceDungeonCostTip.SetHelpButtonVisible(false);
			instanceDungeonCostTip.SetLeftText(currentStageSeasonName);
			instanceDungeonCostTip.SetRightText(rewardProgressText);
			instanceDungeonCostTip.SetStarVisible(false);
		}

		// Token: 0x0603293E RID: 207166 RVA: 0x00CAA51B File Offset: 0x00CA871B
		protected override void OnCloseWorldMapSecondaryUi()
		{
			TipsListView instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView != null)
			{
				instanceCostTipView.Clear();
			}
			this.ClearTimer();
		}

		// Token: 0x0603293F RID: 207167 RVA: 0x00CAA534 File Offset: 0x00CA8734
		private void ClearTimer()
		{
			if (this.TimerId != null && TimerSystem.Instance.Has(this.TimerId))
			{
				TimerSystem.Instance.Remove(this.TimerId);
				this.TimerId = null;
			}
		}

		// Token: 0x06032940 RID: 207168 RVA: 0x00CAA568 File Offset: 0x00CA8768
		protected override void OnBeforeDestroy()
		{
			this.ClearTimer();
			RewardItemBar rewardsView = this.RewardsView;
			if (rewardsView != null)
			{
				rewardsView.Destroy(null);
			}
			TipsListView instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView != null)
			{
				instanceCostTipView.Clear();
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x06032941 RID: 207169 RVA: 0x00CAA59C File Offset: 0x00CA879C
		private void RefreshReward()
		{
			int valueOrDefault = ConfigCommonParamById.GetIntConfig("GhostShipReward").GetValueOrDefault(1);
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(valueOrDefault);
			if (dropPackagePreviewItemList.Count == 0)
			{
				RewardItemBar rewardsView = this.RewardsView;
				if (rewardsView == null)
				{
					return;
				}
				rewardsView.SetActive(false);
				return;
			}
			else
			{
				RewardItemBar rewardsView2 = this.RewardsView;
				if (rewardsView2 != null)
				{
					rewardsView2.SetActive(true);
				}
				RewardItemBar rewardsView3 = this.RewardsView;
				if (rewardsView3 != null)
				{
					rewardsView3.RebuildRewardsByData(dropPackagePreviewItemList);
				}
				RewardItemBar rewardsView4 = this.RewardsView;
				if (rewardsView4 == null)
				{
					return;
				}
				rewardsView4.SetTitleNewTxt("GhostShipMarkRewardTitle_Text");
				return;
			}
		}

		// Token: 0x0401D7BA RID: 120762
		private const string TIME_KEY = "time";

		// Token: 0x0401D7BB RID: 120763
		private const string REWARD_PROGRESS_KEY = "score";

		// Token: 0x0401D7BC RID: 120764
		[Nullable(2)]
		private TipsListView InstanceCostTipView;

		// Token: 0x0401D7BD RID: 120765
		[Nullable(2)]
		protected RewardItemBar RewardsView;

		// Token: 0x0401D7BE RID: 120766
		[Nullable(2)]
		private TimerHandle TimerId;

		// Token: 0x0401D7BF RID: 120767
		private bool IsUpdateProto;

		// Token: 0x0200AC86 RID: 44166
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x040359F9 RID: 219641
			public const int ShipTowerEntrancePanel = 0;
		}
	}
}
