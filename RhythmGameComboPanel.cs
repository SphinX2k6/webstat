using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001140 RID: 4416
public class RhythmGameComboPanel : UiPanelBase
{
	// Token: 0x0600741A RID: 29722 RVA: 0x001E4EDC File Offset: 0x001E30DC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600741B RID: 29723 RVA: 0x001E4F45 File Offset: 0x001E3145
	protected override void OnBeforeCreate()
	{
		this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIActive(false);
		}
		this.TextComboNum = base.GetText(1);
	}

	// Token: 0x0600741C RID: 29724 RVA: 0x001E4F78 File Offset: 0x001E3178
	public void SetCombo(int combo)
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem != null && !rootItem.bIsUIActive && combo > 0)
		{
			UUIItem rootItem2 = this.RootItem;
			if (rootItem2 != null)
			{
				rootItem2.SetUIActive(true);
			}
		}
		if (combo > 0)
		{
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.PlayLevelSequenceByName((this.LastCombo > 0) ? "Up" : "Start", false, null, false);
			}
			UUIText textComboNum = this.TextComboNum;
			if (textComboNum != null)
			{
				textComboNum.SetText(combo.ToString(), true);
			}
		}
		else if (this.LastCombo > 0)
		{
			LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
			if (sequencePlayer2 != null)
			{
				sequencePlayer2.PlayLevelSequenceByName("Close", false, null, false);
			}
		}
		this.LastCombo = combo;
	}

	// Token: 0x040037E8 RID: 14312
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x040037E9 RID: 14313
	[Nullable(2)]
	private UUIText TextComboNum;

	// Token: 0x040037EA RID: 14314
	private int LastCombo;

	// Token: 0x020074C7 RID: 29895
	private enum EViewComponent
	{
		// Token: 0x04028522 RID: 165154
		TextCombo,
		// Token: 0x04028523 RID: 165155
		TextComboNum
	}
}
