using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018C7 RID: 6343
public class CostItem : UiPanelBase
{
	// Token: 0x0600B652 RID: 46674 RVA: 0x00307B38 File Offset: 0x00305D38
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x0600B653 RID: 46675 RVA: 0x00307B94 File Offset: 0x00305D94
	[NullableContext(1)]
	public void Refresh(ICostData costData)
	{
		UUIText text = base.GetText(1);
		text.SetText(costData.Cost.ToString(), true);
		base.SetItemIcon(base.GetTexture(2), costData.ItemId, null, null);
		UUIItem uuiitem = text;
		bool bUseChangeColor = costData.Cost > costData.Count;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x0600B654 RID: 46676 RVA: 0x00307C00 File Offset: 0x00305E00
	[NullableContext(1)]
	public void RefreshCost(List<ICostData> costData)
	{
		base.SetUiActive(false);
		if (costData.Count > 0)
		{
			base.SetUiActive(true);
			ICostData costData2 = costData[0];
			this.Refresh(costData2);
		}
	}

	// Token: 0x02007C43 RID: 31811
	private enum EComponent
	{
		// Token: 0x0402A70F RID: 173839
		TipsText,
		// Token: 0x0402A710 RID: 173840
		CostText,
		// Token: 0x0402A711 RID: 173841
		CostIcon
	}
}
