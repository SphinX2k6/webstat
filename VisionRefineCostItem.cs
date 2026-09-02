using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001818 RID: 6168
public class VisionRefineCostItem : UiPanelBase
{
	// Token: 0x0600AFB7 RID: 44983 RVA: 0x002ED864 File Offset: 0x002EBA64
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture))
		};
	}

	// Token: 0x0600AFB8 RID: 44984 RVA: 0x002ED8C0 File Offset: 0x002EBAC0
	public void SetCost(int itemId, int costCount)
	{
		base.SetItemIcon(base.GetTexture(2), itemId, null, null);
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(costCount.ToString(), true);
	}

	// Token: 0x02007B9E RID: 31646
	private enum EComponent
	{
		// Token: 0x0402A40A RID: 173066
		TxtTips,
		// Token: 0x0402A40B RID: 173067
		TxtCost,
		// Token: 0x0402A40C RID: 173068
		CostIcon
	}
}
