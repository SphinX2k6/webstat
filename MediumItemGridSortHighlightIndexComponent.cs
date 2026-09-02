using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019E0 RID: 6624
public class MediumItemGridSortHighlightIndexComponent : MediumItemGridComponent
{
	// Token: 0x0600BDEE RID: 48622 RVA: 0x003250B4 File Offset: 0x003232B4
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

	// Token: 0x0600BDEF RID: 48623 RVA: 0x003250FC File Offset: 0x003232FC
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemSortNumYellow";
	}

	// Token: 0x0600BDF0 RID: 48624 RVA: 0x00325104 File Offset: 0x00323304
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

	// Token: 0x02007CD3 RID: 31955
	private class EChildType
	{
		// Token: 0x0402A98F RID: 174479
		public const int SortIndexText = 0;
	}
}
