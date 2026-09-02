using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002717 RID: 10007
public class RacingBetsCostItem : UiPanelBase
{
	// Token: 0x06013BD8 RID: 80856 RVA: 0x0057E724 File Offset: 0x0057C924
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x06013BD9 RID: 80857 RVA: 0x0057E780 File Offset: 0x0057C980
	public void RefreshUi(int itemId, int count)
	{
		InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
		ItemConfig itemConfig = (instance != null) ? instance.GetItemConfigData(itemId) : null;
		if (itemConfig == null)
		{
			return;
		}
		base.SetTextureShowUntilLoaded(itemConfig.Icon, base.GetTexture(2), null);
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(count.ToString(), true);
	}

	// Token: 0x02008AB7 RID: 35511
	private enum EComponent
	{
		// Token: 0x0402EC5D RID: 191581
		TipsItem,
		// Token: 0x0402EC5E RID: 191582
		CostText,
		// Token: 0x0402EC5F RID: 191583
		CostIcon
	}
}
