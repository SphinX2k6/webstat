using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EDC RID: 20188
	[NullableContext(2)]
	[Nullable(0)]
	public class TowerDefenseSubView : ActivitySubViewBase
	{
		// Token: 0x0603424A RID: 213578 RVA: 0x00D09930 File Offset: 0x00D07B30
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603424B RID: 213579 RVA: 0x00D09A5F File Offset: 0x00D07C5F
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, new Action<IActivityRewardViewData>(this.RefreshRewardRedDot));
		}

		// Token: 0x0603424C RID: 213580 RVA: 0x00D09A7D File Offset: 0x00D07C7D
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, new Action<IActivityRewardViewData>(this.RefreshRewardRedDot));
		}

		// Token: 0x0603424D RID: 213581 RVA: 0x00D09A9C File Offset: 0x00D07C9C
		private UniTask LoadBgResource()
		{
			TowerDefenseSubView.<LoadBgResource>d__8 <LoadBgResource>d__;
			<LoadBgResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadBgResource>d__.<>4__this = this;
			<LoadBgResource>d__.<>1__state = -1;
			<LoadBgResource>d__.<>t__builder.Start<TowerDefenseSubView.<LoadBgResource>d__8>(ref <LoadBgResource>d__);
			return <LoadBgResource>d__.<>t__builder.Task;
		}

		// Token: 0x0603424E RID: 213582 RVA: 0x00D09AE0 File Offset: 0x00D07CE0
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenseSubView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenseSubView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603424F RID: 213583 RVA: 0x00D09B24 File Offset: 0x00D07D24
		protected override void OnRefreshView()
		{
			Activity? localConfig = this.ActivityBaseData.LocalConfig;
			if (localConfig == null)
			{
				return;
			}
			this.RefreshDesc();
			this.RefreshTitle();
			this.RefreshTimerText();
			this.RefreshReward();
			this.RefreshFunctionalComponent();
			this.TryShowNewUnlockTips();
			this.RefreshRewardRedDot(null);
			this.RefreshButtonRedDot();
		}

		// Token: 0x06034250 RID: 213584 RVA: 0x00D09B78 File Offset: 0x00D07D78
		protected override void OnTimer(float gap)
		{
			this.RefreshTimerText();
			this.RefreshFunctionalComponent();
		}

		// Token: 0x06034251 RID: 213585 RVA: 0x00D09B88 File Offset: 0x00D07D88
		private void TryShowNewUnlockTips()
		{
			if (ControllerBase<TowerDefenseController>.Instance.GetIsFirstOpen())
			{
				DifficultUnlockTipsData difficultUnlockTipsData = new DifficultUnlockTipsData();
				difficultUnlockTipsData.Text = "BossRushUnlockTips";
				Singleton<UiManager>.Instance.OpenView(EUiViewName.DifficultUnlockTipView, difficultUnlockTipsData, null);
			}
		}

		// Token: 0x06034252 RID: 213586 RVA: 0x00D09BC4 File Offset: 0x00D07DC4
		private void RefreshTitle()
		{
			string activitySubViewTitle = ControllerBase<TowerDefenseController>.Instance.GetActivitySubViewTitle();
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
			this.TitleComponent.SetTitleByText(activitySubViewTitle);
		}

		// Token: 0x06034253 RID: 213587 RVA: 0x00D09BFC File Offset: 0x00D07DFC
		private void RefreshTimerText()
		{
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			this.TitleComponent.SetTimeTextVisible(item);
			if (item)
			{
				this.TitleComponent.SetTimeTextByText(item2);
			}
		}

		// Token: 0x06034254 RID: 213588 RVA: 0x00D09C38 File Offset: 0x00D07E38
		private void RefreshDesc()
		{
			Activity activityCfg = ControllerBase<TowerDefenseController>.Instance.GetActivityCfg();
			string descTheme = activityCfg.DescTheme;
			string desc = activityCfg.Desc;
			bool flag = !StringUtils.IsEmpty(descTheme);
			this.DescriptionComponent.SetContentVisible(flag);
			if (flag)
			{
				this.DescriptionComponent.SetContentByTextId(descTheme, Array.Empty<string>());
			}
			this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
		}

		// Token: 0x06034255 RID: 213589 RVA: 0x00D09C9C File Offset: 0x00D07E9C
		private void RefreshReward()
		{
			List<TItem> activityPreviewReward = ControllerBase<TowerDefenseController>.Instance.GetActivityPreviewReward();
			this.RewardListComponent.SetTitleByTextId("FragmentMemoryCollectReward");
			this.RewardListComponent.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.RewardListComponent.InitCommonGridItem));
			this.RewardListComponent.RefreshItemLayout(activityPreviewReward, null);
		}

		// Token: 0x06034256 RID: 213590 RVA: 0x00D09CF0 File Offset: 0x00D07EF0
		private void RefreshFunctionalComponent()
		{
			if (!ControllerBase<TowerDefenseController>.Instance.CheckActivityUnlockByMulti())
			{
				this.FunctionalComponent.SetPanelConditionVisible(true);
				this.FunctionalComponent.SetLockTextByTextId("TowerDefence_Cantplay", Array.Empty<string>());
				this.RewardButtonItem.SetUiActive(false);
				this.FunctionalComponent.FunctionButton.SetUiActive(false);
				return;
			}
			bool flag = ControllerBase<TowerDefenseController>.Instance.CheckActivityUnlockByCondition();
			this.FunctionalComponent.SetPanelConditionVisible(!flag);
			this.FunctionalComponent.FunctionButton.SetUiActive(flag);
			if (flag)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew("BossRushEnterText", null);
				this.FunctionalComponent.FunctionButton.SetText(localTextNew);
			}
			else
			{
				this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
			}
			ValueTuple<int, int> previewRewardCount = ModelBase<TowerDefenseModel>.Instance.GetPreviewRewardCount();
			this.RewardButtonItem.SetText(previewRewardCount.Item1.ToString() + "/" + previewRewardCount.Item2.ToString());
			this.RewardButtonItem.SetUiActive(flag);
		}

		// Token: 0x06034257 RID: 213591 RVA: 0x00D09DFC File Offset: 0x00D07FFC
		private void HandleOnClickConfirm()
		{
			ModelBase<TowerDefenseModel>.Instance.IsEnterInActivityClicked = true;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityBaseData.Id);
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			TowerDefenseConfig? towerDefenseConfigByActivityId = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigByActivityId(this.ActivityBaseData.Id);
			if (towerDefenseConfigByActivityId.Value.EntranceId != 0)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(towerDefenseConfigByActivityId.Value.EntranceId, 0, null);
				return;
			}
			WorldMapViewOpenParams data = new WorldMapViewOpenParams
			{
				MarkId = new int?(ControllerBase<TowerDefenseController>.Instance.GetMarkIdByActivityId(this.ActivityBaseData.Id)),
				MarkType = EMarkType.None,
				OpenFogId = new int?(0)
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
		}

		// Token: 0x06034258 RID: 213592 RVA: 0x00D09EEA File Offset: 0x00D080EA
		[NullableContext(1)]
		private void RefreshRewardRedDot(IActivityRewardViewData activityRewardViewData = null)
		{
			this.RewardButtonItem.SetRedDotVisible(ControllerBase<TowerDefenseController>.Instance.CheckHasReward());
		}

		// Token: 0x06034259 RID: 213593 RVA: 0x00D09F01 File Offset: 0x00D08101
		private void RefreshButtonRedDot()
		{
			this.FunctionalComponent.SetFunctionRedDotVisible(ControllerBase<TowerDefenseController>.Instance.CheckHasNewStage());
		}

		// Token: 0x0401E1BC RID: 123324
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x0401E1BD RID: 123325
		private ActivityFunctionalTypeA FunctionalComponent;

		// Token: 0x0401E1BE RID: 123326
		private ActivityButtonItem RewardButtonItem;

		// Token: 0x0401E1BF RID: 123327
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x0401E1C0 RID: 123328
		private ActivityTitleTypeA TitleComponent;

		// Token: 0x0200AE8E RID: 44686
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04036324 RID: 221988
			public const int TitleItem = 0;

			// Token: 0x04036325 RID: 221989
			public const int DescItem = 1;

			// Token: 0x04036326 RID: 221990
			public const int RewardItem = 2;

			// Token: 0x04036327 RID: 221991
			public const int FunctionalAreaItem = 3;

			// Token: 0x04036328 RID: 221992
			public const int BgAttachItem = 4;

			// Token: 0x04036329 RID: 221993
			public const int RewardButtonItem = 5;

			// Token: 0x0403632A RID: 221994
			public const int TipsItem = 6;

			// Token: 0x0403632B RID: 221995
			public const int TipsText = 7;
		}
	}
}
