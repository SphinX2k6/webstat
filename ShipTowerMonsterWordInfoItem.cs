using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020029C3 RID: 10691
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerMonsterWordInfoItem : GridProxyAbstract<ShipTowerMonsterWordInfoItemData>
{
	// Token: 0x06015522 RID: 87330 RVA: 0x005E8A04 File Offset: 0x005E6C04
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06015523 RID: 87331 RVA: 0x005E8A5E File Offset: 0x005E6C5E
	public override void Refresh(ShipTowerMonsterWordInfoItemData data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x06015524 RID: 87332 RVA: 0x005E8A68 File Offset: 0x005E6C68
	public void Refresh(ShipTowerMonsterWordInfoItemData data)
	{
		bool flag = !string.IsNullOrEmpty(data.IconPath);
		UUISprite sprite = base.GetSprite(1);
		UUIItem item = base.GetItem(0);
		if (flag)
		{
			this.SetSpriteByPath(data.IconPath, sprite, false, null, null);
		}
		item.SetUIActive(flag);
		base.GetText(2).SetText(data.Desc, true);
	}

	// Token: 0x02008D1E RID: 36126
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F778 RID: 194424
		public const int ItemIconRoot = 0;

		// Token: 0x0402F779 RID: 194425
		public const int SpriteIcon = 1;

		// Token: 0x0402F77A RID: 194426
		public const int TxtDesc = 2;
	}
}
