using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001CE5 RID: 7397
public class GachaDiscountTagItem : UiPanelBase
{
	// Token: 0x0600D900 RID: 55552 RVA: 0x003A20F8 File Offset: 0x003A02F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D901 RID: 55553 RVA: 0x003A2140 File Offset: 0x003A0340
	[NullableContext(1)]
	public void SetContent(string text)
	{
		base.GetText(0).SetText(text, true);
	}

	// Token: 0x0600D902 RID: 55554 RVA: 0x003A2150 File Offset: 0x003A0350
	[NullableContext(1)]
	public void SetLocalText(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
	}

	// Token: 0x02008039 RID: 32825
	private enum EComponent
	{
		// Token: 0x0402B9E8 RID: 178664
		TextContent
	}
}
