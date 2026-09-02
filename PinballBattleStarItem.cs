using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001D56 RID: 7510
internal class PinballBattleStarItem : GridProxyAbstract<bool>
{
	// Token: 0x0600DD63 RID: 56675 RVA: 0x003B81F8 File Offset: 0x003B63F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600DD64 RID: 56676 RVA: 0x003B8240 File Offset: 0x003B6440
	public override void Refresh(bool isBright, bool isSelected, int gridIndex)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(isBright);
	}
}
