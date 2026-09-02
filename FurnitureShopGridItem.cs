using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020010A4 RID: 4260
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FurnitureShopGridItem : GridProxyAbstract<FurnitureShopGridItemProxy>
{
	// Token: 0x06006F0E RID: 28430 RVA: 0x001CE53C File Offset: 0x001CC73C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06006F0F RID: 28431 RVA: 0x001CE596 File Offset: 0x001CC796
	protected override void OnStart()
	{
		this.PayShopItem = new GameplayShopItem();
		this.PayShopItem.CreateThenShowByActor(base.GetItem(0).GetOwner(), null);
	}

	// Token: 0x06006F10 RID: 28432 RVA: 0x001CE5BB File Offset: 0x001CC7BB
	[NullableContext(1)]
	public override void Refresh(FurnitureShopGridItemProxy data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.PayShopItem.RefreshByData(this.Data.FurnitureShopItemProxy);
		this.RefreshAtmosphereText();
	}

	// Token: 0x06006F11 RID: 28433 RVA: 0x001CE5E0 File Offset: 0x001CC7E0
	public void RefreshAtmosphereText()
	{
		base.GetText(2).SetText(this.Data.AtmosphereText, true);
	}

	// Token: 0x0400351C RID: 13596
	private GameplayShopItem PayShopItem;

	// Token: 0x0400351D RID: 13597
	private FurnitureShopGridItemProxy Data;
}
