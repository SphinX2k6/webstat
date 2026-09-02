using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001A38 RID: 6712
public class SmallItemGridRightTopValueComponent : SmallItemGridComponent
{
	// Token: 0x0600C03C RID: 49212 RVA: 0x0032CA70 File Offset: 0x0032AC70
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

	// Token: 0x0600C03D RID: 49213 RVA: 0x0032CAB8 File Offset: 0x0032ACB8
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_EnemyCount";
	}

	// Token: 0x0600C03E RID: 49214 RVA: 0x0032CAC0 File Offset: 0x0032ACC0
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		string text = data as string;
		if (text == null)
		{
			return;
		}
		bool flag = !string.IsNullOrEmpty(text);
		this.SetActive(flag);
		if (flag)
		{
			UUIText text2 = base.GetText(0);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(text, true);
		}
	}

	// Token: 0x0600C03F RID: 49215 RVA: 0x0032CAFF File Offset: 0x0032ACFF
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x02007D02 RID: 32002
	private class EChildType
	{
		// Token: 0x0402AA1F RID: 174623
		public const int TextContent = 0;
	}
}
