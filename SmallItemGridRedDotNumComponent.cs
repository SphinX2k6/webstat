using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001A37 RID: 6711
public class SmallItemGridRedDotNumComponent : SmallItemGridComponent
{
	// Token: 0x0600C037 RID: 49207 RVA: 0x0032C9D0 File Offset: 0x0032ABD0
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

	// Token: 0x0600C038 RID: 49208 RVA: 0x0032CA18 File Offset: 0x0032AC18
	[NullableContext(2)]
	protected override void OnRefresh(object tempData)
	{
		if (tempData is int)
		{
			int num = (int)tempData;
			if (num > 0)
			{
				base.GetText(0).SetText(num.ToString(), true);
				this.SetActive(true);
				return;
			}
		}
		this.SetActive(false);
	}

	// Token: 0x0600C039 RID: 49209 RVA: 0x0032CA5B File Offset: 0x0032AC5B
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemRedDotNum";
	}

	// Token: 0x0600C03A RID: 49210 RVA: 0x0032CA62 File Offset: 0x0032AC62
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Top;
	}

	// Token: 0x02007D01 RID: 32001
	private enum EChildType
	{
		// Token: 0x0402AA1E RID: 174622
		TxtContent
	}
}
