using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001010 RID: 4112
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DrinksShowTasteItem : GridProxyAbstract<IDrinkTasteInfo>
{
	// Token: 0x06006AFB RID: 27387 RVA: 0x001BF5F2 File Offset: 0x001BD7F2
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06006AFC RID: 27388 RVA: 0x001BF62C File Offset: 0x001BD82C
	public override void Refresh(IDrinkTasteInfo data, bool isSelected, int gridIndex)
	{
		base.SetTextureByPath(ConfigBase<DrinksConfig>.Instance.GetFlavorType(data.Type).Value.Icon, base.GetTexture(0), null, null);
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(data.Value.ToString(), true);
	}
}
