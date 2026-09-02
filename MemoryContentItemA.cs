using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020013F0 RID: 5104
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MemoryContentItemA : GridProxyAbstract<IMemoryItemData>
{
	// Token: 0x06008D7A RID: 36218 RVA: 0x00253390 File Offset: 0x00251590
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite))
		};
	}

	// Token: 0x06008D7B RID: 36219 RVA: 0x002533EC File Offset: 0x002515EC
	public override void Refresh(IMemoryItemData data, bool isSelected, int gridIndex)
	{
		UUISprite sprite = base.GetSprite(2);
		this.SetSpriteByPath(data.IconPath ?? "", sprite, false, null, null);
		base.GetText(1).ShowTextNew(data.Title);
		base.GetText(0).SetText(data.Content ?? "", true);
	}
}
