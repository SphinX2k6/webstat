using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Morale.Data;
using CSharpScript.Game.Module.WorldMap.SubViews.SceneGameplayPanel;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.CommonGamePlay
{
	// Token: 0x02004BD6 RID: 19414
	[NullableContext(2)]
	[Nullable(0)]
	public class CommonGamePlayPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x17008704 RID: 34564
		// (get) Token: 0x06032A92 RID: 207506 RVA: 0x00CB02BF File Offset: 0x00CAE4BF
		// (set) Token: 0x06032A93 RID: 207507 RVA: 0x00CB02C7 File Offset: 0x00CAE4C7
		public MapMoraleLvItem MapMoraleLvItem { get; set; }

		// Token: 0x17008705 RID: 34565
		// (get) Token: 0x06032A94 RID: 207508 RVA: 0x00CB02D0 File Offset: 0x00CAE4D0
		// (set) Token: 0x06032A95 RID: 207509 RVA: 0x00CB02D8 File Offset: 0x00CAE4D8
		public MapMoraleWarnItem MapMoraleWarnItem { get; set; }

		// Token: 0x17008706 RID: 34566
		// (get) Token: 0x06032A96 RID: 207510 RVA: 0x00CB02E1 File Offset: 0x00CAE4E1
		// (set) Token: 0x06032A97 RID: 207511 RVA: 0x00CB02E9 File Offset: 0x00CAE4E9
		public RewardItemBar RewardsView { get; set; }

		// Token: 0x06032A98 RID: 207512 RVA: 0x00CB02F2 File Offset: 0x00CAE4F2
		[NullableContext(1)]
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x06032A99 RID: 207513 RVA: 0x00CB02FC File Offset: 0x00CAE4FC
		[NullableContext(1)]
		protected override UniTask OnBeforeShowWorldMapSecondaryUiAsync(params object[] param)
		{
			CommonGamePlayPanel.<OnBeforeShowWorldMapSecondaryUiAsync>d__19 <OnBeforeShowWorldMapSecondaryUiAsync>d__;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>4__this = this;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.param = param;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>1__state = -1;
			<OnBeforeShowWorldMapSecondaryUiAsync>d__.<>t__builder.Start<CommonGamePlayPanel.<OnBeforeShowWorldMapSecondaryUiAsync>d__19>(ref <OnBeforeShowWorldMapSecondaryUiAsync>d__);
			return <OnBeforeShowWorldMapSecondaryUiAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032A9A RID: 207514 RVA: 0x00CB0347 File Offset: 0x00CAE547
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(14);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			this.SetPanelItemLayoutActive(false);
		}

		// Token: 0x06032A9B RID: 207515 RVA: 0x00CB0380 File Offset: 0x00CAE580
		private void SetPanelItemLayoutActive(bool active)
		{
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(7);
			if (verticalLayout == null)
			{
				return;
			}
			verticalLayout.RootUIComp.Get().SetUIActive(active);
		}

		// Token: 0x06032A9C RID: 207516 RVA: 0x00CB03AC File Offset: 0x00CAE5AC
		[NullableContext(1)]
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				ConfigMarkItem configMarkItem = param[0] as ConfigMarkItem;
				if (configMarkItem != null)
				{
					this.LayoutContext.MarkItem = configMarkItem;
					this.UpdateEnableFastMoveLayout();
					base.UpdateMultiMap();
					WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateDesc(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateDownStateIcon(this.LayoutContext);
					base.UpdateTopRightIconActive();
					if (!base.UpdateDeliveryPropLayout())
					{
						this.UpdateMoraleFlagReward(configMarkItem);
					}
					MapMark? markConfig = configMarkItem.MarkConfig;
					if (markConfig.Value.RelativeType == 1)
					{
						this.RefreshRewardItemBar(configMarkItem);
					}
				}
			}
		}

		// Token: 0x06032A9D RID: 207517 RVA: 0x00CB0460 File Offset: 0x00CAE660
		[NullableContext(1)]
		public void UpdateMoraleFlagReward(ConfigMarkItem markItem)
		{
			if (!markItem.IsMoraleFlag())
			{
				return;
			}
			MoraleAreaFlagData flagDataByMarkId = ModelBase<MoraleModel>.Instance.GetFlagDataByMarkId(markItem.MarkId);
			if (flagDataByMarkId == null)
			{
				return;
			}
			int boxRewardId = flagDataByMarkId.Config.BoxRewardId;
			if (boxRewardId <= 0)
			{
				return;
			}
			this.SetPanelItemLayoutActive(true);
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			RewardItemBar rewardsView = this.RewardsView;
			if (rewardsView != null)
			{
				rewardsView.RebuildRewardsByData(base.GetItemListByDropId(boxRewardId));
			}
			RewardItemBar rewardsView2 = this.RewardsView;
			if (rewardsView2 == null)
			{
				return;
			}
			rewardsView2.SetTitleNewTxt("Morale_title_18");
		}

		// Token: 0x06032A9E RID: 207518 RVA: 0x00CB04E4 File Offset: 0x00CAE6E4
		[NullableContext(0)]
		private UniTask<bool> UpdateMoraleItem([Nullable(1)] ConfigMarkItem markItem)
		{
			CommonGamePlayPanel.<UpdateMoraleItem>d__24 <UpdateMoraleItem>d__;
			<UpdateMoraleItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UpdateMoraleItem>d__.<>4__this = this;
			<UpdateMoraleItem>d__.markItem = markItem;
			<UpdateMoraleItem>d__.<>1__state = -1;
			<UpdateMoraleItem>d__.<>t__builder.Start<CommonGamePlayPanel.<UpdateMoraleItem>d__24>(ref <UpdateMoraleItem>d__);
			return <UpdateMoraleItem>d__.<>t__builder.Task;
		}

		// Token: 0x06032A9F RID: 207519 RVA: 0x00CB0530 File Offset: 0x00CAE730
		private void SetMoraleItemHide()
		{
			WorldMapSecondaryUiLayoutHelper.SetTitleUseChangeColor(this.LayoutContext, false);
			UUIItem item = base.GetItem(45);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			MapMoraleLvItem mapMoraleLvItem = this.MapMoraleLvItem;
			if (mapMoraleLvItem != null)
			{
				mapMoraleLvItem.SetActive(false);
			}
			MapMoraleWarnItem mapMoraleWarnItem = this.MapMoraleWarnItem;
			if (mapMoraleWarnItem != null)
			{
				mapMoraleWarnItem.SetActive(false);
			}
			PopupTypeRightItem uiBgItem = this.UiBgItem;
			if (uiBgItem == null)
			{
				return;
			}
			uiBgItem.ShowMoraleBg(false);
		}

		// Token: 0x06032AA0 RID: 207520 RVA: 0x00CB0592 File Offset: 0x00CAE792
		private void SetNightMareItemHide()
		{
			SceneGameplayTipGrid rewardGrid = this.RewardGrid;
			if (rewardGrid != null)
			{
				rewardGrid.SetUiActive(false);
			}
			SceneGameplayTipGrid firstRewardGrid = this.FirstRewardGrid;
			if (firstRewardGrid != null)
			{
				firstRewardGrid.SetUiActive(false);
			}
			this.SetPanelItemLayoutActive(false);
		}

		// Token: 0x06032AA1 RID: 207521 RVA: 0x00CB05C0 File Offset: 0x00CAE7C0
		[NullableContext(1)]
		private bool UpdateNightMareItem(ConfigMarkItem markItem)
		{
			if (!markItem.IsNightMareFlag() && !markItem.IsVisionSettlementFlag())
			{
				return false;
			}
			this.LevelPlayInfo = ModelBase<LevelPlayModel>.Instance.GetLevelPlayInfo((markItem != null) ? markItem.MarkConfig.Value.RelativeId : 0);
			if (this.LevelPlayInfo == null)
			{
				this.LevelPlayInfo = new LevelPlayInfo((markItem != null) ? markItem.MarkConfig.Value.RelativeId : 0);
				this.LevelPlayInfo.InitConfig();
			}
			this.InitNightMareRewards(markItem);
			return true;
		}

		// Token: 0x06032AA2 RID: 207522 RVA: 0x00CB0648 File Offset: 0x00CAE848
		[NullableContext(1)]
		public void InitNightMareRewards(ConfigMarkItem markItem)
		{
			ValueTuple<bool, int, int, string, string> doubleRestAndMaxTimes = MapHelper.GetDoubleRestAndMaxTimes(markItem);
			bool item = doubleRestAndMaxTimes.Item1;
			int item2 = doubleRestAndMaxTimes.Item2;
			int item3 = doubleRestAndMaxTimes.Item3;
			string item4 = doubleRestAndMaxTimes.Item4;
			string item5 = doubleRestAndMaxTimes.Item5;
			if (item)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(20), item4, new <>z__ReadOnlyArray<object>(new object[]
				{
					item2,
					item3
				}));
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(42), item5, Array.Empty<object>());
				UUIText text = base.GetText(42);
				if (text != null)
				{
					text.SetUIActive(item);
				}
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(42), "Double_reward_tips_02", Array.Empty<object>());
			}
			UUIItem item6 = base.GetItem(19);
			if (item6 != null)
			{
				item6.SetUIActive(item);
			}
			if (this.RewardGrid == null)
			{
				AActor owner = base.GetItem(8).GetOwner();
				TWeakObjectPtr<UUIItem> rootUIComp = base.GetVerticalLayout(7).RootUIComp;
				this.FirstRewardGrid = new SceneGameplayTipGrid();
				this.FirstRewardGrid.Initialize(Singleton<LguiUtil>.Instance.DuplicateActor(owner, rootUIComp));
				this.RewardGrid = new SceneGameplayTipGrid();
				this.RewardGrid.Initialize(Singleton<LguiUtil>.Instance.DuplicateActor(owner, rootUIComp));
			}
			SceneGameplayTipGrid firstRewardGrid = this.FirstRewardGrid;
			if (firstRewardGrid != null)
			{
				firstRewardGrid.SetBtnPreviewVisible(false);
			}
			ExchangeReward? rewardConfig;
			if (markItem != null)
			{
				int reward = markItem.MarkConfig.Value.Reward;
				rewardConfig = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardConfig(new int?(markItem.MarkConfig.Value.Reward));
			}
			else
			{
				rewardConfig = null;
			}
			this.RewardConfig = rewardConfig;
			LevelPlayInfo levelPlayInfo = this.LevelPlayInfo;
			bool flag;
			if (levelPlayInfo == null)
			{
				flag = false;
			}
			else
			{
				int firstRewardId = levelPlayInfo.FirstRewardId;
				flag = true;
			}
			this.FirstRewardConfig = (flag ? ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardConfig(new int?(this.LevelPlayInfo.FirstRewardId)) : null);
			LevelPlayInfo levelPlayInfo2 = this.LevelPlayInfo;
			if (levelPlayInfo2 != null && levelPlayInfo2.IsFirstPass)
			{
				this.UpdateNightMareReward(this.FirstRewardGrid, null, "", false);
			}
			else
			{
				this.UpdateNightMareReward(this.FirstRewardGrid, this.FirstRewardConfig, "FirstReward", false);
			}
			this.UpdateNightMareReward(this.RewardGrid, this.RewardConfig, "ProbReward", item);
		}

		// Token: 0x06032AA3 RID: 207523 RVA: 0x00CB088C File Offset: 0x00CAEA8C
		[NullableContext(1)]
		private void UpdateNightMareReward([Nullable(2)] SceneGameplayTipGrid grid, ExchangeReward? rewardConfig, string title, bool showDouble = false)
		{
			if (grid == null)
			{
				return;
			}
			if (rewardConfig == null)
			{
				grid.SetUiActive(false);
				return;
			}
			Dictionary<int, int> nightMareShowReward = ConfigBase<AdventureGuideConfig>.Instance.GetNightMareShowReward(rewardConfig.Value.RewardIdCalabash());
			if (nightMareShowReward != null)
			{
				grid.Refresh(nightMareShowReward, title, false, false, showDouble);
				grid.SetUiActive(true);
			}
			else
			{
				grid.SetUiActive(false);
			}
			this.SetPanelItemLayoutActive(true);
		}

		// Token: 0x06032AA4 RID: 207524 RVA: 0x00CB08F0 File Offset: 0x00CAEAF0
		[NullableContext(0)]
		private UniTask<bool> UpdateFlagChallengeItem([Nullable(1)] ConfigMarkItem markItem)
		{
			CommonGamePlayPanel.<UpdateFlagChallengeItem>d__30 <UpdateFlagChallengeItem>d__;
			<UpdateFlagChallengeItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UpdateFlagChallengeItem>d__.<>4__this = this;
			<UpdateFlagChallengeItem>d__.markItem = markItem;
			<UpdateFlagChallengeItem>d__.<>1__state = -1;
			<UpdateFlagChallengeItem>d__.<>t__builder.Start<CommonGamePlayPanel.<UpdateFlagChallengeItem>d__30>(ref <UpdateFlagChallengeItem>d__);
			return <UpdateFlagChallengeItem>d__.<>t__builder.Task;
		}

		// Token: 0x06032AA5 RID: 207525 RVA: 0x00CB093C File Offset: 0x00CAEB3C
		public UniTask CreateRewardItemBar()
		{
			CommonGamePlayPanel.<CreateRewardItemBar>d__31 <CreateRewardItemBar>d__;
			<CreateRewardItemBar>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateRewardItemBar>d__.<>4__this = this;
			<CreateRewardItemBar>d__.<>1__state = -1;
			<CreateRewardItemBar>d__.<>t__builder.Start<CommonGamePlayPanel.<CreateRewardItemBar>d__31>(ref <CreateRewardItemBar>d__);
			return <CreateRewardItemBar>d__.<>t__builder.Task;
		}

		// Token: 0x06032AA6 RID: 207526 RVA: 0x00CB0980 File Offset: 0x00CAEB80
		[NullableContext(1)]
		private void RefreshRewardItemBar(ConfigMarkItem selectedMarkItem)
		{
			int levelPlayId = (selectedMarkItem != null) ? selectedMarkItem.MarkConfig.Value.RelativeId : 0;
			if (ModelBase<LevelPlayModel>.Instance.GetLevelPlayConfig(levelPlayId) == null)
			{
				UUIVerticalLayout verticalLayout = base.GetVerticalLayout(7);
				if (verticalLayout == null)
				{
					return;
				}
				verticalLayout.RootUIComp.Get().SetUIActive(false);
				return;
			}
			else
			{
				List<TItem> gameplayDropPreviewItemList = selectedMarkItem.MarkItemEntity.GamePlay.GameplayDropPreviewItemList;
				if (gameplayDropPreviewItemList.Count <= 0)
				{
					UUIVerticalLayout verticalLayout2 = base.GetVerticalLayout(7);
					if (verticalLayout2 == null)
					{
						return;
					}
					verticalLayout2.RootUIComp.Get().SetUIActive(false);
					return;
				}
				else
				{
					UUIVerticalLayout verticalLayout3 = base.GetVerticalLayout(7);
					if (verticalLayout3 != null)
					{
						verticalLayout3.RootUIComp.Get().SetUIActive(true);
					}
					UUIItem item = base.GetItem(8);
					if (item != null)
					{
						item.SetUIActive(true);
					}
					bool finishRecord;
					if (selectedMarkItem.MarkItemEntity.GamePlay.GameplayCompleteRewardIds.Count > 0)
					{
						finishRecord = selectedMarkItem.MarkItemEntity.GamePlay.IsFinish;
					}
					else
					{
						finishRecord = selectedMarkItem.MarkItemEntity.GamePlay.IsAllRewardReceived;
					}
					RewardItemBar rewardsView = this.RewardsView;
					if (rewardsView != null)
					{
						rewardsView.RebuildRewardsByLevelRewardData(new CommonLevelPlayPanelRewardData
						{
							FinishRecord = finishRecord,
							ItemList = gameplayDropPreviewItemList
						});
					}
					RewardItemBar rewardsView2 = this.RewardsView;
					if (rewardsView2 == null)
					{
						return;
					}
					rewardsView2.SetTitleNewTxt("GameplayMark_Reward_Text");
					return;
				}
			}
		}

		// Token: 0x06032AA7 RID: 207527 RVA: 0x00CB0ABC File Offset: 0x00CAECBC
		protected override void OnBeforeDestroy()
		{
			if (this.RewardGrid != null)
			{
				base.AddChild(this.RewardGrid);
				this.RewardGrid = null;
			}
			if (this.FirstRewardGrid != null)
			{
				base.AddChild(this.FirstRewardGrid);
				this.FirstRewardGrid = null;
			}
			this.RewardConfig = null;
			this.FirstRewardConfig = null;
			ModelBase<CalabashModel>.Instance.ClearOnlyShowData();
			base.OnBeforeDestroy();
		}

		// Token: 0x0401D81E RID: 120862
		private SceneGameplayTipGrid RewardGrid;

		// Token: 0x0401D81F RID: 120863
		private SceneGameplayTipGrid FirstRewardGrid;

		// Token: 0x0401D820 RID: 120864
		private LevelPlayInfo LevelPlayInfo;

		// Token: 0x0401D821 RID: 120865
		private ExchangeReward? RewardConfig;

		// Token: 0x0401D822 RID: 120866
		private ExchangeReward? FirstRewardConfig;

		// Token: 0x0200ACBB RID: 44219
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035A81 RID: 219777
			public const int CommonGamePlayPanel = 0;
		}
	}
}
