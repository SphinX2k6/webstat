using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001665 RID: 5733
public class WheelTowerResultScoreList : UiPanelBase
{
	// Token: 0x0600A091 RID: 41105 RVA: 0x002A0954 File Offset: 0x0029EB54
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A092 RID: 41106 RVA: 0x002A099C File Offset: 0x0029EB9C
	protected override void OnStart()
	{
		UUIVerticalLayout uuiverticalLayout = this.RootItem.GetOwner().GetComponentByClass(UUIVerticalLayout.StaticClass()) as UUIVerticalLayout;
		if (uuiverticalLayout != null)
		{
			this.ScoreList = new GenericLayout<WheelTowerResultScoreList.ScoreInfoItem, WheelTowerResultScoreInfoItemData>(uuiverticalLayout, new Func<WheelTowerResultScoreList.ScoreInfoItem>(this.CreateScoreInfoItem), null, false, true);
		}
	}

	// Token: 0x0600A093 RID: 41107 RVA: 0x002A09E7 File Offset: 0x0029EBE7
	[NullableContext(1)]
	private WheelTowerResultScoreList.ScoreInfoItem CreateScoreInfoItem()
	{
		return new WheelTowerResultScoreList.ScoreInfoItem();
	}

	// Token: 0x0600A094 RID: 41108 RVA: 0x002A09F0 File Offset: 0x0029EBF0
	public void Refresh(int totalScore, int roundScore)
	{
		base.SetUiActive(true);
		WheelTowerModel instance = ModelBase<WheelTowerModel>.Instance;
		GenericLayout<WheelTowerResultScoreList.ScoreInfoItem, WheelTowerResultScoreInfoItemData> scoreList = this.ScoreList;
		if (scoreList == null)
		{
			return;
		}
		scoreList.RefreshByData(new <>z__ReadOnlyArray<WheelTowerResultScoreInfoItemData>(new WheelTowerResultScoreInfoItemData[]
		{
			new WheelTowerResultScoreInfoItemData
			{
				Desc = "WheelBattleResult_CurTotalScore",
				Score = totalScore.ToString(),
				ScoreLevel = instance.GetTotalScoreLevel(totalScore, null, null)
			},
			new WheelTowerResultScoreInfoItemData
			{
				Desc = "WheelBattleResult_CurScore",
				Score = roundScore.ToString(),
				ScoreLevel = instance.GetRoundScoreLevel(roundScore)
			}
		}), null, false);
	}

	// Token: 0x04004A30 RID: 18992
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerResultScoreList.ScoreInfoItem, WheelTowerResultScoreInfoItemData> ScoreList;

	// Token: 0x020079F8 RID: 31224
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	private class ScoreInfoItem : GridProxyAbstract<WheelTowerResultScoreInfoItemData>
	{
		// Token: 0x06047818 RID: 292888 RVA: 0x0130E5C4 File Offset: 0x0130C7C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06047819 RID: 292889 RVA: 0x0130E64E File Offset: 0x0130C84E
		protected override void OnStart()
		{
			this.ScoreItem = new WheelTowerScoreItem(this, base.GetItem(1));
			this.Player = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0604781A RID: 292890 RVA: 0x0130E674 File Offset: 0x0130C874
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer player = this.Player;
			if (player == null)
			{
				return;
			}
			player.Clear();
		}

		// Token: 0x0604781B RID: 292891 RVA: 0x0130E688 File Offset: 0x0130C888
		[NullableContext(1)]
		public override void Refresh(WheelTowerResultScoreInfoItemData data, bool isSelected, int gridIndex)
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.ShowTextNew(data.Desc);
			}
			UUIText text2 = base.GetText(2);
			if (text2 != null)
			{
				text2.SetText(data.Score, true);
			}
			WheelTowerScoreItem scoreItem = this.ScoreItem;
			if (scoreItem != null)
			{
				scoreItem.Refresh(data.ScoreLevel);
			}
			LevelSequencePlayer player = this.Player;
			if (player == null)
			{
				return;
			}
			player.PlaySequencePurely("Start", false, false, null, null, false);
		}

		// Token: 0x04029DDC RID: 171484
		private WheelTowerScoreItem ScoreItem;

		// Token: 0x04029DDD RID: 171485
		private LevelSequencePlayer Player;
	}
}
