using System;
using System.Collections.Generic;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A18 RID: 10776
public class PausePanel : UiComponentAction
{
	// Token: 0x060157F9 RID: 88057 RVA: 0x005F5B6C File Offset: 0x005F3D6C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick)),
			new ValueTuple<int, Delegate>(1, new Action(this.OnStartAgainBtnClick)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnContinueBtnClick))
		};
	}

	// Token: 0x060157FA RID: 88058 RVA: 0x005F5C19 File Offset: 0x005F3E19
	private void OnCloseBtnClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.SignalDecodeView, null);
	}

	// Token: 0x060157FB RID: 88059 RVA: 0x005F5C2B File Offset: 0x005F3E2B
	private void OnStartAgainBtnClick()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSignalCatchStartAgain);
	}

	// Token: 0x060157FC RID: 88060 RVA: 0x005F5C3D File Offset: 0x005F3E3D
	private void OnContinueBtnClick()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSignalCatchContinue);
	}

	// Token: 0x02008D97 RID: 36247
	private static class EChildComponent
	{
		// Token: 0x0402F9C0 RID: 195008
		public const int LeaveBtn = 0;

		// Token: 0x0402F9C1 RID: 195009
		public const int StartAgainBtn = 1;

		// Token: 0x0402F9C2 RID: 195010
		public const int ContinueBtn = 2;
	}
}
