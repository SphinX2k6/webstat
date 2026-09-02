using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.InstanceDungeonEntrancePanel
{
	// Token: 0x02004BAD RID: 19373
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerEntrancePanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x06032945 RID: 207173 RVA: 0x00CAA634 File Offset: 0x00CA8834
		public override string GetResourceId()
		{
			return "UiView_Map_Tower_Tip_Prefab";
		}

		// Token: 0x06032946 RID: 207174 RVA: 0x00CAA63C File Offset: 0x00CA883C
		protected override void OnStart()
		{
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(5);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(true);
			}
			this.InstanceCostTipView = new TipsListView();
			this.InstanceCostTipView.Initialize(base.GetVerticalLayout(5));
			this.RewardsView = new RewardItemBar();
			UiPanelBase rewardsView = this.RewardsView;
			UUIItem item = base.GetItem(8);
			rewardsView.SetRootActor((item != null) ? item.GetOwner() : null, true);
			base.OnStart();
		}

		// Token: 0x06032947 RID: 207175 RVA: 0x00CAA6B6 File Offset: 0x00CA88B6
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIItem item = base.GetItem(25);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(32);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x06032948 RID: 207176 RVA: 0x00CAA6E8 File Offset: 0x00CA88E8
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				TeleportMarkItem teleportMarkItem = param[0] as TeleportMarkItem;
				if (teleportMarkItem != null)
				{
					this.LayoutContext.MarkItem = teleportMarkItem;
					int num = (teleportMarkItem != null) ? teleportMarkItem.MarkConfig.Value.RelativeId : 0;
					int markConfigId = teleportMarkItem.MarkConfigId;
					int num2;
					if (num == 0)
					{
						InstanceDungeonEntranceConfig instance = ConfigBase<InstanceDungeonEntranceConfig>.Instance;
						num2 = ((instance != null) ? instance.GetEntranceIdByMarkId(markConfigId) : 0);
					}
					else
					{
						num2 = num;
					}
					int id = num2;
					InstanceDungeonEntranceConfig instance2 = ConfigBase<InstanceDungeonEntranceConfig>.Instance;
					int flowId = (instance2 != null) ? instance2.GetInstanceDungeonEntranceFlowId(id) : 0;
					this.FlowId = flowId;
					this.RefreshTime();
					this.RefreshReward();
					this.RefreshExploreContainer(flowId);
					this.RefreshDifficult();
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
					this.ClearTimer();
					this.TimerId = TimerSystem.Instance.Forever(delegate(float delta)
					{
						this.OnSecondRefresh();
					}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
					this.RemainingTime = (double)ModelBase<TowerModel>.Instance.TowerEndTime.GetValueOrDefault() - Singleton<TimeUtil>.Instance.GetServerTime();
				}
			}
		}

		// Token: 0x06032949 RID: 207177 RVA: 0x00CAA833 File Offset: 0x00CA8A33
		private void OnSecondRefresh()
		{
			this.RefreshDifficult();
			this.RefreshExploreContainer(this.FlowId);
			this.RefreshTime();
		}

		// Token: 0x0603294A RID: 207178 RVA: 0x00CAA850 File Offset: 0x00CA8A50
		private void RefreshReward()
		{
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(3331);
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
				if (rewardsView3 == null)
				{
					return;
				}
				rewardsView3.RebuildRewardsByData(dropPackagePreviewItemList);
				return;
			}
		}

		// Token: 0x0603294B RID: 207179 RVA: 0x00CAA8AC File Offset: 0x00CA8AAC
		private void RefreshDifficult()
		{
			InstanceDungeonCostTip instanceDungeonCostTip = this.InstanceCostTipView.AddItemByKey("difficult");
			int maxDifficulty = ModelBase<TowerModel>.Instance.GetMaxDifficulty();
			instanceDungeonCostTip.SetHelpButtonVisible(false);
			instanceDungeonCostTip.SetLeftText(ConfigMultiTextLang.GetLocalTextNew("TowerProcess", null) ?? "");
			TowerClimbConfig instance = ConfigBase<TowerClimbConfig>.Instance;
			string text = (instance != null) ? instance.GetNewTowerDifficultTitle(maxDifficulty) : null;
			instanceDungeonCostTip.SetRightText(text ?? "");
		}

		// Token: 0x0603294C RID: 207180 RVA: 0x00CAA918 File Offset: 0x00CA8B18
		private void RefreshTime()
		{
			CommonDefine.ICountDown seasonCountDownData = ModelBase<TowerModel>.Instance.GetSeasonCountDownData();
			InstanceDungeonCostTip instanceDungeonCostTip = this.InstanceCostTipView.AddItemByKey("time");
			string leftText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_ActiveRemainTime_Text", null) ?? "", new string[]
			{
				""
			});
			instanceDungeonCostTip.SetLeftText(leftText);
			instanceDungeonCostTip.SetRightText(seasonCountDownData.CountDownText ?? "");
			instanceDungeonCostTip.SetHelpButtonVisible(false);
			this.RemainingTime -= 1.0;
			if (this.RemainingTime < 2.0)
			{
				ControllerBase<TowerController>.Instance.RefreshTower(0).Forget<bool>();
			}
		}

		// Token: 0x0603294D RID: 207181 RVA: 0x00CAA9C4 File Offset: 0x00CA8BC4
		private void RefreshExploreContainer(int flowId)
		{
			if (flowId >= 4)
			{
				InstanceDungeonCostTip instanceDungeonCostTip = this.InstanceCostTipView.AddItemByKey("score");
				TowerModel instance = ModelBase<TowerModel>.Instance;
				int maxDifficulty = instance.GetMaxDifficulty();
				int difficultyMaxStars = instance.GetDifficultyMaxStars(maxDifficulty, false);
				int difficultyAllStars = instance.GetDifficultyAllStars(maxDifficulty, false);
				instanceDungeonCostTip.SetHelpButtonVisible(false);
				instanceDungeonCostTip.SetLeftText(ConfigMultiTextLang.GetLocalTextNew("TowerScore", null) ?? "");
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(difficultyMaxStars);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(difficultyAllStars);
				instanceDungeonCostTip.SetRightText(defaultInterpolatedStringHandler.ToStringAndClear());
				instanceDungeonCostTip.SetStarVisible(true);
			}
		}

		// Token: 0x0603294E RID: 207182 RVA: 0x00CAAA63 File Offset: 0x00CA8C63
		protected override void OnCloseWorldMapSecondaryUi()
		{
			TipsListView instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView != null)
			{
				instanceCostTipView.Clear();
			}
			this.ClearTimer();
		}

		// Token: 0x0603294F RID: 207183 RVA: 0x00CAAA7C File Offset: 0x00CA8C7C
		private void ClearTimer()
		{
			if (this.TimerId != null && TimerSystem.Instance.Has(this.TimerId))
			{
				TimerSystem.Instance.Remove(this.TimerId);
				this.TimerId = null;
			}
		}

		// Token: 0x06032950 RID: 207184 RVA: 0x00CAAAB0 File Offset: 0x00CA8CB0
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

		// Token: 0x0401D7C0 RID: 120768
		private const int REWARD_ID = 3331;

		// Token: 0x0401D7C1 RID: 120769
		private const string TIME_KEY = "time";

		// Token: 0x0401D7C2 RID: 120770
		private const string DIFFICULT_KEY = "difficult";

		// Token: 0x0401D7C3 RID: 120771
		private const string SCORE_KEY = "score";

		// Token: 0x0401D7C4 RID: 120772
		[Nullable(2)]
		private TipsListView InstanceCostTipView;

		// Token: 0x0401D7C5 RID: 120773
		[Nullable(2)]
		protected RewardItemBar RewardsView;

		// Token: 0x0401D7C6 RID: 120774
		[Nullable(2)]
		private TimerHandle TimerId;

		// Token: 0x0401D7C7 RID: 120775
		private int FlowId;

		// Token: 0x0401D7C8 RID: 120776
		private double RemainingTime;

		// Token: 0x0200AC89 RID: 44169
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035A02 RID: 219650
			public const int TowerEntrancePanel = 0;
		}
	}
}
