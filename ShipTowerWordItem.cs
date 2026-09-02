using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020029ED RID: 10733
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerWordItem : GridProxyAbstract<ShipTowerWordItemData>
{
	// Token: 0x06015687 RID: 87687 RVA: 0x005EE654 File Offset: 0x005EC854
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite))
		};
	}

	// Token: 0x06015688 RID: 87688 RVA: 0x005EE6B0 File Offset: 0x005EC8B0
	public override void Refresh(ShipTowerWordItemData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		base.GetText(1).SetText(data.Title, true);
		if (!string.IsNullOrEmpty(data.TitleColor))
		{
			FColor color = FColor.FromHex(data.TitleColor);
			base.GetText(1).SetColor(color);
			base.GetSprite(0).SetColor(color);
		}
		this.SetSpriteByPath(data.IconPath, base.GetSprite(2), false, null, null);
	}

	// Token: 0x0400A4C6 RID: 42182
	private ShipTowerWordItemData ItemData;

	// Token: 0x02008D65 RID: 36197
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F8BA RID: 194746
		public const int SpriteBg = 0;

		// Token: 0x0402F8BB RID: 194747
		public const int TxtName = 1;

		// Token: 0x0402F8BC RID: 194748
		public const int SpriteIcon = 2;
	}
}
