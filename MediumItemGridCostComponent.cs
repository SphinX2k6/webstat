using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x020019B9 RID: 6585
public class MediumItemGridCostComponent : MediumItemGridComponent
{
	// Token: 0x0600BD22 RID: 48418 RVA: 0x003234E1 File Offset: 0x003216E1
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemEnergy";
	}

	// Token: 0x0600BD23 RID: 48419 RVA: 0x003234E8 File Offset: 0x003216E8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BD24 RID: 48420 RVA: 0x00323554 File Offset: 0x00321754
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		MediumItemGridCostComponentData mediumItemGridCostComponentData = data as MediumItemGridCostComponentData;
		if (mediumItemGridCostComponentData == null)
		{
			return;
		}
		UUIText text = base.GetText(0);
		if (mediumItemGridCostComponentData.Text != null)
		{
			text.SetText(mediumItemGridCostComponentData.Text, true);
		}
		else
		{
			text.SetText(mediumItemGridCostComponentData.Cost.ToString(), true);
		}
		if (text != null)
		{
			text.SetColor(mediumItemGridCostComponentData.Color);
		}
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetColor(mediumItemGridCostComponentData.Color);
		}
		this.SetActive(true);
	}

	// Token: 0x02007CBB RID: 31931
	private class ECostItem
	{
		// Token: 0x0402A95E RID: 174430
		public const int NumberText = 0;

		// Token: 0x0402A95F RID: 174431
		public const int IconItem = 1;
	}
}
