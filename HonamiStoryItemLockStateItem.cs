using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F07 RID: 7943
public class HonamiStoryItemLockStateItem : UiPanelBase
{
	// Token: 0x0600ED26 RID: 60710 RVA: 0x0040AA2E File Offset: 0x00408C2E
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite))
		};
	}

	// Token: 0x0600ED27 RID: 60711 RVA: 0x0040AA54 File Offset: 0x00408C54
	[NullableContext(1)]
	public void RefreshMask(bool enable, HonamiStoryItemDataBase itemData, EHonamiStoryBackpackType backpackType)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite != null)
		{
			sprite.SetUIActive(enable);
		}
		if (!enable)
		{
			return;
		}
		UUIItem rootItem = this.RootItem;
		HonamiStoryModel instance = ModelBase<HonamiStoryModel>.Instance;
		EHonamiStoryBackpack backpackId = Singleton<HonamiStoryDefine>.Instance.HonamiBackpackTypeMap[backpackType];
		HonamiStoryBackpackData backPackData = instance.GetBackPackData((int)backpackId, false);
		int gridWidth = itemData.GetGridWidth();
		int gridHeight = itemData.GetGridHeight();
		int num = backPackData.GetCellWidth() * gridWidth + (gridWidth - 1) * backPackData.GetCellHorizontalInterval();
		int num2 = backPackData.GetCellHeight() * gridHeight + (gridHeight - 1) * backPackData.GetCellVerticalInterval();
		rootItem.SetWidth((float)num);
		rootItem.SetHeight((float)num2);
	}

	// Token: 0x02008260 RID: 33376
	private enum EItemLock
	{
		// Token: 0x0402C384 RID: 181124
		Mask
	}
}
