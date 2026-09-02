using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BE9 RID: 11241
public class TowerCostItem : UiPanelBase
{
	// Token: 0x060166F2 RID: 91890 RVA: 0x0063B42C File Offset: 0x0063962C
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

	// Token: 0x060166F3 RID: 91891 RVA: 0x0063B498 File Offset: 0x00639698
	public void Update(int cost)
	{
		UUIText text = base.GetText(0);
		text.SetText(cost.ToString(), true);
		FColor? fcolor = (cost >= 4) ? TowerData.highColor : ((cost == 0) ? TowerData.noneColor : TowerData.lowColor);
		text.SetColor(fcolor.Value);
		base.GetItem(1).SetColor(fcolor.Value);
	}

	// Token: 0x02008EDF RID: 36575
	private enum EChildType
	{
		// Token: 0x0402FFF0 RID: 196592
		NumberText,
		// Token: 0x0402FFF1 RID: 196593
		IconItem
	}
}
