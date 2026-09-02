using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A02 RID: 6658
public class CommonCostItem : UiPanelBase
{
	// Token: 0x0600BE8C RID: 48780 RVA: 0x00327384 File Offset: 0x00325584
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BE8D RID: 48781 RVA: 0x00327410 File Offset: 0x00325610
	public void UpdateItem(int id, int count)
	{
		this.ItemId = id;
		this.Count = count;
		base.SetItemIcon(base.GetTexture(2), id, null, null);
		base.GetText(1).SetText(count.ToString(), true);
	}

	// Token: 0x0600BE8E RID: 48782 RVA: 0x00327458 File Offset: 0x00325658
	public void RefreshCountEnableState()
	{
		UUIText text = base.GetText(1);
		UUIItem uuiitem = text;
		bool bUseChangeColor = !this.IsEnough;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x17000F93 RID: 3987
	// (get) Token: 0x0600BE8F RID: 48783 RVA: 0x0032748A File Offset: 0x0032568A
	public bool IsEnough
	{
		get
		{
			return this.ItemId != 0 && ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ItemId, 0) >= this.Count;
		}
	}

	// Token: 0x04005999 RID: 22937
	private int ItemId;

	// Token: 0x0400599A RID: 22938
	private int Count;

	// Token: 0x02007CEC RID: 31980
	private enum ECommonCostItemDefine
	{
		// Token: 0x0402A9D9 RID: 174553
		Tips,
		// Token: 0x0402A9DA RID: 174554
		CostText,
		// Token: 0x0402A9DB RID: 174555
		Icon
	}
}
