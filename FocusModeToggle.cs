using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002664 RID: 9828
public class FocusModeToggle : UiPanelBase
{
	// Token: 0x060135B6 RID: 79286 RVA: 0x00562F30 File Offset: 0x00561130
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060135B7 RID: 79287 RVA: 0x00562F99 File Offset: 0x00561199
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x060135B8 RID: 79288 RVA: 0x00562FB4 File Offset: 0x005611B4
	protected override void OnBeforeDestroy()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.OnStateChange.Clear();
			extendToggle.OnPointUpCallBack.Unbind();
			extendToggle.CanExecuteChange.Unbind();
		}
	}

	// Token: 0x060135B9 RID: 79289 RVA: 0x00562FF0 File Offset: 0x005611F0
	[NullableContext(1)]
	public void BindToggleCallback(Action<EToggleState> onToggleStateChange, Action<EToggleState> onPointUpCallBack)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.OnStateChange.Add(onToggleStateChange);
			extendToggle.OnPointUpCallBack.Bind(onPointUpCallBack);
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
		}
	}

	// Token: 0x060135BA RID: 79290 RVA: 0x00563037 File Offset: 0x00561237
	public void SetToggleState(bool bActive)
	{
		this.ManualSetToggleState = true;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(bActive ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, true, false, false);
		}
		this.ManualSetToggleState = false;
	}

	// Token: 0x060135BB RID: 79291 RVA: 0x00563064 File Offset: 0x00561264
	[NullableContext(1)]
	public void SetButtonText(string textTableId)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), textTableId, Array.Empty<object>());
	}

	// Token: 0x060135BC RID: 79292 RVA: 0x00563080 File Offset: 0x00561280
	private bool CanToggleExecuteChange()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		EToggleState? etoggleState = (extendToggle != null) ? new EToggleState?(extendToggle.GetToggleState()) : null;
		if (!this.ManualSetToggleState)
		{
			EToggleState? etoggleState2 = etoggleState;
			EToggleState etoggleState3 = EToggleState.ETT_Checked;
			return etoggleState2.GetValueOrDefault() == etoggleState3 & etoggleState2 != null;
		}
		return true;
	}

	// Token: 0x0400971D RID: 38685
	private bool ManualSetToggleState;

	// Token: 0x020089F6 RID: 35318
	private class EChildComponent
	{
		// Token: 0x0402E88D RID: 190605
		public const int Toggle = 0;

		// Token: 0x0402E88E RID: 190606
		public const int ToggleText = 1;
	}
}
