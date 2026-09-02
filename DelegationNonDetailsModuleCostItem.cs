using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020013C6 RID: 5062
public class DelegationNonDetailsModuleCostItem : UiPanelBase
{
	// Token: 0x06008BCF RID: 35791 RVA: 0x0024CB8F File Offset: 0x0024AD8F
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture))
		};
	}

	// Token: 0x06008BD0 RID: 35792 RVA: 0x0024CBC8 File Offset: 0x0024ADC8
	public void UpdateItem(int id, int count)
	{
		this.ItemId = id;
		this.Count = count;
		base.SetItemIcon(base.GetTexture(1), id, null, null);
		base.GetText(0).SetText(count.ToString(), true);
		this.RefreshCountEnableState();
	}

	// Token: 0x06008BD1 RID: 35793 RVA: 0x0024CC18 File Offset: 0x0024AE18
	public void RefreshCountEnableState()
	{
		UUIText text = base.GetText(0);
		UUIItem uuiitem = text;
		bool bUseChangeColor = !this.IsEnough;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x17000BCF RID: 3023
	// (get) Token: 0x06008BD2 RID: 35794 RVA: 0x0024CC4A File Offset: 0x0024AE4A
	public bool IsEnough
	{
		get
		{
			return this.ItemId != 0 && ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ItemId, 0) >= this.Count;
		}
	}

	// Token: 0x04004132 RID: 16690
	private int ItemId;

	// Token: 0x04004133 RID: 16691
	private int Count;

	// Token: 0x0200779B RID: 30619
	private static class ECostItemDefine
	{
		// Token: 0x040292B8 RID: 168632
		public const int CostText = 0;

		// Token: 0x040292B9 RID: 168633
		public const int Icon = 1;
	}
}
