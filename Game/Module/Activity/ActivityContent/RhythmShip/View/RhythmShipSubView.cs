using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x0200651D RID: 25885
	[NullableContext(2)]
	[Nullable(0)]
	public class RhythmShipSubView : ActivitySubViewBase
	{
		// Token: 0x17009E8D RID: 40589
		// (get) Token: 0x06040BDF RID: 265183 RVA: 0x01099ECD File Offset: 0x010980CD
		protected new RhythmShipData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as RhythmShipData;
			}
		}

		// Token: 0x06040BE0 RID: 265184 RVA: 0x01099EDC File Offset: 0x010980DC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, new Action(this.OnClickTaskBtn)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickTaskLimitBtn))
			};
		}

		// Token: 0x06040BE1 RID: 265185 RVA: 0x0109A068 File Offset: 0x01098268
		protected override UniTask OnBeforeStartAsync()
		{
			RhythmShipSubView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RhythmShipSubView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040BE2 RID: 265186 RVA: 0x0109A0AB File Offset: 0x010982AB
		protected override void OnStart()
		{
			this.RefreshTitle();
			this.RefreshDescription();
			this.RefreshRewardList();
			this.RefreshBottom();
			this.RefreshBottomTimeText();
		}

		// Token: 0x06040BE3 RID: 265187 RVA: 0x0109A0CB File Offset: 0x010982CB
		protected override void OnBeforeShow()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RhythmShipTask, base.GetItem(10), null, 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RhythmShipTimeLimitTask, base.GetItem(9), null, 0);
		}

		// Token: 0x06040BE4 RID: 265188 RVA: 0x0109A0FF File Offset: 0x010982FF
		protected override void OnBeforeHide()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RhythmShipTask, base.GetItem(10), 0);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RhythmShipTimeLimitTask, base.GetItem(9), 0);
		}

		// Token: 0x06040BE5 RID: 265189 RVA: 0x0109A131 File Offset: 0x01098331
		protected override void OnRefreshView()
		{
			base.GetText(8).SetText(ModelBase<RhythmShipModel>.Instance.GetTaskProgressString(0), true);
			base.GetText(7).SetText(ModelBase<RhythmShipModel>.Instance.GetTaskProgressString(1), true);
			this.RefreshBottom();
			this.RefreshRecommendQuestTips();
		}

		// Token: 0x06040BE6 RID: 265190 RVA: 0x0109A170 File Offset: 0x01098370
		private void RefreshTitle()
		{
			string title = this.ActivityBaseData.GetTitle();
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
			this.TitleComponent.SetTitleByText(title);
			this.RefreshTimeTitle();
		}

		// Token: 0x06040BE7 RID: 265191 RVA: 0x0109A1AC File Offset: 0x010983AC
		protected override void OnTimer(float gap)
		{
			this.RefreshTimeTitle();
			this.RefreshBottomTimeText();
		}

		// Token: 0x06040BE8 RID: 265192 RVA: 0x0109A1BC File Offset: 0x010983BC
		private void RefreshTimeTitle()
		{
			RhythmShipData activityBaseData = this.ActivityBaseData;
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(activityBaseData, null);
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			if (activityBaseData.EndShowTime != 0L && (double)activityBaseData.EndShowTime < Singleton<TimeUtil>.Instance.GetServerTime())
			{
				this.TitleComponent.SetTimeTextVisible(false);
				return;
			}
			this.TitleComponent.SetTimeTextVisible(item);
			if (item)
			{
				this.TitleComponent.SetTimeTextByText(item2);
			}
		}

		// Token: 0x06040BE9 RID: 265193 RVA: 0x0109A22C File Offset: 0x0109842C
		private void RefreshBottomTimeText()
		{
			bool uiactive = this.ActivityBaseData.CheckIfInLimitTime();
			base.GetItem(11).SetUIActive(uiactive);
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityBaseData.EndRewardTime, "{0}");
			base.GetText(13).SetText(remainTimeText ?? "", true);
		}

		// Token: 0x06040BEA RID: 265194 RVA: 0x0109A288 File Offset: 0x01098488
		private void RefreshDescription()
		{
			Activity? localConfig = this.ActivityBaseData.LocalConfig;
			string descTheme = localConfig.Value.DescTheme;
			string desc = localConfig.Value.Desc;
			bool flag = !StringUtils.IsEmpty(descTheme);
			this.TitleComponent.SetSubTitleVisible(flag);
			if (flag)
			{
				this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
			}
			this.DescriptionComponent.SetContentByTextId(desc, Array.Empty<string>());
		}

		// Token: 0x06040BEB RID: 265195 RVA: 0x0109A300 File Offset: 0x01098500
		private void RefreshRewardList()
		{
			List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
			this.RewardListComponent.SetTitleByTextId("CollectActivity_reward");
			this.RewardListComponent.RefreshItemLayout(previewReward, null);
		}

		// Token: 0x06040BEC RID: 265196 RVA: 0x0109A340 File Offset: 0x01098540
		private void RefreshBottom()
		{
			RhythmShipData activityBaseData = this.ActivityBaseData;
			bool flag = activityBaseData.IsUnLock();
			ActivityFunctionAreaParams activityFunctionAreaParams = new ActivityFunctionAreaParams
			{
				UnlockBtnTextId = "LongShanStage_Join01",
				UnlockBtnFunction = new Action(this.OnGotoBtnClick)
			};
			if (!flag)
			{
				this.BottomComponent.RefreshGeneralPerformance(activityFunctionAreaParams);
				return;
			}
			this.BottomComponent.SetGeneralUnlockPerformance(activityFunctionAreaParams);
			this.BottomComponent.SetPanelConditionVisible(!flag);
			this.BottomComponent.FunctionButton.SetUiActive(flag);
			this.BottomComponent.SetFunctionRedDotVisible(activityBaseData.GetGotoRhythmShipBtnRedDotActive());
		}

		// Token: 0x06040BED RID: 265197 RVA: 0x0109A3CC File Offset: 0x010985CC
		private void OnGotoBtnClick()
		{
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			RhythmShipChoseLevelViewData param = new RhythmShipChoseLevelViewData
			{
				OpenShowType = ERhythmShipPlanetType.Normal
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipChoseLevelView, param, null);
		}

		// Token: 0x06040BEE RID: 265198 RVA: 0x0109A427 File Offset: 0x01098627
		private void OnClickTaskBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipTaskView, null, null);
		}

		// Token: 0x06040BEF RID: 265199 RVA: 0x0109A43A File Offset: 0x0109863A
		private void OnClickTaskLimitBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipLimitTaskView, null, null);
		}

		// Token: 0x06040BF0 RID: 265200 RVA: 0x0109A450 File Offset: 0x01098650
		private void OnRecommendBtnClick()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DirectTrainRecommendQuest);
			Action value = delegate()
			{
				int recommendQuestId = this.ActivityBaseData.GetRecommendQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, recommendQuestId, null);
			};
			confirmBoxDataNew.FunctionMap.Add(2, value);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06040BF1 RID: 265201 RVA: 0x0109A490 File Offset: 0x01098690
		private void RefreshRecommendQuestTips()
		{
			bool flag = !this.ActivityBaseData.IsRecommendQuestFinish();
			this.RecommendQuestTipsSubPanel.SetUiActive(flag);
			if (flag)
			{
				this.RecommendQuestTipsSubPanel.SetTipsTxtByTextId(this.ActivityBaseData.GetRecommendQuestIdTips(), Array.Empty<string>());
			}
		}

		// Token: 0x040244DC RID: 148700
		private ActivityTitleTypeA TitleComponent;

		// Token: 0x040244DD RID: 148701
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x040244DE RID: 148702
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x040244DF RID: 148703
		private ActivityFunctionalTypeA BottomComponent;

		// Token: 0x040244E0 RID: 148704
		private RecommendQuestTipsSubPanel RecommendQuestTipsSubPanel;
	}
}
