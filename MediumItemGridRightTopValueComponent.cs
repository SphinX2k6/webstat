using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019D8 RID: 6616
public class MediumItemGridRightTopValueComponent : MediumItemGridComponent
{
	// Token: 0x0600BDCD RID: 48589 RVA: 0x00324A08 File Offset: 0x00322C08
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

	// Token: 0x0600BDCE RID: 48590 RVA: 0x00324A50 File Offset: 0x00322C50
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_EnemyCount";
	}

	// Token: 0x0600BDCF RID: 48591 RVA: 0x00324A58 File Offset: 0x00322C58
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

	// Token: 0x0600BDD0 RID: 48592 RVA: 0x00324A97 File Offset: 0x00322C97
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x02007CCC RID: 31948
	private class EChildType
	{
		// Token: 0x0402A984 RID: 174468
		public const int TextContent = 0;
	}
}
