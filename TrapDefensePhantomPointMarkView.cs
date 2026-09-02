using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;

// Token: 0x02001D97 RID: 7575
public class TrapDefensePhantomPointMarkView : TrapDefenseMarkView
{
	// Token: 0x0600DF35 RID: 57141 RVA: 0x003C0EE8 File Offset: 0x003BF0E8
	public TrapDefensePhantomPointMarkView(int markId) : base(markId)
	{
	}

	// Token: 0x0600DF36 RID: 57142 RVA: 0x003C0EF1 File Offset: 0x003BF0F1
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite))
		};
	}

	// Token: 0x0600DF37 RID: 57143 RVA: 0x003C0F14 File Offset: 0x003BF114
	protected override void OnBeforeShow()
	{
		this.RefreshIcon();
	}

	// Token: 0x0600DF38 RID: 57144 RVA: 0x003C0F1C File Offset: 0x003BF11C
	private void RefreshIcon()
	{
		UUISprite sprite = base.GetSprite(0);
		TrapDefensePhantomPointMarkItem trapDefensePhantomPointMarkItem = base.GetMarkData() as TrapDefensePhantomPointMarkItem;
		if (trapDefensePhantomPointMarkItem != null && trapDefensePhantomPointMarkItem.IsActivated())
		{
			this.SetSpriteByPath("/Game/Aki/UI/UIResources/UiFight/Atlas/TowerDefense/SP_IconTowerDefenseMapIcon2.SP_IconTowerDefenseMapIcon2", sprite, true, null, delegate(bool _)
			{
				sprite.SetUIActive(true);
			});
			return;
		}
		this.SetSpriteByPath("/Game/Aki/UI/UIResources/UiFight/Atlas/TowerDefense/SP_IconTowerDefenseMapIcon1.SP_IconTowerDefenseMapIcon1", sprite, true, null, delegate(bool _)
		{
			sprite.SetUIActive(true);
		});
	}

	// Token: 0x0600DF39 RID: 57145 RVA: 0x003C0FA2 File Offset: 0x003BF1A2
	public override void OnTowerDefenseStepUpdate(ETowerDefenseEventProcessStatus status)
	{
		if (status == ETowerDefenseEventProcessStatus.Ready)
		{
			this.RefreshIcon();
		}
	}

	// Token: 0x0200812C RID: 33068
	private static class EChildComponent
	{
		// Token: 0x0402BE83 RID: 179843
		public const int Icon = 0;
	}
}
