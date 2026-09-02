using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001012 RID: 4114
public class DrinksBubbleItem : UiPanelBase
{
	// Token: 0x06006B04 RID: 27396 RVA: 0x001BF92E File Offset: 0x001BDB2E
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture))
		};
	}

	// Token: 0x06006B05 RID: 27397 RVA: 0x001BF951 File Offset: 0x001BDB51
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06006B06 RID: 27398 RVA: 0x001BF964 File Offset: 0x001BDB64
	public void SetIsVisible(bool value, bool isEnd = false)
	{
		bool flag = base.IsUiActiveInHierarchy();
		if ((value == flag && !value) || isEnd)
		{
			return;
		}
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.StopSequenceByKey("Start", false, false);
		}
		LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
		if (sequencePlayer2 != null)
		{
			sequencePlayer2.StopSequenceByKey("Close", false, false);
		}
		LevelSequencePlayer sequencePlayer3 = this.SequencePlayer;
		if (sequencePlayer3 == null)
		{
			return;
		}
		sequencePlayer3.PlayLevelSequenceByName(value ? "Start" : "Close", false, null, false);
	}

	// Token: 0x06006B07 RID: 27399 RVA: 0x001BF9E4 File Offset: 0x001BDBE4
	public void Update(bool isBatching, int id)
	{
		string path;
		if (isBatching)
		{
			path = ConfigBase<DrinksConfig>.Instance.GetBatching(id).Value.Icon;
		}
		else
		{
			path = ConfigBase<DrinksConfig>.Instance.GetDrinkBase(id).Value.DrinkIcon;
		}
		base.SetTextureByPath(path, base.GetTexture(0), null, null);
	}

	// Token: 0x040032E0 RID: 13024
	[Nullable(2)]
	protected LevelSequencePlayer SequencePlayer;

	// Token: 0x020073F3 RID: 29683
	private static class EBubble
	{
		// Token: 0x040281C5 RID: 164293
		public const int Icon = 0;
	}
}
