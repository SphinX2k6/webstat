using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020023F6 RID: 9206
[Nullable(new byte[]
{
	0,
	1
})]
public class WeekCardCostGrid : GridProxyAbstract<IWeekCostData>
{
	// Token: 0x06011D13 RID: 72979 RVA: 0x004E7070 File Offset: 0x004E5270
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

	// Token: 0x06011D14 RID: 72980 RVA: 0x004E70FC File Offset: 0x004E52FC
	[NullableContext(1)]
	public void Refresh(IWeekCostData costData)
	{
		UUIText text = base.GetText(0);
		text.SetUIActive(!string.IsNullOrEmpty(costData.Tips));
		if (!string.IsNullOrEmpty(costData.Tips))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, costData.Tips, Array.Empty<object>());
		}
		base.GetText(1).SetText(costData.Count.ToString(), true);
		base.SetItemIcon(base.GetTexture(2), costData.ItemId, null, null);
	}

	// Token: 0x06011D15 RID: 72981 RVA: 0x004E7180 File Offset: 0x004E5380
	[NullableContext(2)]
	public override void Refresh(IWeekCostData data, bool isSelected, int gridIndex)
	{
		if (data != null)
		{
			this.Refresh(data);
		}
	}

	// Token: 0x02008732 RID: 34610
	private class EComponent
	{
		// Token: 0x0402DBB0 RID: 187312
		public const int TipsText = 0;

		// Token: 0x0402DBB1 RID: 187313
		public const int CostText = 1;

		// Token: 0x0402DBB2 RID: 187314
		public const int CostIcon = 2;
	}
}
