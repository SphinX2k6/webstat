using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019E1 RID: 6625
public class MediumItemGridSortIndexComponent : MediumItemGridComponent
{
	// Token: 0x0600BDF2 RID: 48626 RVA: 0x00325154 File Offset: 0x00323354
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

	// Token: 0x0600BDF3 RID: 48627 RVA: 0x0032519C File Offset: 0x0032339C
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemSortNum";
	}

	// Token: 0x0600BDF4 RID: 48628 RVA: 0x003251A4 File Offset: 0x003233A4
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		if (data is int)
		{
			int num = (int)data;
			if (num != 0)
			{
				UUIText text = base.GetText(0);
				if (text != null)
				{
					text.SetText(num.ToString(), true);
				}
				this.SetActive(true);
				return;
			}
		}
		this.SetActive(false);
	}

	// Token: 0x02007CD4 RID: 31956
	private class EChildType
	{
		// Token: 0x0402A990 RID: 174480
		public const int SortIndexText = 0;
	}
}
