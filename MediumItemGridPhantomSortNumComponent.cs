using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019D1 RID: 6609
public class MediumItemGridPhantomSortNumComponent : MediumItemGridComponent
{
	// Token: 0x0600BDAD RID: 48557 RVA: 0x00324600 File Offset: 0x00322800
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

	// Token: 0x0600BDAE RID: 48558 RVA: 0x00324648 File Offset: 0x00322848
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBSortNumA";
	}

	// Token: 0x0600BDAF RID: 48559 RVA: 0x00324650 File Offset: 0x00322850
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		if (data is int)
		{
			int num = (int)data;
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetText(num.ToString(), true);
			}
			this.SetActive(num > 0);
			return;
		}
	}

	// Token: 0x02007CC8 RID: 31944
	private class EComponent
	{
		// Token: 0x0402A97C RID: 174460
		public const int TxtSortNum = 0;
	}
}
