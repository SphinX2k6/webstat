using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020015FD RID: 5629
public class ActivityDescriptionTypeB : UiPanelBase
{
	// Token: 0x06009EA1 RID: 40609 RVA: 0x0029829C File Offset: 0x0029649C
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

	// Token: 0x06009EA2 RID: 40610 RVA: 0x002982E4 File Offset: 0x002964E4
	[NullableContext(1)]
	public void SetContentByTextId(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
	}

	// Token: 0x06009EA3 RID: 40611 RVA: 0x002982F9 File Offset: 0x002964F9
	[NullableContext(1)]
	public void SetContentByText(string text)
	{
		base.GetText(0).SetText(text, true);
	}

	// Token: 0x06009EA4 RID: 40612 RVA: 0x00298309 File Offset: 0x00296509
	public void SetContentVisible(bool bVisible)
	{
		base.GetText(0).SetUIActive(bVisible);
	}

	// Token: 0x020079BD RID: 31165
	private class EComponents
	{
		// Token: 0x04029CD0 RID: 171216
		public const int TextContent = 0;
	}
}
