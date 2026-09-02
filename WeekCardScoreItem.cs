using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002404 RID: 9220
public class WeekCardScoreItem : UiPanelBase
{
	// Token: 0x06011D60 RID: 73056 RVA: 0x004E7CDC File Offset: 0x004E5EDC
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

	// Token: 0x06011D61 RID: 73057 RVA: 0x004E7D68 File Offset: 0x004E5F68
	[NullableContext(1)]
	public void Refresh(IWeekScoreData costData)
	{
		UUIText text = base.GetText(0);
		text.SetUIActive(!string.IsNullOrEmpty(costData.Tips));
		if (!string.IsNullOrEmpty(costData.Tips))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, costData.Tips, Array.Empty<object>());
		}
		base.GetText(1).SetText(costData.Count.ToString(), true);
		base.SetTextureByPath(costData.IconPath, base.GetTexture(2), null, null);
	}

	// Token: 0x02008737 RID: 34615
	private class EComponent
	{
		// Token: 0x0402DBC3 RID: 187331
		public const int TipsText = 0;

		// Token: 0x0402DBC4 RID: 187332
		public const int CostText = 1;

		// Token: 0x0402DBC5 RID: 187333
		public const int CostIcon = 2;
	}
}
