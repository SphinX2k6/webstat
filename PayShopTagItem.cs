using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020023E8 RID: 9192
public class PayShopTagItem : UiPanelBase
{
	// Token: 0x06011C9B RID: 72859 RVA: 0x004E4560 File Offset: 0x004E2760
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06011C9C RID: 72860 RVA: 0x004E45C9 File Offset: 0x004E27C9
	[NullableContext(1)]
	public void SetText(string text)
	{
		UUIText text2 = base.GetText(0);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(text, true);
	}

	// Token: 0x06011C9D RID: 72861 RVA: 0x004E45DE File Offset: 0x004E27DE
	[NullableContext(1)]
	public void SetTextByTextId(string textId, int param = 0)
	{
		this.TextParam = param;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, new <>z__ReadOnlySingleElementList<object>(param));
	}

	// Token: 0x06011C9E RID: 72862 RVA: 0x004E4604 File Offset: 0x004E2804
	public void SetMaskVisible(bool isVisible)
	{
		UUITexture texture = base.GetTexture(1);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(isVisible);
	}

	// Token: 0x04008B37 RID: 35639
	public int TextParam;

	// Token: 0x02008721 RID: 34593
	private class EComponents
	{
		// Token: 0x0402DB52 RID: 187218
		public const int Text = 0;

		// Token: 0x0402DB53 RID: 187219
		public const int TextureMask = 1;
	}
}
