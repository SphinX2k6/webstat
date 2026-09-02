using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001D79 RID: 7545
public class PinballBattleReviveRoleHeadItem : GridProxyAbstract<int>
{
	// Token: 0x0600DDDE RID: 56798 RVA: 0x003BA758 File Offset: 0x003B8958
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

	// Token: 0x0600DDDF RID: 56799 RVA: 0x003BA7A0 File Offset: 0x003B89A0
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		base.SetTextureShowUntilLoaded(ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(data).Value.CircleIcon, base.GetTexture(0), null);
	}
}
