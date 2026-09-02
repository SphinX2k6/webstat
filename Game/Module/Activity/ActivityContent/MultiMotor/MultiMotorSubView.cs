using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006666 RID: 26214
	[NullableContext(2)]
	[Nullable(0)]
	public class MultiMotorSubView : ActivitySubViewBase
	{
		// Token: 0x0604175F RID: 268127 RVA: 0x010CD3B0 File Offset: 0x010CB5B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
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
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnReward));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041760 RID: 268128 RVA: 0x010CD5A4 File Offset: 0x010CB7A4
		protected override UniTask OnBeforeStartAsync()
		{
			MultiMotorSubView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MultiMotorSubView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041761 RID: 268129 RVA: 0x010CD5E7 File Offset: 0x010CB7E7
		protected override void OnStart()
		{
		}

		// Token: 0x06041762 RID: 268130 RVA: 0x010CD5EC File Offset: 0x010CB7EC
		protected override void OnRefreshView()
		{
			Activity? localConfig = this.ActivityBaseData.LocalConfig;
			if (localConfig == null)
			{
				return;
			}
			this.RefreshDesc();
			this.RefreshTitle();
			this.RefreshReward();
			this.RefreshFunctionalComponent();
			this.RefreshState();
			this.RefreshRewardRedDot();
			this.RefreshLevelCount();
			this.RefreshRecommendQuestTips();
			this.RefreshRewardText();
		}

		// Token: 0x06041763 RID: 268131 RVA: 0x010CD648 File Offset: 0x010CB848
		private void RefreshRecommendQuestTips()
		{
			bool flag = this.IsShowPreOpenTips();
			this.RecommendQuestTipsSubPanelInst.SetUiActive(flag);
			if (flag)
			{
				string stringConfig = ConfigCommonParamById.GetStringConfig("MultiMotorPreQuestTips");
				this.RecommendQuestTipsSubPanelInst.SetTipsTxtByTextId(stringConfig, Array.Empty<string>());
			}
		}

		// Token: 0x06041764 RID: 268132 RVA: 0x010CD688 File Offset: 0x010CB888
		private bool IsShowPreOpenTips()
		{
			int num = this.ActivityBaseData.IsUnLock() ? 1 : 0;
			bool flag = this.ActivityBaseData.CanPreOpen();
			return num == 0 && flag;
		}

		// Token: 0x06041765 RID: 268133 RVA: 0x010CD6B4 File Offset: 0x010CB8B4
		private void RefreshLevelCount()
		{
			MultiMotorData multiMotorData = this.ActivityBaseData as MultiMotorData;
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetText(multiMotorData.FinishedLevelCount.ToString(), true);
			}
			UUIText text2 = base.GetText(6);
			if (text2 == null)
			{
				return;
			}
			text2.SetText("/" + multiMotorData.TotalLevelCount.ToString(), true);
		}

		// Token: 0x06041766 RID: 268134 RVA: 0x010CD718 File Offset: 0x010CB918
		private void RefreshRewardRedDot()
		{
			MultiMotorData multiMotorData = this.ActivityBaseData as MultiMotorData;
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(multiMotorData != null && multiMotorData.HasAnyRewardRedDot);
		}

		// Token: 0x06041767 RID: 268135 RVA: 0x010CD750 File Offset: 0x010CB950
		private void RefreshRewardText()
		{
			MultiMotorData multiMotorData = this.ActivityBaseData as MultiMotorData;
			Dictionary<int, MultiMotorTaskData> dictionary = (multiMotorData != null) ? multiMotorData.TaskDataMap : null;
			int num = 0;
			int num2 = 0;
			if (dictionary != null)
			{
				foreach (KeyValuePair<int, MultiMotorTaskData> keyValuePair in dictionary)
				{
					num++;
					if (keyValuePair.Value.IsReceived)
					{
						num2++;
					}
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "MultRacing_RewardCollectedlAmount", new <>z__ReadOnlySingleElementList<object>(num2.ToString()));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "MultRacing_RewardTotalAmount", new <>z__ReadOnlySingleElementList<object>(num.ToString()));
		}

		// Token: 0x06041768 RID: 268136 RVA: 0x010CD814 File Offset: 0x010CBA14
		private void RefreshDesc()
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

		// Token: 0x06041769 RID: 268137 RVA: 0x010CD88C File Offset: 0x010CBA8C
		private void RefreshTitle()
		{
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
			this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			this.TitleComponent.SetTimeTextVisible(item);
			if (item)
			{
				this.TitleComponent.SetTimeTextByText(item2);
			}
		}

		// Token: 0x0604176A RID: 268138 RVA: 0x010CD8F0 File Offset: 0x010CBAF0
		private void RefreshReward()
		{
			List<TItem> previewReward = this.ActivityBaseData.GetPreviewReward(null);
			this.RewardListComponent.SetTitleByTextId("BossRushCollectReward");
			this.RewardListComponent.RefreshItemLayout(previewReward, null);
		}

		// Token: 0x0604176B RID: 268139 RVA: 0x010CD930 File Offset: 0x010CBB30
		private void RefreshFunctionalComponent()
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("BossRushEnterText", null);
			this.FunctionalComponent.FunctionButton.SetText(localTextNew);
			MultiMotorData multiMotorData = this.ActivityBaseData as MultiMotorData;
			ActivityBaseData activityBaseData = this.ActivityBaseData;
			bool flag = activityBaseData != null && activityBaseData.GetPreGuideQuestFinishState();
			this.FunctionalComponent.SetFunctionRedDotVisible(flag && (multiMotorData.HasAnyLevelRedDot || multiMotorData.HasAnyRewardRedDot));
		}

		// Token: 0x0604176C RID: 268140 RVA: 0x010CD99B File Offset: 0x010CBB9B
		protected override void OnTimer(float gap)
		{
			base.OnTimer(gap);
			this.RefreshTitle();
		}

		// Token: 0x0604176D RID: 268141 RVA: 0x010CD9AC File Offset: 0x010CBBAC
		private void FunctionExecute()
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti && !ModelBase<OnlineModel>.Instance.GetIsMyTeam())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MultiMotorOnlineDisable", Array.Empty<object>());
				return;
			}
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MultiMotorChoseLevelView, null, null);
		}

		// Token: 0x0604176E RID: 268142 RVA: 0x010CDA28 File Offset: 0x010CBC28
		private void OnClickBtnReward()
		{
			MultiMotorData multiMotorData = this.ActivityBaseData as MultiMotorData;
			List<MultiMotorLevelData> levelDataList = multiMotorData.GetLevelDataList();
			if (levelDataList.Count > 0)
			{
				IMultiMotorParkourRewardViewData param = new IMultiMotorParkourRewardViewData
				{
					ActivityData = multiMotorData,
					SelectLevelData = levelDataList[0]
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MultiMotorRewardView, param, null);
			}
		}

		// Token: 0x0604176F RID: 268143 RVA: 0x010CDA7C File Offset: 0x010CBC7C
		private void RefreshState()
		{
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			bool flag = this.ActivityBaseData.IsUnLock();
			this.FunctionalComponent.SetPanelConditionVisible(!flag);
			this.FunctionalComponent.FunctionButton.SetUiActive(flag);
			if (!flag)
			{
				this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
			}
			base.GetButton(4).RootUIComp.Get().SetUIActive(flag);
			UUIItem item2 = base.GetItem(11);
			if (item2 != null)
			{
				item2.SetUIActive(flag);
			}
			UUIText text = base.GetText(6);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(flag);
		}

		// Token: 0x06041770 RID: 268144 RVA: 0x010CDB2C File Offset: 0x010CBD2C
		private void OnRecommendBtnClick()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("MultiMotorPreQuestId");
			if (ModelBase<QuestNewModel>.Instance.GetQuest(intConfig.Value) == null)
			{
				string stringConfig = ConfigCommonParamById.GetStringConfig("MultiMotorPreQuestTips");
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(stringConfig, Array.Empty<object>());
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, intConfig, null);
		}

		// Token: 0x04024997 RID: 149911
		private ActivityTitleTypeA TitleComponent;

		// Token: 0x04024998 RID: 149912
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x04024999 RID: 149913
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;

		// Token: 0x0402499A RID: 149914
		private ActivityFunctionalTypeA FunctionalComponent;

		// Token: 0x0402499B RID: 149915
		private RecommendQuestTipsSubPanel RecommendQuestTipsSubPanelInst;

		// Token: 0x0200C68E RID: 50830
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D237 RID: 250423
			public const int TitleItem = 0;

			// Token: 0x0403D238 RID: 250424
			public const int DescItem = 1;

			// Token: 0x0403D239 RID: 250425
			public const int RewardItem = 2;

			// Token: 0x0403D23A RID: 250426
			public const int FunctionalAreaItem = 3;

			// Token: 0x0403D23B RID: 250427
			public const int RewardBtn = 4;

			// Token: 0x0403D23C RID: 250428
			public const int FinishLevelText = 5;

			// Token: 0x0403D23D RID: 250429
			public const int MaxLevelText = 6;

			// Token: 0x0403D23E RID: 250430
			public const int RewardRedDotItem = 7;

			// Token: 0x0403D23F RID: 250431
			public const int PreOpenTipsItem = 8;

			// Token: 0x0403D240 RID: 250432
			public const int RewardBtnText1 = 9;

			// Token: 0x0403D241 RID: 250433
			public const int RewardBtnText2 = 10;

			// Token: 0x0403D242 RID: 250434
			public const int FinishLevelItem = 11;
		}
	}
}
