using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001661 RID: 5729
public class WheelTowerResultRoundItem : UiPanelBase
{
	// Token: 0x0600A085 RID: 41093 RVA: 0x002A0814 File Offset: 0x0029EA14
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A086 RID: 41094 RVA: 0x002A085C File Offset: 0x0029EA5C
	protected override void OnStart()
	{
		this.Player = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600A087 RID: 41095 RVA: 0x002A086F File Offset: 0x0029EA6F
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer player = this.Player;
		if (player == null)
		{
			return;
		}
		player.Clear();
	}

	// Token: 0x0600A088 RID: 41096 RVA: 0x002A0884 File Offset: 0x0029EA84
	public void Refresh(bool endless, int currentRound, int totalRound)
	{
		base.SetUiActive(true);
		string textStringId = endless ? "WheelBattleResult_Endless" : "WheelBattleResult_Normal";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textStringId, new <>z__ReadOnlyArray<object>(new object[]
		{
			currentRound,
			totalRound
		}));
		LevelSequencePlayer player = this.Player;
		if (player == null)
		{
			return;
		}
		player.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x04004A26 RID: 18982
	[Nullable(2)]
	private LevelSequencePlayer Player;
}
