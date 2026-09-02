using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200190F RID: 6415
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class QualityToggleGridProxy : GridProxyAbstract<FilterItemData>
{
	// Token: 0x0600B851 RID: 47185 RVA: 0x0030FBB8 File Offset: 0x0030DDB8
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

	// Token: 0x0600B852 RID: 47186 RVA: 0x0030FC60 File Offset: 0x0030DE60
	private void OnToggleChanged(EToggleState state)
	{
		bool isChecked = state == EToggleState.ETT_Checked;
		if (base.ScrollViewDelegate != null && this.ToggleFunction != null)
		{
			ScrollViewDelegate<QualityToggleGridProxy, FilterItemData> scrollViewDelegate = base.ScrollViewDelegate as ScrollViewDelegate<QualityToggleGridProxy, FilterItemData>;
			FilterItemData filterItemData = (scrollViewDelegate != null) ? scrollViewDelegate.TryGetCachedData(base.GridIndex) : null;
			if (filterItemData != null)
			{
				this.ToggleFunction(isChecked, filterItemData.FilterId, filterItemData.Content ?? "");
			}
		}
	}

	// Token: 0x0600B853 RID: 47187 RVA: 0x0030FCC4 File Offset: 0x0030DEC4
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

	// Token: 0x0600B854 RID: 47188 RVA: 0x0030FD15 File Offset: 0x0030DF15
	public void SetToggleFunction(TQualityToggleFunction func)
	{
		this.ToggleFunction = func;
	}

	// Token: 0x0600B855 RID: 47189 RVA: 0x0030FD20 File Offset: 0x0030DF20
	public void SetSelectedState(bool isSelected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x040056D3 RID: 22227
	[Nullable(2)]
	private TQualityToggleFunction ToggleFunction;

	// Token: 0x040056D4 RID: 22228
	[Nullable(2)]
	public FilterItemData Data;

	// Token: 0x02007C5C RID: 31836
	[NullableContext(0)]
	private class EQualityToggleDefine
	{
		// Token: 0x0402A7A2 RID: 173986
		public const int Toggle = 0;

		// Token: 0x0402A7A3 RID: 173987
		public const int QualityText = 1;
	}
}
