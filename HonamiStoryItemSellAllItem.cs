using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F08 RID: 7944
public class HonamiStoryItemSellAllItem : UiPanelBase
{
	// Token: 0x0600ED29 RID: 60713 RVA: 0x0040AAED File Offset: 0x00408CED
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite))
		};
	}

	// Token: 0x0600ED2A RID: 60714 RVA: 0x0040AB10 File Offset: 0x00408D10
	public void SetSelected(bool value)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(value);
	}

	// Token: 0x02008261 RID: 33377
	private enum ESell
	{
		// Token: 0x0402C386 RID: 181126
		Sprite
	}
}
