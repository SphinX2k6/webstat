using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001687 RID: 5767
public class WheelTowerSeasonRewardInfoItem : UiPanelBase
{
	// Token: 0x0600A103 RID: 41219 RVA: 0x002A3A90 File Offset: 0x002A1C90
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A104 RID: 41220 RVA: 0x002A3B1C File Offset: 0x002A1D1C
	[NullableContext(2)]
	public void Refresh(TItem data, string previewIcon = null)
	{
		string path;
		if (!string.IsNullOrEmpty(previewIcon))
		{
			path = previewIcon;
		}
		else
		{
			int itemId = data.ItemData.ItemId;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
			if (itemConfigData == null)
			{
				return;
			}
			path = itemConfigData.Icon;
		}
		base.SetTextureByPath(path, base.GetTexture(0), null, null);
		base.SetTextureByPath(path, base.GetTexture(1), null, null);
		base.SetTextureByPath(path, base.GetTexture(2), null, null);
	}
}
