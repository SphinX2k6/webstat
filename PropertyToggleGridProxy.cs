using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001918 RID: 6424
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PropertyToggleGridProxy : GridProxyAbstract<FilterItemData>
{
	// Token: 0x0600B8AB RID: 47275 RVA: 0x003114BC File Offset: 0x0030F6BC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleChanged));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B8AC RID: 47276 RVA: 0x003115A4 File Offset: 0x0030F7A4
	protected override void OnStart()
	{
		base.GetTexture(2).SetUIActive(true);
		base.GetSprite(3).SetUIActive(false);
	}

	// Token: 0x0600B8AD RID: 47277 RVA: 0x003115C0 File Offset: 0x0030F7C0
	private void OnToggleChanged(EToggleState state)
	{
		bool isChecked = state == EToggleState.ETT_Checked;
		if (this.ToggleFunction != null)
		{
			this.ToggleFunction(isChecked, this.Data.FilterId, this.Data.Content ?? "");
		}
	}

	// Token: 0x0600B8AE RID: 47278 RVA: 0x00311608 File Offset: 0x0030F808
	public override void Refresh(FilterItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		UUIText text = base.GetText(4);
		if (text != null)
		{
			text.SetText(data.Content ?? "", true);
		}
		UUITexture texture = base.GetTexture(2);
		if (texture != null)
		{
			base.SetTextureByPath(data.GetIconPath() ?? "", texture, null, null);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x0600B8AF RID: 47279 RVA: 0x00311684 File Offset: 0x0030F884
	public void SetToggleFunction(TPropertyToggleFunction func)
	{
		this.ToggleFunction = func;
	}

	// Token: 0x0600B8B0 RID: 47280 RVA: 0x00311690 File Offset: 0x0030F890
	public void SetSelectedState(bool isSelected)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x040056EE RID: 22254
	[Nullable(2)]
	private TPropertyToggleFunction ToggleFunction;

	// Token: 0x040056EF RID: 22255
	[Nullable(2)]
	public FilterItemData Data;

	// Token: 0x02007C69 RID: 31849
	[NullableContext(0)]
	private class EPropertyToggleDefine
	{
		// Token: 0x0402A7D7 RID: 174039
		public const int Toggle = 0;

		// Token: 0x0402A7D8 RID: 174040
		public const int TexIcon = 2;

		// Token: 0x0402A7D9 RID: 174041
		public const int SpriteIcon = 3;

		// Token: 0x0402A7DA RID: 174042
		public const int PropertyText = 4;
	}
}
