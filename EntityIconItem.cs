using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020025DA RID: 9690
[NullableContext(2)]
[Nullable(0)]
public class EntityIconItem : UiPanelBase
{
	// Token: 0x06012F1B RID: 77595 RVA: 0x0053D4DE File Offset: 0x0053B6DE
	public EntityIconItem(UUIItem item)
	{
		this.Item = item;
		this.UiSequencePlayer = new LevelSequencePlayer(item);
	}

	// Token: 0x06012F1C RID: 77596 RVA: 0x0053D4F9 File Offset: 0x0053B6F9
	public UUIItem GetItsItem()
	{
		return this.Item;
	}

	// Token: 0x06012F1D RID: 77597 RVA: 0x0053D501 File Offset: 0x0053B701
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06012F1E RID: 77598 RVA: 0x0053D53A File Offset: 0x0053B73A
	public void InitSpr()
	{
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x06012F1F RID: 77599 RVA: 0x0053D564 File Offset: 0x0053B764
	public void UpdateNowIcon(ESprColor toColor)
	{
		switch (toColor)
		{
		case ESprColor.None:
			if (this.ItsColor == ESprColor.Green)
			{
				this.UiSequencePlayer.StopCurrentSequence(false, true);
				this.UiSequencePlayer.PlayLevelSequenceByName("GtoN", false, null, false);
				this.ItsColor = ESprColor.None;
				return;
			}
			if (this.ItsColor == ESprColor.Yellow)
			{
				this.UiSequencePlayer.StopCurrentSequence(false, true);
				this.UiSequencePlayer.PlayLevelSequenceByName("YtoN", false, null, false);
				this.ItsColor = ESprColor.None;
			}
			break;
		case ESprColor.Yellow:
			if (this.ItsColor == ESprColor.None)
			{
				this.UiSequencePlayer.StopCurrentSequence(false, true);
				this.UiSequencePlayer.PlayLevelSequenceByName("NtoY", false, null, false);
				this.ItsColor = ESprColor.Yellow;
				return;
			}
			if (this.ItsColor == ESprColor.Green)
			{
				this.UiSequencePlayer.StopCurrentSequence(false, true);
				this.UiSequencePlayer.PlayLevelSequenceByName("GtoY", false, null, false);
				this.ItsColor = ESprColor.Yellow;
				return;
			}
			break;
		case ESprColor.Green:
			if (this.ItsColor == ESprColor.None)
			{
				this.UiSequencePlayer.StopCurrentSequence(false, true);
				this.UiSequencePlayer.PlayLevelSequenceByName("NtoG", false, null, false);
				this.ItsColor = ESprColor.Green;
				return;
			}
			if (this.ItsColor == ESprColor.Yellow)
			{
				this.UiSequencePlayer.StopCurrentSequence(false, true);
				this.UiSequencePlayer.PlayLevelSequenceByName("YtoG", false, null, false);
				this.ItsColor = ESprColor.Green;
				return;
			}
			break;
		default:
			return;
		}
	}

	// Token: 0x040093E5 RID: 37861
	protected LevelSequencePlayer UiSequencePlayer;

	// Token: 0x040093E6 RID: 37862
	protected UUIItem Item;

	// Token: 0x040093E7 RID: 37863
	protected ESprColor ItsColor;

	// Token: 0x02008943 RID: 35139
	[NullableContext(0)]
	private enum EItemIconType
	{
		// Token: 0x0402E506 RID: 189702
		SprGreen,
		// Token: 0x0402E507 RID: 189703
		SprYellow
	}
}
