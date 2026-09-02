using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002C06 RID: 11270
public class TowerStarsSimpleItem : GridProxyAbstract<bool>
{
	// Token: 0x060167C2 RID: 92098 RVA: 0x00640064 File Offset: 0x0063E264
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

	// Token: 0x060167C3 RID: 92099 RVA: 0x006400AC File Offset: 0x0063E2AC
	public override void Refresh(bool data, bool isSelected, int gridIndex)
	{
		base.GetItem(0).SetUIActive(data);
	}

	// Token: 0x02008F04 RID: 36612
	private enum EChildType
	{
		// Token: 0x040300AA RID: 196778
		StarItem
	}
}
