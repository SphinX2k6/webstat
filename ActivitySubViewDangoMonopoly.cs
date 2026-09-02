using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012DA RID: 4826
[NullableContext(1)]
[Nullable(0)]
public class ActivitySubViewDangoMonopoly : ActivitySubViewBase
{
	// Token: 0x17000AF1 RID: 2801
	// (get) Token: 0x060082A5 RID: 33445 RVA: 0x002293D2 File Offset: 0x002275D2
	protected new ActivityDangoMonopolyData ActivityBaseData
	{
		get
		{
			return (ActivityDangoMonopolyData)this.ActivityBaseData;
		}
	}

	// Token: 0x060082A6 RID: 33446 RVA: 0x002293E0 File Offset: 0x002275E0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnBtnDice))
		};
	}

	// Token: 0x060082A7 RID: 33447 RVA: 0x002294CB File Offset: 0x002276CB
	private void OnBtnDice()
	{
		this.ActivityBaseData.OpenViewDiceTask();
	}

	// Token: 0x060082A8 RID: 33448 RVA: 0x002294D8 File Offset: 0x002276D8
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewDangoMonopoly.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewDangoMonopoly.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060082A9 RID: 33449 RVA: 0x0022951B File Offset: 0x0022771B
	protected override void OnStart()
	{
	}

	// Token: 0x060082AA RID: 33450 RVA: 0x0022951D File Offset: 0x0022771D
	protected override void OnAddEventListener()
	{
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.DangoMonopolyTask, base.GetItem(2), new Action<bool, int>(this.UpdateRedDotActivity), 0);
	}

	// Token: 0x060082AB RID: 33451 RVA: 0x00229542 File Offset: 0x00227742
	protected override void OnRemoveEventListener()
	{
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.DangoMonopolyTask);
	}

	// Token: 0x060082AC RID: 33452 RVA: 0x00229554 File Offset: 0x00227754
	protected override void OnRefreshView()
	{
		bool flag = this.ActivityBaseData.IsUnLock();
		bool diceShowState = this.GetDiceShowState();
		int[] array;
		if (!diceShowState)
		{
			array = new int[0];
		}
		else
		{
			(array = new int[1])[0] = this.ActivityBaseData.DiceItemId;
		}
		int[] p = array;
		base.GetItem(5).SetUIActive(flag);
		base.GetItem(6).SetUIActive(diceShowState);
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.SetActivityViewCurrency, p);
		if (flag)
		{
			int currentBoardPosition = this.ActivityBaseData.GetCurrentBoardPosition();
			int totalRoundNum = this.ActivityBaseData.GetTotalRoundNum();
			base.GetText(3).SetText(currentBoardPosition.ToString(), true);
			UUIText text = base.GetText(4);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(totalRoundNum);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		this.UpdateRedDotActivity(false, 0);
		this.UpdateRoundRewardInfo();
		this.UpdateBoardLockRemainTime();
	}

	// Token: 0x060082AD RID: 33453 RVA: 0x00229635 File Offset: 0x00227835
	private void ClickCommonInfo(ActivityBaseData _)
	{
		this.ActivityBaseData.RequestEnterDangoMonopoly();
	}

	// Token: 0x060082AE RID: 33454 RVA: 0x00229644 File Offset: 0x00227844
	private void UpdateRedDotActivity(bool _1, int _2)
	{
		bool exDataRedPointShowState = this.ActivityBaseData.GetExDataRedPointShowState();
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		if (commonInfoPanel == null)
		{
			return;
		}
		commonInfoPanel.SetFunctionRedDotVisible(exDataRedPointShowState);
	}

	// Token: 0x060082AF RID: 33455 RVA: 0x0022966E File Offset: 0x0022786E
	public bool GetDiceShowState()
	{
		return this.ActivityBaseData.IsUnLock() && !this.ActivityBaseData.IsFinishAllRound();
	}

	// Token: 0x060082B0 RID: 33456 RVA: 0x00229690 File Offset: 0x00227890
	public void UpdateRoundRewardInfo()
	{
		if (!this.ActivityBaseData.IsAllGetRoundReward())
		{
			return;
		}
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		ActivityFunctionalTypeA activityFunctionalTypeA = (commonInfoPanel != null) ? commonInfoPanel.GetFunctional() : null;
		if (activityFunctionalTypeA != null)
		{
			activityFunctionalTypeA.SetActivatePanelConditionVisible(true);
		}
		if (activityFunctionalTypeA == null)
		{
			return;
		}
		activityFunctionalTypeA.SetActivateTextByTextId("DangoMonopoly_title_21", Array.Empty<string>());
	}

	// Token: 0x060082B1 RID: 33457 RVA: 0x002296E0 File Offset: 0x002278E0
	public void UpdateBoardLockRemainTime()
	{
		if (!this.ActivityBaseData.IsRunningBoardLock())
		{
			return;
		}
		ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
		ActivityFunctionalTypeA activityFunctionalTypeA = (commonInfoPanel != null) ? commonInfoPanel.GetFunctional() : null;
		if (activityFunctionalTypeA != null)
		{
			activityFunctionalTypeA.SetPanelConditionVisible(true);
		}
		if (activityFunctionalTypeA == null)
		{
			return;
		}
		activityFunctionalTypeA.SetLockTextByText(this.ActivityBaseData.GetBoardRemainTimeStr());
	}

	// Token: 0x060082B2 RID: 33458 RVA: 0x0022972F File Offset: 0x0022792F
	protected override void OnTimer(float _)
	{
		this.UpdateBoardLockRemainTime();
	}

	// Token: 0x04003E04 RID: 15876
	[Nullable(2)]
	protected ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x0200765C RID: 30300
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028C98 RID: 167064
		ItemCommonPanel,
		// Token: 0x04028C99 RID: 167065
		BtnDice,
		// Token: 0x04028C9A RID: 167066
		ItemDiceRedDot,
		// Token: 0x04028C9B RID: 167067
		TxtCurrentRound,
		// Token: 0x04028C9C RID: 167068
		TxtTotalRound,
		// Token: 0x04028C9D RID: 167069
		ItemRoundRoot,
		// Token: 0x04028C9E RID: 167070
		ItemDiceRoot,
		// Token: 0x04028C9F RID: 167071
		TxtDiceBtnTitle
	}
}
