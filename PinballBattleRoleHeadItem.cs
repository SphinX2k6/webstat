using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001D6A RID: 7530
internal class PinballBattleRoleHeadItem : GridProxyAbstract<int>
{
	// Token: 0x0600DD98 RID: 56728 RVA: 0x003B9654 File Offset: 0x003B7854
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600DD99 RID: 56729 RVA: 0x003B969C File Offset: 0x003B789C
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		base.SetTextureShowUntilLoaded(ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(data).Value.Icon, base.GetTexture(0), null);
	}
}
