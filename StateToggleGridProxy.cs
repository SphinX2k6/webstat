using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001910 RID: 6416
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class StateToggleGridProxy : GridProxyAbstract<FilterItemData>
{
	// Token: 0x0600B857 RID: 47191 RVA: 0x0030FD54 File Offset: 0x0030DF54
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
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleChanged));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B858 RID: 47192 RVA: 0x0030FDFC File Offset: 0x0030DFFC
	private void OnToggleChanged(EToggleState state)
	{
		bool isChecked = state == EToggleState.ETT_Checked;
		if (this.ToggleFunction != null)
		{
			this.ToggleFunction(isChecked, this.Data.FilterId, this.Data.Content ?? "");
		}
	}

	// Token: 0x0600B859 RID: 47193 RVA: 0x0030FE44 File Offset: 0x0030E044
	public override void Refresh(FilterItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetText(data.Content ?? "", true);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x0600B85A RID: 47194 RVA: 0x0030FE95 File Offset: 0x0030E095
	public void SetToggleFunction(TQualityToggleFunction func)
	{
		this.ToggleFunction = func;
	}

	// Token: 0x0600B85B RID: 47195 RVA: 0x0030FEA0 File Offset: 0x0030E0A0
	public void SetSelectedState(bool isSelected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x040056D5 RID: 22229
	[Nullable(2)]
	private TQualityToggleFunction ToggleFunction;

	// Token: 0x040056D6 RID: 22230
	[Nullable(2)]
	public FilterItemData Data;

	// Token: 0x02007C5D RID: 31837
	[NullableContext(0)]
	private class EStateToggleDefine
	{
		// Token: 0x0402A7A4 RID: 173988
		public const int Toggle = 0;

		// Token: 0x0402A7A5 RID: 173989
		public const int StateText = 1;
	}
}
