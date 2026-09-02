using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001904 RID: 6404
[NullableContext(2)]
[Nullable(0)]
public class FilterToggleItem : UiPanelBase
{
	// Token: 0x0600B7DC RID: 47068 RVA: 0x0030E648 File Offset: 0x0030C848
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600B7DD RID: 47069 RVA: 0x0030E690 File Offset: 0x0030C890
	protected override void OnStart()
	{
		this.Toggle = base.GetExtendToggle(0);
		UUIExtendToggle toggle = this.Toggle;
		if (toggle == null)
		{
			return;
		}
		toggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
	}

	// Token: 0x0600B7DE RID: 47070 RVA: 0x0030E6C0 File Offset: 0x0030C8C0
	protected override void OnBeforeDestroy()
	{
		UUIExtendToggle toggle = this.Toggle;
		if (toggle != null)
		{
			toggle.OnStateChange.Remove(new Action<EToggleState>(this.OnToggleStateChange));
		}
		this.Toggle = null;
		this.ToggleFunction = null;
	}

	// Token: 0x0600B7DF RID: 47071 RVA: 0x0030E6F2 File Offset: 0x0030C8F2
	private void OnToggleStateChange(EToggleState state)
	{
		Action<EToggleState> toggleFunction = this.ToggleFunction;
		if (toggleFunction == null)
		{
			return;
		}
		toggleFunction(state);
	}

	// Token: 0x0600B7E0 RID: 47072 RVA: 0x0030E705 File Offset: 0x0030C905
	[NullableContext(1)]
	public void SetFunction(Action<EToggleState> toggleFunction)
	{
		this.ToggleFunction = toggleFunction;
	}

	// Token: 0x0600B7E1 RID: 47073 RVA: 0x0030E70E File Offset: 0x0030C90E
	public void SetToggleState(EToggleState state)
	{
		UUIExtendToggle toggle = this.Toggle;
		if (toggle == null)
		{
			return;
		}
		toggle.SetToggleStateForce(state, false, false, false);
	}

	// Token: 0x0600B7E2 RID: 47074 RVA: 0x0030E724 File Offset: 0x0030C924
	public UUIItem GetFilterToggleItem()
	{
		UUIExtendToggle toggle = this.Toggle;
		if (toggle == null)
		{
			return null;
		}
		return toggle.RootUIComp.Get();
	}

	// Token: 0x040056B3 RID: 22195
	private UUIExtendToggle Toggle;

	// Token: 0x040056B4 RID: 22196
	private Action<EToggleState> ToggleFunction;

	// Token: 0x02007C55 RID: 31829
	[NullableContext(0)]
	private class EFilterToggleComp
	{
		// Token: 0x0402A77F RID: 173951
		public const int Toggle = 0;
	}
}
