using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EFF RID: 7935
public class HonamiStoryLevelPowerItem : UiPanelBase
{
	// Token: 0x0600ECE0 RID: 60640 RVA: 0x00408798 File Offset: 0x00406998
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x0600ECE1 RID: 60641 RVA: 0x0040881E File Offset: 0x00406A1E
	public void RefreshPowerVisible(bool isVisible)
	{
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(isVisible);
	}

	// Token: 0x02008256 RID: 33366
	private enum EPower
	{
		// Token: 0x0402C34F RID: 181071
		Txt,
		// Token: 0x0402C350 RID: 181072
		SpriteNumBg,
		// Token: 0x0402C351 RID: 181073
		SpriteLevelIcon,
		// Token: 0x0402C352 RID: 181074
		SpriteCircle,
		// Token: 0x0402C353 RID: 181075
		PanelNum
	}
}
