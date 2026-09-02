using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F09 RID: 7945
public class HonamiStoryItemSellValueItem : UiPanelBase
{
	// Token: 0x0600ED2C RID: 60716 RVA: 0x0040AB2C File Offset: 0x00408D2C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x0600ED2D RID: 60717 RVA: 0x0040AB68 File Offset: 0x00408D68
	protected override void OnStart()
	{
		int activityId = ModelBase<HonamiStoryModel>.Instance.ActivityId;
		int outCoinItemId = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryActivityConfig(activityId).Value.OutCoinItemId;
		base.SetItemIcon(base.GetTexture(0), outCoinItemId, null, null);
	}

	// Token: 0x0600ED2E RID: 60718 RVA: 0x0040ABB8 File Offset: 0x00408DB8
	[NullableContext(1)]
	public void Refresh(HonamiStoryItemDataBase itemData)
	{
		int sellPrice = itemData.GetSellPrice();
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(HonamiStoryUtil.GetPriceNumFormat(sellPrice), true);
	}

	// Token: 0x02008262 RID: 33378
	private enum EValue
	{
		// Token: 0x0402C388 RID: 181128
		Icon,
		// Token: 0x0402C389 RID: 181129
		Txt
	}
}
