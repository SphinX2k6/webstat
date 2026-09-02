using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200235F RID: 9055
[NullableContext(1)]
[Nullable(0)]
public class QteTipItem : UiPanelBase
{
	// Token: 0x06011514 RID: 70932 RVA: 0x004C3AB3 File Offset: 0x004C1CB3
	public void Init(UUIItem rootItem)
	{
		base.CreateThenShowByResourceIdAsync("UiItem_QteTips", rootItem, false);
	}

	// Token: 0x06011515 RID: 70933 RVA: 0x004C3AC4 File Offset: 0x004C1CC4
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

	// Token: 0x06011516 RID: 70934 RVA: 0x004C3B0C File Offset: 0x004C1D0C
	protected override void OnStart()
	{
		if (!string.IsNullOrEmpty(this.Tip))
		{
			this.Refresh(this.Tip);
		}
	}

	// Token: 0x06011517 RID: 70935 RVA: 0x004C3B27 File Offset: 0x004C1D27
	public void Refresh(string tip)
	{
		this.Tip = tip;
		if (!base.InAsyncLoading())
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), tip, Array.Empty<object>());
		}
	}

	// Token: 0x0400880C RID: 34828
	private string Tip = string.Empty;

	// Token: 0x02008674 RID: 34420
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402D7B9 RID: 186297
		TxtTip
	}
}
