using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020015FC RID: 5628
public class ActivityDescriptionTypeA : UiPanelBase
{
	// Token: 0x06009E9C RID: 40604 RVA: 0x00298218 File Offset: 0x00296418
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

	// Token: 0x06009E9D RID: 40605 RVA: 0x00298260 File Offset: 0x00296460
	[NullableContext(1)]
	public void SetContentByTextId(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
	}

	// Token: 0x06009E9E RID: 40606 RVA: 0x00298275 File Offset: 0x00296475
	[NullableContext(1)]
	public void SetContentByText(string text)
	{
		base.GetText(0).SetText(text, true);
	}

	// Token: 0x06009E9F RID: 40607 RVA: 0x00298285 File Offset: 0x00296485
	public void SetContentVisible(bool bVisible)
	{
		base.GetText(0).SetUIActive(bVisible);
	}

	// Token: 0x020079BC RID: 31164
	private class EComponents
	{
		// Token: 0x04029CCF RID: 171215
		public const int TextContent = 0;
	}
}
