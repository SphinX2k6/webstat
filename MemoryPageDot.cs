using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C7D RID: 7293
public class MemoryPageDot : GridProxyAbstract<bool>
{
	// Token: 0x0600D51E RID: 54558 RVA: 0x0038E0A4 File Offset: 0x0038C2A4
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

	// Token: 0x0600D51F RID: 54559 RVA: 0x0038E0EC File Offset: 0x0038C2EC
	public override void Refresh(bool data, bool isSelected, int gridIndex)
	{
		UUIItem item = base.GetItem(0);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(data);
	}

	// Token: 0x02007FCD RID: 32717
	private class EDotItem
	{
		// Token: 0x0402B7F4 RID: 178164
		public const int Dot = 0;
	}
}
