using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FeiXue
{
	// Token: 0x0200683F RID: 26687
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySubViewFeiXuePreheat : ActivitySubViewBase
	{
		// Token: 0x1700A192 RID: 41362
		// (get) Token: 0x0604287C RID: 272508 RVA: 0x01113900 File Offset: 0x01111B00
		protected new ActivityFeiXuePreheatData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as ActivityFeiXuePreheatData;
			}
		}

		// Token: 0x0604287D RID: 272509 RVA: 0x01113910 File Offset: 0x01111B10
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x0604287E RID: 272510 RVA: 0x0111396C File Offset: 0x01111B6C
		protected override UniTask OnBeforeStartAsync()
		{
			ActivitySubViewFeiXuePreheat.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewFeiXuePreheat.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604287F RID: 272511 RVA: 0x011139B0 File Offset: 0x01111BB0
		protected override void OnRefreshView()
		{
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel != null)
			{
				commonInfoPanel.OnRefreshView();
			}
			ActivitySubViewGeneralInfo commonInfoPanel2 = this.CommonInfoPanel;
			if (commonInfoPanel2 != null)
			{
				commonInfoPanel2.SetFunctionRedDotVisible(this.GetFunctionRedDotState());
			}
			this.RefreshCondition();
			ButtonItem rewardBtn = this.RewardBtn;
			if (rewardBtn != null)
			{
				rewardBtn.SetRedDotVisible(this.ActivityBaseData.IsExistClaimableTask());
			}
			ButtonItem rewardBtn2 = this.RewardBtn;
			if (rewardBtn2 != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.ActivityBaseData.GetFinishedTaskNum());
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.ActivityBaseData.GetTotalTaskNum());
				rewardBtn2.SetText(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			this.RefreshRecommendQuestTips();
		}

		// Token: 0x06042880 RID: 272512 RVA: 0x01113A5E File Offset: 0x01111C5E
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06042881 RID: 272513 RVA: 0x01113A7C File Offset: 0x01111C7C
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06042882 RID: 272514 RVA: 0x01113A9A File Offset: 0x01111C9A
		private bool GetFunctionRedDotState()
		{
			return this.ActivityBaseData.IsFirstDoingTaskIsUnClick() || this.ActivityBaseData.IsExistClaimableTask();
		}

		// Token: 0x06042883 RID: 272515 RVA: 0x01113AB8 File Offset: 0x01111CB8
		private void RefreshCondition()
		{
			ActivityFunctionalTypeA functional = this.CommonInfoPanel.GetFunctional();
			ActivityFunctionAreaParams parameters = new ActivityFunctionAreaParams
			{
				UnlockBtnTextId = "LongShanStage_Join01",
				UnlockBtnFunction = new Action(this.OnConfirmBtnClick)
			};
			functional.RefreshGeneralPerformance(parameters);
		}

		// Token: 0x06042884 RID: 272516 RVA: 0x01113AFC File Offset: 0x01111CFC
		private bool IsShowPreOpenTips()
		{
			int num = this.ActivityBaseData.IsUnLock() ? 1 : 0;
			bool flag = this.ActivityBaseData.CanPreOpen();
			return num == 0 && flag;
		}

		// Token: 0x06042885 RID: 272517 RVA: 0x01113B28 File Offset: 0x01111D28
		private void RefreshRecommendQuestTips()
		{
			bool flag = this.IsShowPreOpenTips();
			this.RecommendQuestTipsSubPanel.SetUiActive(flag);
			if (flag)
			{
				this.RecommendQuestTipsSubPanel.SetTipsTxtByTextId("FeiXueWarmup_1030", Array.Empty<string>());
			}
		}

		// Token: 0x06042886 RID: 272518 RVA: 0x01113B60 File Offset: 0x01111D60
		private void OnRefreshCommonActivityRedDot(int id)
		{
			if (this.ActivityBaseData.Id != id)
			{
				return;
			}
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel == null)
			{
				return;
			}
			commonInfoPanel.SetFunctionRedDotVisible(this.GetFunctionRedDotState());
		}

		// Token: 0x06042887 RID: 272519 RVA: 0x01113B88 File Offset: 0x01111D88
		private void OnConfirmBtnClick()
		{
			if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
			{
				int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			}
			else
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.FeiXuePreheatMainView, this.ActivityBaseData, null);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityTab, this.ActivityBaseData.Id);
		}

		// Token: 0x06042888 RID: 272520 RVA: 0x01113BF7 File Offset: 0x01111DF7
		private void OnRewardBtnClick(int _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FeiXuePreheatRewardView, this.ActivityBaseData, null);
		}

		// Token: 0x06042889 RID: 272521 RVA: 0x01113C10 File Offset: 0x01111E10
		private void OnRecommendBtnClick()
		{
			if (ModelBase<QuestNewModel>.Instance.GetQuest(165800001) == null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RecallActivity_Role_Precondition", Array.Empty<object>());
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, 165800001, null);
		}

		// Token: 0x04025071 RID: 151665
		protected ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x04025072 RID: 151666
		private RecommendQuestTipsSubPanel RecommendQuestTipsSubPanel;

		// Token: 0x04025073 RID: 151667
		private ButtonItem RewardBtn;
	}
}
