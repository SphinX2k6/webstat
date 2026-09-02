using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019DE RID: 6622
public class MediumItemGridRoleSkillBranchComponent : MediumItemGridComponent
{
	// Token: 0x0600BDE4 RID: 48612 RVA: 0x00324EB4 File Offset: 0x003230B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BDE5 RID: 48613 RVA: 0x00324EFC File Offset: 0x003230FC
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemRoleTag";
	}

	// Token: 0x0600BDE6 RID: 48614 RVA: 0x00324F04 File Offset: 0x00323104
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		if (data is int)
		{
			int num = (int)data;
			this.SetActive(true);
			UUIItem item = base.GetItem(0);
			int num2 = (num == 0) ? 0 : 180;
			FVector fvector = new FVector(0f, (float)num2, 0f);
			FRotator frotator = FRotator.MakeFromEuler(fvector);
			item.SetUIRelativeRotation(frotator);
			return;
		}
	}

	// Token: 0x02007CD1 RID: 31953
	private class EComponent
	{
		// Token: 0x0402A98D RID: 174477
		public const int ItemTag = 0;
	}
}
