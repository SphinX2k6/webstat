using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002CD1 RID: 11473
[NullableContext(1)]
[Nullable(0)]
public class SimpleGenericLayout
{
	// Token: 0x060171CE RID: 94670 RVA: 0x006672EC File Offset: 0x006654EC
	public SimpleGenericLayout(UUILayoutBase layout)
	{
		this.Layout = layout;
		UUIItem attachUIChild = layout.RootUIComp.Get().GetAttachUIChild(0);
		if (attachUIChild == null || !attachUIChild.IsValid())
		{
			Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.LZK, "Layout下不存在有效的子节点", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.SrcItem = attachUIChild;
		this.ItemList.Add(this.SrcItem);
	}

	// Token: 0x060171CF RID: 94671 RVA: 0x00667368 File Offset: 0x00665568
	public void RebuildLayout(int length)
	{
		if (this.SrcItem == null || !this.SrcItem.IsValid())
		{
			Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.LZK, "Layout下不存在有效的子节点", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.DisplayCount = length;
		UUIItem parent = this.Layout.RootUIComp.Get();
		for (int i = this.ItemList.Count; i < this.DisplayCount; i++)
		{
			UUIItem item = Singleton<LguiUtil>.Instance.CopyItem(this.SrcItem, parent);
			this.ItemList.Add(item);
		}
		for (int j = 0; j < this.DisplayCount; j++)
		{
			this.ItemList[j].SetUIActive(true);
		}
		for (int k = this.DisplayCount; k < this.ItemList.Count; k++)
		{
			this.ItemList[k].SetUIActive(false);
		}
	}

	// Token: 0x060171D0 RID: 94672 RVA: 0x00667456 File Offset: 0x00665656
	public int GetDisplayCount()
	{
		return this.DisplayCount;
	}

	// Token: 0x060171D1 RID: 94673 RVA: 0x0066745E File Offset: 0x0066565E
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<UUIItem> GetItemList()
	{
		return this.ItemList;
	}

	// Token: 0x060171D2 RID: 94674 RVA: 0x00667468 File Offset: 0x00665668
	public void SetActive(bool active)
	{
		this.Layout.RootUIComp.Get().SetUIActive(active);
	}

	// Token: 0x0400B1D0 RID: 45520
	[Nullable(2)]
	public readonly UUILayoutBase Layout;

	// Token: 0x0400B1D1 RID: 45521
	[Nullable(2)]
	private readonly UUIItem SrcItem;

	// Token: 0x0400B1D2 RID: 45522
	private readonly List<UUIItem> ItemList = new List<UUIItem>();

	// Token: 0x0400B1D3 RID: 45523
	private int DisplayCount;
}
