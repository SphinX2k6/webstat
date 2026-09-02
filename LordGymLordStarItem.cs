using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002206 RID: 8710
public class LordGymLordStarItem : GridProxyAbstract<bool>
{
	// Token: 0x06010709 RID: 67337 RVA: 0x0047D8CC File Offset: 0x0047BACC
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

	// Token: 0x0601070A RID: 67338 RVA: 0x0047D914 File Offset: 0x0047BB14
	public override void Refresh(bool data, bool isSelected, int gridIndex)
	{
		UUIItem item = base.GetItem(0);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(data);
	}

	// Token: 0x020084D4 RID: 34004
	private class EComponent
	{
		// Token: 0x0402D005 RID: 184325
		public const int ActiveStarItem = 0;
	}
}
