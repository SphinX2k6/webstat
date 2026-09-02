using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Morale;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001421 RID: 5153
[NullableContext(2)]
[Nullable(0)]
public class ActivitySubViewMorale : ActivitySubViewBase
{
	// Token: 0x17000BFE RID: 3070
	// (get) Token: 0x06008EDF RID: 36575 RVA: 0x00258265 File Offset: 0x00256465
	protected new ActivityMoraleData ActivityBaseData
	{
		get
		{
			return (ActivityMoraleData)this.ActivityBaseData;
		}
	}

	// Token: 0x06008EE1 RID: 36577 RVA: 0x0025827C File Offset: 0x0025647C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x06008EE2 RID: 36578 RVA: 0x00258318 File Offset: 0x00256518
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewMorale.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewMorale.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008EE3 RID: 36579 RVA: 0x0025835B File Offset: 0x0025655B
	protected override void OnStart()
	{
	}

	// Token: 0x06008EE4 RID: 36580 RVA: 0x00258360 File Offset: 0x00256560
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.EventCloseView));
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel == null)
		{
			return;
		}
		ActivityFunctionalTypeA functional = commonInfoPanel.GetFunctional();
		if (functional == null)
		{
			return;
		}
		ActivityButtonItem functionButton = functional.FunctionButton;
		if (functionButton == null)
		{
			return;
		}
		functionButton.BindRedDot(ERedDotName.Morale, 0);
	}

	// Token: 0x06008EE5 RID: 36581 RVA: 0x002583B0 File Offset: 0x002565B0
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.EventCloseView));
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel == null)
		{
			return;
		}
		ActivityFunctionalTypeA functional = commonInfoPanel.GetFunctional();
		if (functional == null)
		{
			return;
		}
		ActivityButtonItem functionButton = functional.FunctionButton;
		if (functionButton == null)
		{
			return;
		}
		functionButton.UnBindGivenUid(0);
	}

	// Token: 0x06008EE6 RID: 36582 RVA: 0x002583F0 File Offset: 0x002565F0
	protected override void OnRefreshView()
	{
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.ShowTextNew("Morale_title_20");
		}
		this.ScoreProgressPanel.UpdateData();
		this.UpdateTipsFinishNeedGetReward();
		this.UpdateGuideQuestState();
	}

	// Token: 0x06008EE7 RID: 36583 RVA: 0x00258420 File Offset: 0x00256620
	private void ClickCommonInfo(ActivityBaseData _)
	{
		ControllerBase<ActivityController>.Instance.OpenActivityContentView(this.ActivityBaseData);
	}

	// Token: 0x06008EE8 RID: 36584 RVA: 0x00258434 File Offset: 0x00256634
	public void UpdateTipsFinishNeedGetReward()
	{
		bool uiActive = this.IsShowFinishTips();
		this.FinishTipsSubPanel.SetUiActive(uiActive);
	}

	// Token: 0x06008EE9 RID: 36585 RVA: 0x00258454 File Offset: 0x00256654
	private bool IsShowFinishTips()
	{
		return this.ActivityBaseData != null && this.ActivityBaseData.IsUnLock() && this.ActivityBaseData.GetPreGuideQuestFinishState() && ModelBase<MoraleModel>.Instance.IsProgressScoreReachTarget();
	}

	// Token: 0x06008EEA RID: 36586 RVA: 0x00258486 File Offset: 0x00256686
	private void OnTipsFinishNeedGetRewardHelpCallback()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(322);
	}

	// Token: 0x06008EEB RID: 36587 RVA: 0x00258497 File Offset: 0x00256697
	private void EventCloseView(EUiViewName viewName, int _)
	{
		if (viewName == EUiViewName.MoraleAreaSumView)
		{
			this.UpdateTipsFinishNeedGetReward();
		}
	}

	// Token: 0x06008EEC RID: 36588 RVA: 0x002584AC File Offset: 0x002566AC
	public void UpdateGuideQuestState()
	{
		if (this.ActivityBaseData == null || !this.ActivityBaseData.IsUnLock())
		{
			return;
		}
		bool preGuideQuestFinishState = this.ActivityBaseData.GetPreGuideQuestFinishState();
		base.GetItem(3).SetUIActive(preGuideQuestFinishState);
		if (preGuideQuestFinishState)
		{
			return;
		}
		this.CommonInfoPanel.SetBtnText("Morale_title_36", Array.Empty<object>());
		string preShowGuideQuestName = this.ActivityBaseData.GetPreShowGuideQuestName();
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		ActivityFunctionalTypeA activityFunctionalTypeA = (commonInfoPanel != null) ? commonInfoPanel.GetFunctional() : null;
		if (activityFunctionalTypeA != null)
		{
			ActivityButtonItem functionButton = activityFunctionalTypeA.FunctionButton;
			if (functionButton != null)
			{
				functionButton.SetUiActive(true);
			}
		}
		if (activityFunctionalTypeA != null)
		{
			activityFunctionalTypeA.SetPanelConditionVisible(true);
		}
		if (activityFunctionalTypeA != null)
		{
			activityFunctionalTypeA.SetLockSpriteVisible(false);
		}
		if (activityFunctionalTypeA != null)
		{
			activityFunctionalTypeA.SetLockConditionButtonVisible(false);
		}
		if (activityFunctionalTypeA == null)
		{
			return;
		}
		activityFunctionalTypeA.SetLockTextByTextId("Morale_title_35", new string[]
		{
			preShowGuideQuestName
		});
	}

	// Token: 0x0400427F RID: 17023
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x04004280 RID: 17024
	[Nullable(1)]
	public MoraleScoreProgressActivityPanel ScoreProgressPanel;

	// Token: 0x04004281 RID: 17025
	[Nullable(1)]
	public RecommendQuestTipsSubPanel FinishTipsSubPanel;

	// Token: 0x02007823 RID: 30755
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402951C RID: 169244
		public const int ItemCommonPanel = 0;

		// Token: 0x0402951D RID: 169245
		public const int ItemTipsRoot = 1;

		// Token: 0x0402951E RID: 169246
		public const int TxtTips = 2;

		// Token: 0x0402951F RID: 169247
		public const int ItemProgressRoot = 3;

		// Token: 0x04029520 RID: 169248
		public const int ItemProgressPanel = 4;

		// Token: 0x04029521 RID: 169249
		public const int ItemFinishTipsPanel = 5;
	}
}
