using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002774 RID: 10100
public class RogueBattleStarItem : GridProxyAbstract<bool>
{
	// Token: 0x06013ED2 RID: 81618 RVA: 0x0058DC0C File Offset: 0x0058BE0C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06013ED3 RID: 81619 RVA: 0x0058DC66 File Offset: 0x0058BE66
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		base.GetSprite(0).SetUIActive(true);
	}

	// Token: 0x06013ED4 RID: 81620 RVA: 0x0058DC86 File Offset: 0x0058BE86
	public override void Refresh(bool isOn, bool isSelected, int gridIndex)
	{
		base.GetSprite(1).SetUIActive(isOn);
		base.GetItem(2).SetUIActive(false);
	}

	// Token: 0x06013ED5 RID: 81621 RVA: 0x0058DCA4 File Offset: 0x0058BEA4
	public void SetPreviewAnimOn(bool bOn)
	{
		base.GetSprite(1).SetUIActive(bOn);
		base.GetItem(2).SetUIActive(bOn);
		if (bOn)
		{
			if (this.LevelSequencePlayer.GetCurrentSequence() == "Light")
			{
				this.LevelSequencePlayer.ReplaySequenceByKey("Light");
				return;
			}
			this.LevelSequencePlayer.StopPlayingSequence(false, true);
			this.LevelSequencePlayer.PlayLevelSequenceByName("Light", false, null, false);
			return;
		}
		else
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.StopSequenceByKey("Light", false, false);
			return;
		}
	}

	// Token: 0x04009B18 RID: 39704
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;
}
