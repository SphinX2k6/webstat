using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.InstanceDungeonEntrancePanel
{
	// Token: 0x02004BAF RID: 19375
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerEntrancePanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x06032967 RID: 207207 RVA: 0x00CAB2A4 File Offset: 0x00CA94A4
		public override string GetResourceId()
		{
			return "UiView_Map_Tower_Tip_Prefab";
		}

		// Token: 0x06032968 RID: 207208 RVA: 0x00CAB2AC File Offset: 0x00CA94AC
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
			this.RewardsView.SetRootActor(base.GetItem(8).GetOwner(), true);
			base.OnStart();
		}

		// Token: 0x06032969 RID: 207209 RVA: 0x00CAB31F File Offset: 0x00CA951F
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

		// Token: 0x0603296A RID: 207210 RVA: 0x00CAB350 File Offset: 0x00CA9550
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				TeleportMarkItem teleportMarkItem = param[0] as TeleportMarkItem;
				if (teleportMarkItem != null)
				{
					this.LayoutContext.MarkItem = teleportMarkItem;
					this.RefreshTime();
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
				}
			}
		}

		// Token: 0x0603296B RID: 207211 RVA: 0x00CAB413 File Offset: 0x00CA9613
		private void OnSecondRefresh()
		{
			this.RefreshDifficult();
			this.RefreshTime();
		}

		// Token: 0x0603296C RID: 207212 RVA: 0x00CAB424 File Offset: 0x00CA9624
		private void RefreshDifficult()
		{
			WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
			InstanceDungeonCostTip instanceDungeonCostTip = this.InstanceCostTipView.AddItemByKey("normal");
			instanceDungeonCostTip.SetHelpButtonVisible(false);
			instanceDungeonCostTip.SetLeftText(ConfigMultiTextLang.GetLocalTextNew("WheelBattleMode_NormalProgress", null) ?? "");
			instanceDungeonCostTip.SetStarVisible(false);
			int currentRewardProgress = instance.ActivityData.GetCurrentRewardProgress(EFilterMode.Normal);
			int totalRewardProgress = instance.ActivityData.GetTotalRewardProgress(EFilterMode.Normal);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(currentRewardProgress);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(totalRewardProgress);
			instanceDungeonCostTip.SetRightText(defaultInterpolatedStringHandler.ToStringAndClear());
			InstanceDungeonCostTip instanceDungeonCostTip2 = this.InstanceCostTipView.AddItemByKey("endless");
			instanceDungeonCostTip2.SetHelpButtonVisible(false);
			instanceDungeonCostTip2.SetLeftText(ConfigMultiTextLang.GetLocalTextNew("WheelBattleMode_EndlessProgress", null) ?? "");
			instanceDungeonCostTip2.SetStarVisible(false);
			int currentRewardProgress2 = instance.ActivityData.GetCurrentRewardProgress(EFilterMode.Endless);
			int totalRewardProgress2 = instance.ActivityData.GetTotalRewardProgress(EFilterMode.Endless);
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(currentRewardProgress2);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(totalRewardProgress2);
			instanceDungeonCostTip2.SetRightText(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0603296D RID: 207213 RVA: 0x00CAB540 File Offset: 0x00CA9740
		private void RefreshTime()
		{
			CommonDefine.ICountDown seasonCountDownData = ModelBase<WheelTowerModel>.Instance.GetSeasonCountDownData();
			InstanceDungeonCostTip instanceDungeonCostTip = this.InstanceCostTipView.AddItemByKey("time");
			string leftText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("Text_ActiveRemainTime_Text", null) ?? "", new string[]
			{
				""
			});
			instanceDungeonCostTip.SetLeftText(leftText);
			instanceDungeonCostTip.SetRightText(seasonCountDownData.CountDownText ?? "");
			instanceDungeonCostTip.SetHelpButtonVisible(false);
		}

		// Token: 0x0603296E RID: 207214 RVA: 0x00CAB5B4 File Offset: 0x00CA97B4
		protected override void OnCloseWorldMapSecondaryUi()
		{
			TipsListView instanceCostTipView = this.InstanceCostTipView;
			if (instanceCostTipView != null)
			{
				instanceCostTipView.Clear();
			}
			this.ClearTimer();
		}

		// Token: 0x0603296F RID: 207215 RVA: 0x00CAB5CD File Offset: 0x00CA97CD
		private void ClearTimer()
		{
			if (this.TimerId != null && TimerSystem.Instance.Has(this.TimerId))
			{
				TimerSystem.Instance.Remove(this.TimerId);
				this.TimerId = null;
			}
		}

		// Token: 0x06032970 RID: 207216 RVA: 0x00CAB601 File Offset: 0x00CA9801
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

		// Token: 0x0401D7D0 RID: 120784
		private const string TIME_KEY = "time";

		// Token: 0x0401D7D1 RID: 120785
		private const string NORMAL_KEY = "normal";

		// Token: 0x0401D7D2 RID: 120786
		private const string ENDLESS_KEY = "endless";

		// Token: 0x0401D7D3 RID: 120787
		[Nullable(2)]
		private TipsListView InstanceCostTipView;

		// Token: 0x0401D7D4 RID: 120788
		[Nullable(2)]
		protected RewardItemBar RewardsView;

		// Token: 0x0401D7D5 RID: 120789
		[Nullable(2)]
		private TimerHandle TimerId;

		// Token: 0x0200AC8C RID: 44172
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035A08 RID: 219656
			public const int WheelTowerEntrancePanel = 0;
		}
	}
}
