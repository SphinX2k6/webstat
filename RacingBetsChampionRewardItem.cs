using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002716 RID: 10006
public class RacingBetsChampionRewardItem : UiPanelBase
{
	// Token: 0x06013BD4 RID: 80852 RVA: 0x0057E630 File Offset: 0x0057C830
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickTipButton))
		};
	}

	// Token: 0x06013BD5 RID: 80853 RVA: 0x0057E6B0 File Offset: 0x0057C8B0
	public void Refresh(int itemId)
	{
		this.ItemId = itemId;
		UUITexture texture = base.GetTexture(1);
		if (texture != null)
		{
			base.SetItemIcon(texture, this.ItemId, null, null);
		}
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText("x1", true);
	}

	// Token: 0x06013BD6 RID: 80854 RVA: 0x0057E6FD File Offset: 0x0057C8FD
	private void OnClickTipButton()
	{
		if (this.ItemId > 0)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemId, true, null);
		}
	}

	// Token: 0x040099C1 RID: 39361
	private int ItemId;

	// Token: 0x02008AB6 RID: 35510
	private class EComponent
	{
		// Token: 0x0402EC59 RID: 191577
		public const int TipButton = 0;

		// Token: 0x0402EC5A RID: 191578
		public const int ItemIcon = 1;

		// Token: 0x0402EC5B RID: 191579
		public const int ItemCount = 2;
	}
}
