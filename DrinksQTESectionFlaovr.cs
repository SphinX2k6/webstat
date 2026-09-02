using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001023 RID: 4131
[Nullable(new byte[]
{
	0,
	1
})]
public class DrinksQTESectionFlaovr : GridProxyAbstract<IQTEFlavorInfo>
{
	// Token: 0x06006B78 RID: 27512 RVA: 0x001C2153 File Offset: 0x001C0353
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06006B79 RID: 27513 RVA: 0x001C218C File Offset: 0x001C038C
	[NullableContext(1)]
	public override void Refresh(IQTEFlavorInfo data, bool isSelected, int gridIndex)
	{
		base.SetTextureByPath(ConfigBase<DrinksConfig>.Instance.GetFlavorType(data.Type).Value.Icon, base.GetTexture(0), null, null);
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(data.Value.ToString(), true);
	}

	// Token: 0x02007404 RID: 29700
	private static class EFlavor
	{
		// Token: 0x04028200 RID: 164352
		public const int TexIcon = 0;

		// Token: 0x04028201 RID: 164353
		public const int Txt = 1;
	}
}
