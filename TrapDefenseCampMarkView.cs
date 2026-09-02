using System;
using System.Collections.Generic;
using UnrealEngine;

// Token: 0x02001D93 RID: 7571
public class TrapDefenseCampMarkView : TrapDefenseMarkView
{
	// Token: 0x0600DF23 RID: 57123 RVA: 0x003C0997 File Offset: 0x003BEB97
	public TrapDefenseCampMarkView(int markId) : base(markId)
	{
	}

	// Token: 0x0600DF24 RID: 57124 RVA: 0x003C09A0 File Offset: 0x003BEBA0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite))
		};
	}

	// Token: 0x0600DF25 RID: 57125 RVA: 0x003C09C4 File Offset: 0x003BEBC4
	protected override void OnBeforeShow()
	{
		UUISprite sprite = base.GetSprite(0);
		this.SetSpriteByPath("/Game/Aki/UI/UIResources/UiFight/Atlas/TowerDefense/SP_IconTowerDefenseMapIcon3.SP_IconTowerDefenseMapIcon3", sprite, true, null, delegate(bool _)
		{
			sprite.SetUIActive(true);
		});
	}

	// Token: 0x02008127 RID: 33063
	private static class EChildComponent
	{
		// Token: 0x0402BE7E RID: 179838
		public const int Icon = 0;
	}
}
