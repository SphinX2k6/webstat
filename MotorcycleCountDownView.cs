using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200228B RID: 8843
public class MotorcycleCountDownView : UiViewBase
{
	// Token: 0x06010B82 RID: 68482 RVA: 0x004941F3 File Offset: 0x004923F3
	[NullableContext(1)]
	public MotorcycleCountDownView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010B83 RID: 68483 RVA: 0x00494204 File Offset: 0x00492404
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x06010B84 RID: 68484 RVA: 0x00494227 File Offset: 0x00492427
	protected override void OnStart()
	{
		this.CountDownText = base.GetText(0);
	}

	// Token: 0x06010B85 RID: 68485 RVA: 0x00494236 File Offset: 0x00492436
	protected override void OnBeforeShow()
	{
		ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.Custom, MotorcycleCountDownDefine.hideBattleUiChildren, false, true, 0);
	}

	// Token: 0x06010B86 RID: 68486 RVA: 0x00494250 File Offset: 0x00492450
	protected override void OnAfterHide()
	{
		ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.Custom, MotorcycleCountDownDefine.hideBattleUiChildren, true, true, 0);
	}

	// Token: 0x06010B87 RID: 68487 RVA: 0x0049426A File Offset: 0x0049246A
	protected override void OnAddEventListener()
	{
		base.OnAddEventListener();
		Singleton<EventSystem>.Instance.Add<double, double>(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.OnCountDownChanged));
	}

	// Token: 0x06010B88 RID: 68488 RVA: 0x0049428E File Offset: 0x0049248E
	protected override void OnRemoveEventListener()
	{
		base.OnRemoveEventListener();
		Singleton<EventSystem>.Instance.Remove<double, double>(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.OnCountDownChanged));
	}

	// Token: 0x06010B89 RID: 68489 RVA: 0x004942B4 File Offset: 0x004924B4
	private void OnCountDownChanged(double remainTime, double timerEndTime)
	{
		if (remainTime <= 0.0)
		{
			this.HandleCountDownEnd();
			return;
		}
		string remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat5(remainTime);
		UUIText countDownText = this.CountDownText;
		if (countDownText != null)
		{
			countDownText.SetText(remainTimeDataFormat, true);
		}
		if (remainTime < (double)this.WarningTime)
		{
			this.PlayWarningAnim();
		}
	}

	// Token: 0x06010B8A RID: 68490 RVA: 0x00494303 File Offset: 0x00492503
	private void HandleCountDownEnd()
	{
		ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing = true;
		base.CloseMe(delegate(bool success)
		{
			if (success)
			{
				ModelBase<GeneralLogicTreeModel>.Instance.CountDownViewClosing = false;
			}
		});
	}

	// Token: 0x06010B8B RID: 68491 RVA: 0x00494338 File Offset: 0x00492538
	private void PlayWarningAnim()
	{
		if (this.IsInWarning)
		{
			return;
		}
		this.IsInWarning = true;
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Loop", false, null);
	}

	// Token: 0x040083F0 RID: 33776
	private bool IsInWarning;

	// Token: 0x040083F1 RID: 33777
	private readonly int WarningTime = 10;

	// Token: 0x040083F2 RID: 33778
	[Nullable(2)]
	private UUIText CountDownText;

	// Token: 0x02008555 RID: 34133
	private class EChildType
	{
		// Token: 0x0402D1EE RID: 184814
		public const int CountDownText = 0;
	}
}
