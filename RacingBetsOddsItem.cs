using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002727 RID: 10023
public class RacingBetsOddsItem : UiPanelBase
{
	// Token: 0x06013C4B RID: 80971 RVA: 0x0057FF8C File Offset: 0x0057E18C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIArtText)),
			new ValueTuple<int, Type>(1, typeof(UUIArtText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06013C4C RID: 80972 RVA: 0x0057FFFC File Offset: 0x0057E1FC
	protected override void OnBeforeShow()
	{
		this.RefreshUi(this.OddsNumber, this.Rank, this.IsBet);
	}

	// Token: 0x06013C4D RID: 80973 RVA: 0x00580018 File Offset: 0x0057E218
	public void RefreshUi(int odds, int rank, bool isBet)
	{
		this.OddsNumber = odds;
		this.Rank = rank;
		this.IsBet = isBet;
		if (!base.IsShowOrShowing)
		{
			return;
		}
		base.GetArtText(0).SetText(odds.ToString());
		base.GetArtText(1).SetText(rank.ToString());
		base.GetItem(2).SetUIActive(rank > 0);
		base.GetItem(3).SetUIActive(isBet);
	}

	// Token: 0x06013C4E RID: 80974 RVA: 0x00580086 File Offset: 0x0057E286
	public void SetItemOffset(FVector2D position)
	{
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetAnchorOffset(position);
	}

	// Token: 0x06013C4F RID: 80975 RVA: 0x00580099 File Offset: 0x0057E299
	public void SetVisible(bool visible)
	{
		this.SetActive(visible);
	}

	// Token: 0x040099EB RID: 39403
	private int OddsNumber;

	// Token: 0x040099EC RID: 39404
	private int Rank;

	// Token: 0x040099ED RID: 39405
	private bool IsBet;

	// Token: 0x02008ACC RID: 35532
	private class EComponent
	{
		// Token: 0x0402ECB6 RID: 191670
		public const int OddsText = 0;

		// Token: 0x0402ECB7 RID: 191671
		public const int RankText = 1;

		// Token: 0x0402ECB8 RID: 191672
		public const int RankItem = 2;

		// Token: 0x0402ECB9 RID: 191673
		public const int BetsInfo = 3;
	}
}
