using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F0A RID: 7946
public class HonamiStoryItemGridPlacementItem : UiPanelBase
{
	// Token: 0x0600ED30 RID: 60720 RVA: 0x0040ABEC File Offset: 0x00408DEC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUISprite))
		};
	}

	// Token: 0x0600ED31 RID: 60721 RVA: 0x0040AC28 File Offset: 0x00408E28
	public void Refresh()
	{
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		if (backpackLogicState != EHonamiStoryBackpackLogicState.TipsWithPlugins && backpackLogicState != EHonamiStoryBackpackLogicState.DraggingPlugins)
		{
			return;
		}
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(backpackLogicState == EHonamiStoryBackpackLogicState.TipsWithPlugins);
		}
		UUISprite sprite = base.GetSprite(1);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(backpackLogicState == EHonamiStoryBackpackLogicState.DraggingPlugins);
	}

	// Token: 0x02008263 RID: 33379
	private enum EPlacement
	{
		// Token: 0x0402C38B RID: 181131
		TipsPlacement,
		// Token: 0x0402C38C RID: 181132
		DragPlacementSprite
	}
}
