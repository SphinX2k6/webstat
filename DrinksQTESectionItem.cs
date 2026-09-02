using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001022 RID: 4130
public class DrinksQTESectionItem : UiPanelBase
{
	// Token: 0x06006B72 RID: 27506 RVA: 0x001C1F9C File Offset: 0x001C019C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06006B73 RID: 27507 RVA: 0x001C200C File Offset: 0x001C020C
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.Layout = new GenericLayout<DrinksQTESectionFlaovr, IQTEFlavorInfo>(base.GetHorizontalLayout(2), new Func<DrinksQTESectionFlaovr>(this.CreateFlavor), null, false, true);
	}

	// Token: 0x06006B74 RID: 27508 RVA: 0x001C2040 File Offset: 0x001C0240
	public void ApplyDrinkData(int drinkId)
	{
		DrinksDrinkBase? drinkBase = ConfigBase<DrinksConfig>.Instance.GetDrinkBase(drinkId);
		List<IQTEFlavorInfo> list = new List<IQTEFlavorInfo>();
		foreach (KeyValuePair<int, int> keyValuePair in drinkBase.Value.Flavor())
		{
			QTEFlavorInfo item = new QTEFlavorInfo
			{
				Type = (EDrinksFlavorType)keyValuePair.Key,
				Value = keyValuePair.Value
			};
			list.Add(item);
		}
		this.Layout.RefreshByData(list, null, false);
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetAlpha(1f);
	}

	// Token: 0x06006B75 RID: 27509 RVA: 0x001C20F4 File Offset: 0x001C02F4
	public void SetIsSelected(bool value)
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetAlpha(value ? 1f : 0.5f);
		}
		if (value)
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
	}

	// Token: 0x06006B76 RID: 27510 RVA: 0x001C2144 File Offset: 0x001C0344
	[NullableContext(1)]
	private DrinksQTESectionFlaovr CreateFlavor()
	{
		return new DrinksQTESectionFlaovr();
	}

	// Token: 0x0400330B RID: 13067
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<DrinksQTESectionFlaovr, IQTEFlavorInfo> Layout;

	// Token: 0x0400330C RID: 13068
	[Nullable(2)]
	protected LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02007403 RID: 29699
	private static class ESection
	{
		// Token: 0x040281FC RID: 164348
		public const int PanelHighLight = 0;

		// Token: 0x040281FD RID: 164349
		public const int TxtContent = 1;

		// Token: 0x040281FE RID: 164350
		public const int FlavorLayout = 2;

		// Token: 0x040281FF RID: 164351
		public const int FlavorItem = 3;
	}
}
