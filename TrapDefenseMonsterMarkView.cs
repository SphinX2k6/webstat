using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Module.TowerDefenseEvent;
using CSharpScript.Game.Module.TrapDefense;
using UnrealEngine;

// Token: 0x02001D96 RID: 7574
public class TrapDefenseMonsterMarkView : TrapDefenseMarkView
{
	// Token: 0x0600DF30 RID: 57136 RVA: 0x003C0DD0 File Offset: 0x003BEFD0
	public TrapDefenseMonsterMarkView(int markId) : base(markId)
	{
		this.NeedUpdatePositionInner = true;
	}

	// Token: 0x0600DF31 RID: 57137 RVA: 0x003C0DE0 File Offset: 0x003BEFE0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite))
		};
	}

	// Token: 0x0600DF32 RID: 57138 RVA: 0x003C0E03 File Offset: 0x003BF003
	protected override void OnStart()
	{
		base.GetRootItem().SetAlpha(0f);
		this.RefreshIcon();
	}

	// Token: 0x0600DF33 RID: 57139 RVA: 0x003C0E1C File Offset: 0x003BF01C
	private void RefreshIcon()
	{
		TrapDefenseMonsterMarkItem trapDefenseMonsterMarkItem = base.GetMarkData() as TrapDefenseMonsterMarkItem;
		if (trapDefenseMonsterMarkItem == null || trapDefenseMonsterMarkItem.EnemyType == this.CurrentEnemyType)
		{
			return;
		}
		this.CurrentEnemyType = trapDefenseMonsterMarkItem.EnemyType;
		UUISprite sprite = base.GetSprite(0);
		if (ControllerBase<TowerDefenseEventController>.Instance.ProcessStatus == ETowerDefenseEventProcessStatus.Ready)
		{
			this.SetSpriteByPath(TrapDefenseDefine.enemyResourcePreviewRecord[trapDefenseMonsterMarkItem.EnemyType], sprite, true, null, delegate(bool _)
			{
				sprite.SetUIActive(true);
			});
			return;
		}
		this.SetSpriteByPath(TrapDefenseDefine.enemyResourceBattleRecord[trapDefenseMonsterMarkItem.EnemyType], sprite, true, null, delegate(bool _)
		{
			sprite.SetUIActive(true);
		});
	}

	// Token: 0x0600DF34 RID: 57140 RVA: 0x003C0ED8 File Offset: 0x003BF0D8
	[NullableContext(1)]
	public override void UpdatePosition(float scale, Vector2D centerOffset)
	{
		this.RefreshIcon();
		base.UpdatePosition(scale, centerOffset);
	}

	// Token: 0x04006B56 RID: 27478
	private ETrapDefenseEnemyType CurrentEnemyType;

	// Token: 0x0200812A RID: 33066
	private static class EChildComponent
	{
		// Token: 0x0402BE81 RID: 179841
		public const int Icon = 0;
	}
}
