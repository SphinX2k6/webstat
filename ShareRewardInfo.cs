using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020025EA RID: 9706
public class ShareRewardInfo : UiPanelBase
{
	// Token: 0x06013047 RID: 77895 RVA: 0x00544984 File Offset: 0x00542B84
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x06013048 RID: 77896 RVA: 0x005449E0 File Offset: 0x00542BE0
	public void SetItemInfo(int id, int count)
	{
		base.GetText(1).SetText(count.ToString(), true);
		base.GetTexture(2).SetUIActive(false);
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(id);
		if (itemConfigData == null)
		{
			return;
		}
		string icon = itemConfigData.Icon;
		base.SetTextureByPath(icon, base.GetTexture(2), null, delegate(bool _)
		{
			base.GetTexture(2).SetUIActive(true);
		});
	}

	// Token: 0x0200897C RID: 35196
	private enum EChildType
	{
		// Token: 0x0402E642 RID: 190018
		TxtTip,
		// Token: 0x0402E643 RID: 190019
		TxtCount,
		// Token: 0x0402E644 RID: 190020
		Icon
	}
}
