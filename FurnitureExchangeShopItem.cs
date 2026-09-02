using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001089 RID: 4233
[NullableContext(1)]
[Nullable(0)]
public class FurnitureExchangeShopItem : UiPanelBase
{
	// Token: 0x06006E71 RID: 28273 RVA: 0x001CC5C4 File Offset: 0x001CA7C4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x06006E72 RID: 28274 RVA: 0x001CC61E File Offset: 0x001CA81E
	protected override void OnStart()
	{
		this.PayShopItem = new GameplayShopItem();
		this.PayShopItem.CreateThenShowByActor(base.GetItem(0).GetOwner(), null);
	}

	// Token: 0x06006E73 RID: 28275 RVA: 0x001CC643 File Offset: 0x001CA843
	public void RefreshByData(FurnitureShopExchangeItemProxy data)
	{
		this.ShopItemProxy = data;
		this.PayShopItem.RefreshByData(this.ShopItemProxy.FurnitureShopItemProxy);
		this.RefreshAtmosphereText();
	}

	// Token: 0x06006E74 RID: 28276 RVA: 0x001CC668 File Offset: 0x001CA868
	public void RefreshAtmosphereText()
	{
		base.GetText(2).SetText(this.ShopItemProxy.AtmosphereText, true);
	}

	// Token: 0x040034A5 RID: 13477
	private FurnitureShopExchangeItemProxy ShopItemProxy = new FurnitureShopExchangeItemProxy();

	// Token: 0x040034A6 RID: 13478
	[Nullable(2)]
	private GameplayShopItem PayShopItem;
}
