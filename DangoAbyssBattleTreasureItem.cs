using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001AD7 RID: 6871
public class DangoAbyssBattleTreasureItem : UiPanelBase
{
	// Token: 0x0600C5BE RID: 50622 RVA: 0x00343A16 File Offset: 0x00341C16
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite))
		};
	}

	// Token: 0x0600C5BF RID: 50623 RVA: 0x00343A39 File Offset: 0x00341C39
	public void RefreshByCurrentPercentage(float currentPercentage)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(this.NeedPercentage <= currentPercentage);
	}

	// Token: 0x04005EC4 RID: 24260
	public float NeedPercentage;

	// Token: 0x04005EC5 RID: 24261
	public int RewardId;

	// Token: 0x02007DAC RID: 32172
	private enum ERewardTreasureItemComponent
	{
		// Token: 0x0402ACD4 RID: 175316
		LightSprite
	}
}
