using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View
{
	// Token: 0x02006592 RID: 26002
	[NullableContext(2)]
	[Nullable(0)]
	public class PinballActivitySubView : ActivitySubViewBase
	{
		// Token: 0x17009EBB RID: 40635
		// (get) Token: 0x06040F83 RID: 266115 RVA: 0x010AB637 File Offset: 0x010A9837
		protected new PinballActivityData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as PinballActivityData;
			}
		}

		// Token: 0x06040F84 RID: 266116 RVA: 0x010AB644 File Offset: 0x010A9844
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040F85 RID: 266117 RVA: 0x010AB754 File Offset: 0x010A9954
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
			Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChangeHandler));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnQuestRedDotStateChange, new Action<int>(this.OnQuestRedDotStateChange));
		}

		// Token: 0x06040F86 RID: 266118 RVA: 0x010AB7B8 File Offset: 0x010A99B8
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChangeHandler));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnQuestRedDotStateChange, new Action<int>(this.OnQuestRedDotStateChange));
		}

		// Token: 0x06040F87 RID: 266119 RVA: 0x010AB819 File Offset: 0x010A9A19
		private void OnQuestStateChangeHandler(int questId, QuestState state, EQuestStatusUpdateReason reason)
		{
			this.OnQuestStateChange(questId);
		}

		// Token: 0x06040F88 RID: 266120 RVA: 0x010AB824 File Offset: 0x010A9A24
		private bool IsPinballRelatedQuest(int questId)
		{
			PinballActivityData activityBaseData = this.ActivityBaseData;
			if (activityBaseData == null)
			{
				return false;
			}
			if (activityBaseData.GetRecommendTaskId() == questId)
			{
				return true;
			}
			List<int> preGuideQuestIds = activityBaseData.GetPreGuideQuestIds();
			if (preGuideQuestIds != null)
			{
				using (List<int>.Enumerator enumerator = preGuideQuestIds.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current == questId)
						{
							return true;
						}
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x06040F89 RID: 266121 RVA: 0x010AB898 File Offset: 0x010A9A98
		private void OnQuestStateChange(int questId)
		{
			if (this.IsPinballRelatedQuest(questId))
			{
				base.RefreshView();
			}
		}

		// Token: 0x06040F8A RID: 266122 RVA: 0x010AB8A9 File Offset: 0x010A9AA9
		private void OnQuestRedDotStateChange(int questId)
		{
			if (questId == 0 || this.IsPinballRelatedQuest(questId))
			{
				this.RefreshRedDot();
			}
		}

		// Token: 0x06040F8B RID: 266123 RVA: 0x010AB8C0 File Offset: 0x010A9AC0
		protected override UniTask OnBeforeStartAsync()
		{
			PinballActivitySubView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballActivitySubView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040F8C RID: 266124 RVA: 0x010AB904 File Offset: 0x010A9B04
		private void OnRefreshRedDot(int activityId)
		{
			PinballActivityData activityBaseData = this.ActivityBaseData;
			int? num = (activityBaseData != null) ? new int?(activityBaseData.Id) : null;
			if (activityId == num.GetValueOrDefault() & num != null)
			{
				this.RefreshRewardButtons();
			}
		}

		// Token: 0x06040F8D RID: 266125 RVA: 0x010AB94B File Offset: 0x010A9B4B
		protected override void OnRefreshView()
		{
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel != null)
			{
				commonInfoPanel.OnRefreshView();
			}
			this.RefreshCondition();
			this.RefreshRewardButtons();
			this.RefreshRecommendTaskTips();
		}

		// Token: 0x06040F8E RID: 266126 RVA: 0x010AB970 File Offset: 0x010A9B70
		private void RefreshCondition()
		{
			ActivityFunctionalTypeA functional = this.CommonInfoPanel.GetFunctional();
			ActivityFunctionAreaParams parameters = new ActivityFunctionAreaParams
			{
				UnlockBtnTextId = "LongShanStage_Join01",
				UnlockBtnFunction = new Action(this.OnConfirmBtnClick)
			};
			functional.RefreshGeneralPerformance(parameters);
			if (functional == null)
			{
				return;
			}
			ActivityButtonItem functionButton = functional.FunctionButton;
			if (functionButton == null)
			{
				return;
			}
			functionButton.SetButtonAllowEventBubbleUp(true);
		}

		// Token: 0x06040F8F RID: 266127 RVA: 0x010AB9C7 File Offset: 0x010A9BC7
		protected override void OnTimer(float gap)
		{
			this.RefreshTimeLimitRewardButtonText();
		}

		// Token: 0x06040F90 RID: 266128 RVA: 0x010AB9CF File Offset: 0x010A9BCF
		private void RefreshRewardButtons()
		{
			this.RefreshTimeLimitRewardButtonText();
			this.RefreshPermanentRewardButtonText();
			this.RefreshRedDot();
		}

		// Token: 0x06040F91 RID: 266129 RVA: 0x010AB9E4 File Offset: 0x010A9BE4
		private void RefreshTimeLimitRewardButtonText()
		{
			bool flag = this.ActivityBaseData.CheckIfInRewardTime();
			ButtonItem timeLimitRewardButton = this.TimeLimitRewardButton;
			if (timeLimitRewardButton != null)
			{
				timeLimitRewardButton.SetUiActive(flag);
			}
			if (!flag)
			{
				return;
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Pinball_Main_LimitedRewardTime", null);
			if (localTextNew == null)
			{
				return;
			}
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityBaseData.EndRewardTime, localTextNew);
			ButtonItem timeLimitRewardButton2 = this.TimeLimitRewardButton;
			if (timeLimitRewardButton2 == null)
			{
				return;
			}
			timeLimitRewardButton2.SetText(remainTimeText ?? "");
		}

		// Token: 0x06040F92 RID: 266130 RVA: 0x010ABA54 File Offset: 0x010A9C54
		private void RefreshPermanentRewardButtonText()
		{
			ValueTuple<int, int> permanentTaskProgress = this.ActivityBaseData.GetPermanentTaskProgress();
			int item = permanentTaskProgress.Item1;
			int item2 = permanentTaskProgress.Item2;
			ButtonItem permanentRewardButton = this.PermanentRewardButton;
			if (permanentRewardButton == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(item);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
			permanentRewardButton.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06040F93 RID: 266131 RVA: 0x010ABAB8 File Offset: 0x010A9CB8
		private void RefreshRedDot()
		{
			PinballActivityData activityBaseData = this.ActivityBaseData;
			bool redDotVisible = false;
			if (activityBaseData.CheckIfInRewardTime())
			{
				using (List<PinballTaskData>.Enumerator enumerator = activityBaseData.GetTimeLimitTaskList().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.IsUnclaimed)
						{
							redDotVisible = true;
							break;
						}
					}
				}
			}
			bool redDotVisible2 = false;
			using (List<PinballTaskData>.Enumerator enumerator = activityBaseData.GetPermanentTaskList().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnclaimed)
					{
						redDotVisible2 = true;
						break;
					}
				}
			}
			ButtonItem timeLimitRewardButton = this.TimeLimitRewardButton;
			if (timeLimitRewardButton != null)
			{
				timeLimitRewardButton.SetRedDotVisible(redDotVisible);
			}
			ButtonItem permanentRewardButton = this.PermanentRewardButton;
			if (permanentRewardButton != null)
			{
				permanentRewardButton.SetRedDotVisible(redDotVisible2);
			}
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel == null)
			{
				return;
			}
			commonInfoPanel.SetFunctionRedDotVisible(activityBaseData.IsMainHubEntranceHasRedDot());
		}

		// Token: 0x06040F94 RID: 266132 RVA: 0x010ABBA0 File Offset: 0x010A9DA0
		private void OnConfirmBtnClick()
		{
			if (this.ActivityBaseData == null)
			{
				return;
			}
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				if (unFinishPreGuideQuestId > 0)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
				}
				return;
			}
			ControllerBase<PinballController>.Instance.OpenMainRootView(null).Forget<bool>();
		}

		// Token: 0x06040F95 RID: 266133 RVA: 0x010ABBFA File Offset: 0x010A9DFA
		private void OnTimeLimitRewardButtonClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballLimitedRewardView, this.ActivityBaseData, null);
		}

		// Token: 0x06040F96 RID: 266134 RVA: 0x010ABC12 File Offset: 0x010A9E12
		private void OnPermanentRewardButtonClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballPermanentRewardView, this.ActivityBaseData, null);
		}

		// Token: 0x06040F97 RID: 266135 RVA: 0x010ABC2C File Offset: 0x010A9E2C
		private void OnRecommendTaskBtnClick()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DirectTrainRecommendQuest);
			Action value = delegate()
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.ActivityBaseData.GetRecommendTaskId(), null);
			};
			confirmBoxDataNew.FunctionMap[2] = value;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06040F98 RID: 266136 RVA: 0x010ABC6C File Offset: 0x010A9E6C
		private void RefreshRecommendTaskTips()
		{
			if (this.RecommendQuestTipsSubPanel == null)
			{
				return;
			}
			PinballActivityData activityBaseData = this.ActivityBaseData;
			if (activityBaseData.GetRecommendTaskId() == 0)
			{
				this.RecommendQuestTipsSubPanel.SetUiActive(false);
				return;
			}
			bool flag = !activityBaseData.IsRecommendTaskFinished();
			this.RecommendQuestTipsSubPanel.SetUiActive(flag);
			if (flag)
			{
				string recommendTaskDisplayName = activityBaseData.GetRecommendTaskDisplayName();
				string recommendTaskTips = activityBaseData.GetRecommendTaskTips();
				if (StringUtils.IsEmpty(recommendTaskTips))
				{
					this.RecommendQuestTipsSubPanel.SetTipsTxt(recommendTaskDisplayName);
					return;
				}
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(recommendTaskTips, null);
				string tipsTxt = StringUtils.IsEmpty(localTextNew) ? recommendTaskDisplayName : StringUtils.Format(localTextNew, new string[]
				{
					recommendTaskDisplayName
				});
				this.RecommendQuestTipsSubPanel.SetTipsTxt(tipsTxt);
			}
		}

		// Token: 0x0402470E RID: 149262
		protected ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x0402470F RID: 149263
		private ButtonItem TimeLimitRewardButton;

		// Token: 0x04024710 RID: 149264
		private ButtonItem PermanentRewardButton;

		// Token: 0x04024711 RID: 149265
		private RecommendQuestTipsSubPanel RecommendQuestTipsSubPanel;

		// Token: 0x0200C57E RID: 50558
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403CC7B RID: 248955
			CommonActionInfo,
			// Token: 0x0403CC7C RID: 248956
			LimitRewardButton,
			// Token: 0x0403CC7D RID: 248957
			RewardButton,
			// Token: 0x0403CC7E RID: 248958
			TexPlanetBehind,
			// Token: 0x0403CC7F RID: 248959
			TexPlanetMiddle,
			// Token: 0x0403CC80 RID: 248960
			TexPlanetFront,
			// Token: 0x0403CC81 RID: 248961
			QuestTips
		}
	}
}
